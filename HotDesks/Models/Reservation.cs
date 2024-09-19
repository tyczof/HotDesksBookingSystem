using System.Text.Json.Serialization;

namespace HotDesks.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int DeskId { get; set; }
        [JsonIgnore]
        public Desk Desk { get; set; }
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isCancelled {  get; set; }

        public string GetReservationStatus()
        {
            if (isCancelled)
            {
                return ReservationStatus.Cancelled.ToString();
            }
            else if (EndDate <= DateTime.Now)
            {
                return ReservationStatus.Complete.ToString();
            }
            else if (StartDate <= DateTime.Now && EndDate >= DateTime.Now)
            {
                return ReservationStatus.Ongoing.ToString();
            }
            else
            {
                return ReservationStatus.Upcoming.ToString();
            }
        }
        public void CancelReservation()
        {
            this.isCancelled = true;
        }
    }
}
