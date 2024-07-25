using InventoryControlSystemAPI.DTOs;
using InventoryControlSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystemAPI.Controllers
{
    [Authorize(Roles = "Operator,Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases()
        {
            var purchases = await _purchaseService.GetPurchases();
            return Ok(purchases);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(string id)
        {
            var purchase = await _purchaseService.GetPurchase(id);

            if (purchase == null)
            {
                return NotFound();
            }

            return Ok(purchase);
        }

        [HttpPost]
        public async Task<ActionResult<Purchase>> CreatePurchase(PurchaseCreateDto newPurchase)
        {
            var purchase = await _purchaseService.CreatePurchase(newPurchase);
            return CreatedAtAction(nameof(GetPurchase), new { id = purchase.Id }, purchase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePurchase(string id, PurchaseUpdateDto updatedPurchase)
        {
            var purchase = await _purchaseService.UpdatePurchase(id, updatedPurchase);

            if (purchase == null)
            {
                return NotFound();
            }

            return Ok(purchase);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(string id)
        {
            var success = await _purchaseService.DeletePurchase(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}