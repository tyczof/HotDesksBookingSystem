using System.Diagnostics.Contracts;

namespace HotDesks.DTOs
{
    public class ReservationInfoDTO
    {
        public int Id { get; set; }
        public int DeskId { get; set; }
        public string DeskNumber { get; set; }
        public string DeskLocationName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReservationStatus { get; set; }
    }
}
