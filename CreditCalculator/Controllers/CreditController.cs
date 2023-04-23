using CreditCalculator.Models;
using CreditCalculator.Services.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace CreditCalculator.Controllers
{
    [Route("api/[controller]")]
    public class CreditController : ControllerBase
    {
        private readonly CalculatorService _calculatorService;

        public CreditController(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        [HttpPost("calculate-monthly-payments")]
        public IActionResult CalculateCreditInfo([FromBody] CreditInfo creditInfo)
        {
            try
            {
                if (_calculatorService.IsValidCreditInfo(creditInfo))
                {
                    var monthlyPayments =
                        _calculatorService.GetMonthlyPaymentsFromCreditInfo(creditInfo);
                    return Ok(monthlyPayments);
                }

                return BadRequest("Not valid data");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}