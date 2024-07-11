using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystemAPI.Controllers
{
    [Authorize(Roles = "Operator,Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private readonly AppDbContext _context;

        public InventoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories([FromQuery] string? storeId, [FromQuery] string? productId)
        {
            var query = _context.Inventories.AsQueryable();

            if (!string.IsNullOrEmpty(storeId))
            {
                query = query.Where(inventory => inventory.StoreId == storeId);
            }
            if (!string.IsNullOrEmpty(productId))
            {
                query = query.Where(inventory => inventory.ProductId == productId);
            }

            return await query.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(string id)
        {
            var inventory = await _context.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        [HttpPost]
        public async Task<ActionResult<Inventory>> CreateInventory(InventoryDto inventory)
        {
            var newInventory = new Inventory
            {
                Id = Guid.NewGuid().ToString(),
                Count = inventory.Count
            };

            _context.Inventories.Add(newInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInventory), new { id = newInventory.Id }, newInventory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventory(string id, InventoryDto inventory)
        {
            var existingInventory = await _context.Inventories.FindAsync(id);
            if (existingInventory == null)
            {
                return NotFound();
            }

            existingInventory.Count = inventory.Count;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_context.Inventories.Any(e => e.Id == id))
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