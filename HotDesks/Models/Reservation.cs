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
    }
}
