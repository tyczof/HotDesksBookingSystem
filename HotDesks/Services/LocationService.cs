using HotDesks.DTOs;
using HotDesks.Models;
using Microsoft.EntityFrameworkCore;

namespace HotDesks.Services
{
    public class LocationService : ILocationService
    {
        private readonly HotDeskContext _context;

        public LocationService(HotDeskContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> GetAll()
        {
            return _context.Locations.ToList();
        }

        public Location GetById(int id)
        {
            return _context.Locations.Include(l => l.Desks).FirstOrDefault(l => l.Id == id);
        }

        public void AddLocation(LocationDTO locationDto)
        {
            var location = new Location
            {
                Name = locationDto.Name,
            };
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public void UpdateLocation(int id, LocationDTO locationDto)
        {
            var location = _context.Locations.Find(id);
            if (location != null)
            {
                location.Name = locationDto.Name;
                _context.SaveChanges();
            }
        }

        public void RemoveLocation(int id)
        {
            var location = _context.Locations.Include(l => l.Desks).FirstOrDefault(l => l.Id == id);
            if (location != null && location.Desks.Count == 0)
            {
                _context.Locations.Remove(location);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Cannot remove location if desks exist in the location.");
            }
        }
    }
}
