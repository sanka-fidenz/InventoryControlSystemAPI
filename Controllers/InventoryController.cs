using InventoryControlSystemAPI.DTOs;
using InventoryControlSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystemAPI.Controllers
{
    [Authorize(Roles = "Operator,Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService categoryService)
        {
            _inventoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories([FromQuery] string? storeId, [FromQuery] string? productId)
        {
            var categories = await _inventoryService.GetInventories(storeId, productId);

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(string id)
        {
            var inventory = await _inventoryService.GetInventory(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        [HttpPost]
        public async Task<ActionResult<Inventory>> CreateInventory(InventoryCreateDto newInventory)
        {
            var inventory = await _inventoryService.CreateInventory(newInventory);

            return CreatedAtAction(nameof(GetInventory), new { id = inventory.Id }, inventory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventory(string id, InventoryUpdateDto updatedInventory)
        {
            var inventory = await _inventoryService.UpdateInventory(id, updatedInventory);

            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(string id)
        {
            var success = await _inventoryService.DeleteInventory(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}