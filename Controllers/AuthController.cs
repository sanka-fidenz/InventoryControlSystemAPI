using InventoryControlSystemAPI.DTOs;
using InventoryControlSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult LoginUser(AuthDto credential)
        {
            var user = _authService.GetUserWithRole(credential);

            if (user == null)
            {
                return NotFound("User not found");
            }

            if (!_authService.IsPasswordMatched(credential))
            {
                return Unauthorized("Invalid password");
            }

            return Ok(_authService.GenerateToken(user));

        }
    }
}