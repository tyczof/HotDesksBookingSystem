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
            return _context.Reservations.Include(r => r.Desk).Include(r => r.Employee).ToList();
        }

        public Reservation GetById(int id)
        {
            return _context.Reservations.Include(r => r.Desk).Include(r => r.Employee).FirstOrDefault(r => r.Id == id);
        }

        public void AddReservation(ReservationDTO reservationDTO)
        {
            var reservation = new Reservation
            {
                DeskId = reservationDTO.DeskId,
                EmployeeId = reservationDTO.EmployeeId,
                StartDate = reservationDTO.StartDate,
                EndDate = reservationDTO.EndDate
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
