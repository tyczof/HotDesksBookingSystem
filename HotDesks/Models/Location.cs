namespace HotDesks.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Desk> Desks { get; set; }
        public Location() 
        {
            Id = new int();
            Desks = new List<Desk>();
        }
        public Location(string name)
        {
            Id = new int();
            Name = name;
            Desks = new List<Desk>();
        }
    }
}
