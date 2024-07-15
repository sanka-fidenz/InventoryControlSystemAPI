using InventoryControlSystemAPI.DTOs;
using InventoryControlSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystemAPI.Controllers
{
    [Authorize(Roles = "Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var categories = await _locationService.GetLocations();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(string id)
        {
            var location = await _locationService.GetLocation(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> CreateLocation(LocationDto newLocation)
        {
            var location = await _locationService.CreateLocation(newLocation);

            return CreatedAtAction(nameof(GetLocation), new { id = location.Id }, location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(string id, LocationDto updatedLocation)
        {
            var location = await _locationService.UpdateLocation(id, updatedLocation);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(string id)
        {
            var success = await _locationService.DeleteLocation(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}