using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystemAPI.Controllers
{
    [Authorize(Roles = "Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : Controller
    {
        private readonly AppDbContext _context;

        public StoreController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            return await _context.Stores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Store>>> GetStore(string id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        [HttpPost]
        public async Task<ActionResult<Store>> CreateStore(StoreDto store)
        {
            var newStore = new Store
            {
                Id = Guid.NewGuid().ToString(),
                LocationId = store.LocationId
            };

            _context.Stores.Add(newStore);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStore), new { id = newStore.Id }, newStore);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(string id, StoreDto store)
        {
            var existingStore = await _context.Stores.FindAsync(id);
            if (existingStore == null)
            {
                return NotFound();
            }

            existingStore.LocationId = store.LocationId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_context.Stores.Any(l => l.Id == id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(string id)
        {
            var existingStore = await _context.Stores.FindAsync(id);
            if (existingStore == null)
            {
                return NotFound();
            }

            _context.Stores.Remove(existingStore);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}