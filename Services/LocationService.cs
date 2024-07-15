using InventoryControlSystemAPI.DTOs;
using InventoryControlSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystemAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly AppDbContext _context;

        public LocationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location?> GetLocation(string id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task<Location> CreateLocation(LocationDto Location)
        {
            var newLocation = new Location
            {
                Id = Guid.NewGuid().ToString(),
                AddressLine1 = Location.AddressLine1,
                AddressLine2 = Location.AddressLine2,
                AddressLine3 = Location.AddressLine3
            };

            _context.Locations.Add(newLocation);
            await _context.SaveChangesAsync();
            return newLocation;
        }

        public async Task<Location?> UpdateLocation(string id, LocationDto updatedLocation)
        {
            var existingLocation = await GetLocation(id);
            if (existingLocation == null)
            {
                return null;
            }

            if (updatedLocation.AddressLine1 != null) existingLocation.AddressLine1 = updatedLocation.AddressLine1;
            if (updatedLocation.AddressLine2 != null) existingLocation.AddressLine2 = updatedLocation.AddressLine2;
            if (updatedLocation.AddressLine3 != null) existingLocation.AddressLine3 = updatedLocation.AddressLine3;

            await _context.SaveChangesAsync();

            return existingLocation;
        }

        public async Task<bool> DeleteLocation(string id)
        {
            var location = await GetLocation(id);
            if (location == null)
            {
                return false;
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}