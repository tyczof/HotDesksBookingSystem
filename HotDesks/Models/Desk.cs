using HotDesks.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

namespace HotDesks.Models
{
    public class Desk
    {
        public int Id { get; set; }
        public string DeskNumber { get; set; }
        public bool IsAvailable { get; set; } //permanent availability flag
        public int LocationId { get; set; }
        [JsonIgnore]
        public Location Location { get; set; }
        public ICollection<Reservation> Reservations { get; set; }


        public Desk(string deskNumber, bool isAvailable, int locationId)
        {
            Id = new int();
            DeskNumber = deskNumber;
            IsAvailable = isAvailable;
            LocationId = locationId;
            Reservations = new List<Reservation>();
        }
        public Desk()
        {
            Id = new int();
            Reservations = new List<Reservation>();
        }
        public bool CheckIfReservedOnDate(DateTime startDate, DateTime endDate)
        {
            return Reservations.Where(r => !r.isCancelled).Any(r => r.StartDate <= endDate && r.EndDate >= startDate);
        }
        public List<ReservationInfoDTO> GetReservationsInPeriod(DateTime startDate, DateTime endDate)
        {
            var reservations = Reservations
                .Where(r => !r.isCancelled && r.StartDate <= endDate && r.EndDate >= startDate)
                .OrderBy(r => r.StartDate)
                .ToList();

            if (!reservations.IsNullOrEmpty())
            {
                return reservations.Select(r => new ReservationInfoDTO
                    {
                        Id = r.Id,
                        DeskId = Id,
                        DeskNumber = DeskNumber,
                        EmployeeId = r.EmployeeId,
                        StartDate = r.StartDate,
                        EndDate = r.EndDate
                    })
                    .ToList();
            }
            return [];
        }

    }
}
