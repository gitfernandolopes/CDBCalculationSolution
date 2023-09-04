using CDBCalculationApi.Interfaces;
using CDBCalculationApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDBCalculatorApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CalculationController : ControllerBase
    {
        private readonly IInvestmentCalculator _investmentCalculator;

        public CalculationController(IInvestmentCalculator investmentCalculator)
        {
            _investmentCalculator = investmentCalculator;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] InvestmentData data)
        {
            var result = _investmentCalculator.Calculate(data);

            return Ok(result);
        }
    }

}

