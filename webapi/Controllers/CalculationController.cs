using CDBCalculationApi.Interfaces;
using CDBCalculationApi.Models;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CDBCalculatorApi.Controllers
{
    public class CalculationController : ApiController
    {
        private readonly IInvestmentCalculator _investmentCalculator;

        public CalculationController(IInvestmentCalculator investmentCalculator)
        {
            _investmentCalculator = investmentCalculator;
        }

        [HttpPost]
        [Route("api/calculate")]
        public IHttpActionResult CalculateInvestment([FromBody] InvestmentData data)
        {
            var result = _investmentCalculator.Calculate(data);
            return Ok(result);
        }
    }
}

