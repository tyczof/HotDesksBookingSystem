using HotDesks.Models;
using HotDesks.DTOs;

namespace HotDesks.Services
{
    public interface ILocationService
    {
        IEnumerable<Location> GetAll();
        Location GetById(int id);
        void AddLocation(LocationDTO locationDto);
        void UpdateLocation(int id, LocationDTO locationDto);
        void RemoveLocation(int id);
    }

}
