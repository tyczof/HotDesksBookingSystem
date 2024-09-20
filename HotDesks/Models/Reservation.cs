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

        public ReservationStatus GetReservationStatus(bool throwExceptions = true)
        {
            bool isTomorrow;
            CheckIfLessThan24hToStartDate(out isTomorrow, throwExceptions);

            if (isCancelled)
            {
                return ReservationStatus.Cancelled;
            }
            else if (EndDate <= DateTime.Now)
            {
                return ReservationStatus.Complete;
            }
            else if (StartDate <= DateTime.Now && EndDate >= DateTime.Now)
            {
                return ReservationStatus.Ongoing;
            }
            else if (isTomorrow)
            {
                return ReservationStatus.Tomorrow;
            }
            else
            {
                return ReservationStatus.Upcoming;
            }
        }
        public void CancelReservation()
        {
            bool isTomorrow;
            CheckIfLessThan24hToStartDate(out isTomorrow);
            if (!isTomorrow)   
            {
                isCancelled = true;
            }
        }
        private void CheckIfLessThan24hToStartDate(out bool success, bool throwExceptions = true)
        {
            if ((StartDate - DateTime.Now).TotalHours < 24)
            {
                success = true;
                if (throwExceptions)
                    throw new InvalidOperationException("Cannot change reservation less than 24 hours before.");
            }
            else
            {
                success = false;
            }
        }
    }
}
