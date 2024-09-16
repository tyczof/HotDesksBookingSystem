namespace HotDesks.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int DeskId { get; set; }
        public Desk Desk { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
