﻿using HotDesks.Models;
using HotDesks.DTOs;

namespace HotDesks.Services
{
    public interface IDeskService
    {
        IEnumerable<Desk> GetAll();
        IEnumerable<Desk> GetAvailableDesks(DateTime startDate, DateTime endDate, int locationId);
        Desk GetByDeskNumber(string deskNumber);
        void AddDesk(DeskDTO deskDto);
        void UpdateDesk(int id, DeskDTO deskDto);
        void RemoveDesk(int id);
        void DisableDesk(int id);
    }

}
