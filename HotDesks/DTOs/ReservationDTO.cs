﻿namespace HotDesks.DTOs
{
    public class ReservationDTO
    {
        public int DeskId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
