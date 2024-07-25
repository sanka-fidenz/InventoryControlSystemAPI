using InventoryControlSystemAPI.DTOs;
using InventoryControlSystemAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlSystemAPI.Controllers
{
    [Authorize(Roles = "Operator,Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sales>>> GetSales()
        {
            var sales = await _salesService.GetSales();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> GetSale(string id)
        {
            var sales = await _salesService.GetSale(id);

            if (sales == null)
            {
                return NotFound();
            }

            return Ok(sales);
        }

        [HttpPost]
        public async Task<ActionResult<Sales>> CreateSales(PurchaseCreateDto newSales)
        {
            var sales = await _salesService.CreateSale(newSales);
            return CreatedAtAction(nameof(GetSales), new { id = sales.Id }, sales);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSales(string id, PurchaseUpdateDto updatedSales)
        {
            var sales = await _salesService.UpdateSale(id, updatedSales);

            if (sales == null)
            {
                return NotFound();
            }

            return Ok(sales);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSales(string id)
        {
            var success = await _salesService.DeleteSale(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}