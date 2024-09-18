namespace HotDesks.DTOs
{
    public class DeskInfoDTO
    {
        public int Id { get; set; }
        public string DeskNumber { get; set; }
        public bool IsAvailable { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public bool IsReservedOnDate { get; set; }
    }
}
