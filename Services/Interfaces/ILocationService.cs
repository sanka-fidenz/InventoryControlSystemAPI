using InventoryControlSystemAPI.DTOs;

namespace InventoryControlSystemAPI.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<Location?> GetLocation(string id);
        Task<Location> CreateLocation(LocationDto newLocation);
        Task<Location?> UpdateLocation(string id, LocationDto updatedLocation);
        Task<bool> DeleteLocation(string id);
    }
}