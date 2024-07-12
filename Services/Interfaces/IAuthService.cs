using InventoryControlSystemAPI.DTOs;

namespace InventoryControlSystemAPI.Services.Interfaces
{
    public interface IAuthService
    {
        User? GetUserWithRole(AuthDto credential);
        bool IsPasswordMatched(AuthDto credential);
        string GenerateToken(User user);
    }
}