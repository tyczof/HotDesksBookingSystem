using HotDesks.DTOs;
using HotDesks.Models;

namespace HotDesks.Services
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAll();
        IEnumerable<ReservationInfoDTO> GetEmployeeReservations(int employeeId);
        Reservation GetById(int id);
        void AddReservation(ReservationDTO reservationDto);
        void UpdateReservation(int id, ReservationDTO reservationDto);
        void CancelReservation(int id);
    }

}
