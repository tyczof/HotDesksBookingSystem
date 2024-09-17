﻿using HotDesks.DTOs;
using HotDesks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HotDesks.Services
{
    public class DeskService : IDeskService
    {
        private readonly HotDeskContext _context;

        public DeskService(HotDeskContext context)
        {
            _context = context;
        }

        public IEnumerable<Desk> GetAll()
        {
            return _context.Desks.Include(d => d.Reservations).ToList();
        }

        public Desk GetByDeskNumber(string deskNumber)
        {
            return _context.Desks.FirstOrDefault(d => d.DeskNumber == deskNumber);
        }

        public void AddDesk(DeskDTO deskDTO)
        {
            var desk = new Desk(deskDTO.DeskNumber, deskDTO.IsAvailable, deskDTO.LocationId);
            _context.Desks.Add(desk);
            _context.SaveChanges();
        }

        public void UpdateDesk(int id, DeskDTO deskDTO)
        {
            var desk = _context.Desks.Find(id);
            if (desk != null)
            {
                desk.DeskNumber = deskDTO.DeskNumber;
                desk.IsAvailable = deskDTO.IsAvailable;
                desk.LocationId = deskDTO.LocationId;
                _context.SaveChanges();
            }
        }

        public void RemoveDesk(int id)
        {
            var desk = _context.Desks.Include(d => d.Reservations).FirstOrDefault(d => d.Id == id);
            var upcomingReservations = desk.Reservations.Where(d => d.StartDate >= DateTime.Now);
            if (desk != null && upcomingReservations.IsNullOrEmpty())
            {
                _context.Desks.Remove(desk);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Cannot remove desk if desk have an upcoming reservation.");
            }
        }
        public void DisableDesk(int id)
        {
            var desk = _context.Desks.Find(id);
            if (desk != null)
            {
                desk.IsAvailable = false;
                _context.SaveChanges();
            }
        }
    }

}
