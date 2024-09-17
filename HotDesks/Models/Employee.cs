namespace HotDesks.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
