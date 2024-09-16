using HotDesks.DTOs;
using HotDesks.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Desks.ToList();
        }

        public Desk GetById(int id)
        {
            return _context.Desks.Include(d => d.Location).FirstOrDefault(d => d.Id == id);
        }

        public void AddDesk(DeskDTO deskDTO)
        {
            var desk = new Desk
            {
                LocationId = deskDTO.LocationId,
                DeskNumber = deskDTO.DeskNumber
            };
            _context.Desks.Add(desk);
            _context.SaveChanges();
        }

        public void UpdateDesk(int id, DeskDTO deskDTO)
        {
            var desk = _context.Desks.Find(id);
            if (desk != null)
            {
                desk.LocationId = deskDTO.LocationId;
                desk.DeskNumber = deskDTO.DeskNumber;
                _context.SaveChanges();
            }
        }

        public void RemoveDesk(int id)
        {
            var desk = _context.Desks.Find(id);
            if (desk != null)
            {
                _context.Desks.Remove(desk);
                _context.SaveChanges();
            }
        }
    }

}
