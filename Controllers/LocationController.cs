using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly AppDbContext _context;

        public LocationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(string id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> CreateLocation(LocationDto location)
        {
            var newLocation = new Location
            {
                Id = Guid.NewGuid().ToString(),
                AddressLine1 = location.AddressLine1,
                AddressLine2 = location.AddressLine2,
                AddressLine3 = location.AddressLine3
            };

            _context.Locations.Add(newLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLocation), new { id = newLocation.Id }, newLocation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(string id, LocationDto location)
        {
            var existingLocation = await _context.Locations.FindAsync(id);
            if (existingLocation == null)
            {
                return NotFound();
            }

            existingLocation.AddressLine1 = location.AddressLine1;
            existingLocation.AddressLine2 = location.AddressLine2;
            existingLocation.AddressLine3 = location.AddressLine3;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_context.Locations.Any(l => l.Id == id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(string id)
        {
            var existingLocation = await _context.Locations.FindAsync(id);
            if (existingLocation == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(existingLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}