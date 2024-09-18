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

        public Reservation GetById(int id)
        {
            return _context.Reservations.Include(r => r.Desk).Include(r => r.Employee).FirstOrDefault(r => r.Id == id);
        }

        public void AddReservation(ReservationDTO reservationDto)
        {
                // Validate the reservation range
                if ((reservationDto.EndDate - reservationDto.StartDate).TotalDays > 7)
                    throw new InvalidOperationException("Cannot book for more than 7 days.");

                // Check if the desk is available in that range
                var desk = _context.Desks.Include(d => d.Reservations).Where(d => d.Id == reservationDto.DeskId).FirstOrDefault();
                var isAvailable = desk != null && !desk.CheckIfReservedOnDate(reservationDto.StartDate, reservationDto.EndDate);

                if (!isAvailable)
                    throw new InvalidOperationException("Desk is not available for the selected dates.");

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

        public void CancelReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
        }
    }

}
