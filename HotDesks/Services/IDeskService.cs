﻿using HotDesks.Models;
using HotDesks.DTOs;

namespace HotDesks.Services
{
    public interface IDeskService
    {
        IEnumerable<Desk> GetAll();
        Desk GetById(int id);
        void AddDesk(DeskDTO deskDto);
        void UpdateDesk(int id, DeskDTO deskDto);
        void RemoveDesk(int id);
    }

}
