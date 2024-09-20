using HotDesks.DTOs;
using HotDesks.Models;
using Microsoft.EntityFrameworkCore;

namespace HotDesks.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HotDeskContext _context;

        public ReservationService(HotDeskContext context)
        {
            _context = context;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }
        public IEnumerable<ReservationInfoDTO> GetEmployeeReservations(int employeeId)
        {
             var reservationDtos = _context.Reservations
                .Include(r => r.Employee)
                .Include(r => r.Desk)
                .ThenInclude(d => d.Location)
                .Where(r => r.EmployeeId == employeeId)
                .Select(r => new ReservationInfoDTO
                {
                    Id = r.Id,
                    DeskId = r.DeskId,
                    DeskNumber = r.Desk.DeskNumber,
                    DeskLocationName = r.Desk.Location.Name,
                    EmployeeId = r.EmployeeId,
                    EmployeeName = r.Employee.FirstName + " " + r.Employee.LastName,
                    EmployeeEmail = r.Employee.Email,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    ReservationStatus = r.GetReservationStatus(false)
                })
                .ToList();
            return reservationDtos.OrderBy(r => r.ReservationStatus).ThenBy(r => r.StartDate);
        }

        public Reservation GetById(int id)
        {
            return _context.Reservations.Include(r => r.Desk).Include(r => r.Employee).FirstOrDefault(r => r.Id == id);
        }

        public void AddReservation(ReservationDTO reservationDto)
        {
            // Validate the reservation range
            if ((reservationDto.EndDate - reservationDto.StartDate).TotalDays > 7)
                throw new InvalidOperationException("Cannot book for more than 7 days.");

            ConfirmDeskAvailability(reservationDto);

            // Create reservation
            var reservation = new Reservation
            {
                DeskId = reservationDto.DeskId,
                EmployeeId = reservationDto.EmployeeId,
                StartDate = reservationDto.StartDate,
                EndDate = reservationDto.EndDate
            };

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }
        public void UpdateReservation(int reservationId, ReservationDTO reservationDto)
        {
            var reservation = _context.Reservations.Find(reservationId);

            if (reservation == null)
                throw new InvalidOperationException("Reservation not found.");

            if (reservation.GetReservationStatus(true) == ReservationStatus.Upcoming)
            {
                ConfirmDeskAvailability(reservationDto);

                // Update desk in reservation
                reservation.DeskId = reservationDto.DeskId;
                reservation.StartDate = reservationDto.StartDate;
                reservation.EndDate = reservationDto.EndDate;
                _context.SaveChanges();
            }
            
        }

        public void CancelReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                reservation.CancelReservation();
                _context.SaveChanges();
            }
        }
        private void ConfirmDeskAvailability(ReservationDTO reservationDto)
        {
            // Check if the desk is available in that range
            var desk = _context.Desks.Include(d => d.Reservations).Where(d => d.Id == reservationDto.DeskId).FirstOrDefault();
            var isAvailable = desk != null && !desk.CheckIfReservedOnDate(reservationDto.StartDate, reservationDto.EndDate);

            if (!isAvailable)
                throw new InvalidOperationException("Desk is not available for the selected dates.");
        }
    }

}
