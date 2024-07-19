using InventoryControlSystemAPI.DTOs;

namespace InventoryControlSystemAPI.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<Location?> GetLocation(string id);
        Task<Location> CreateLocation(LocationCreateDto newLocation);
        Task<Location?> UpdateLocation(string id, LocationUpdateDto updatedLocation);
        Task<bool> DeleteLocation(string id);
    }
}