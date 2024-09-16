namespace HotDesks.Models
{
    public class Desk
    {
        public int Id { get; set; }
        public string DeskNumber { get; set; }
        public bool IsAvailable { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
