using Microsoft.AspNetCore.Mvc;
using PaidHr.Interfaces;

namespace PaidHr.Client;

    [ApiController]
    [Route("api/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _taxService;

        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpGet("calculate")]
        public async Task<IActionResult> Calculate(decimal income)
        {
            var tax = await _taxService.CalculateTaxAsync(income);
            return Ok(tax);
        }

        [HttpPost("rate")]
        public async Task<IActionResult> SetTaxRate(decimal rate)
        {
            await _taxService.StoreTaxRateAsync(rate);
            return NoContent();
        }
}