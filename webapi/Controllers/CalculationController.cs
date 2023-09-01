using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Http;

namespace CDBCalculatorApi.Controllers
{
    public class CalculationController : ApiController
    {
        private object grossResult;
        private object netResult;

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/calculate")]
        public IHttpActionResult CalculateInvestment([System.Web.Http.FromBody] InvestmentData data)
        {
            const double TB = 1.08;
            const double CDI = 0.009;
            double currentPrincipal = data.InitialValue;

            for (int i = 0; i < data.Months; i++)
            {
                double grossResult = currentPrincipal * (1 + CDI * TB);
                double taxRate = GetTaxRate(i + 1);
                double netResult = grossResult * (1 - taxRate);

                currentPrincipal = netResult;
            }

            return Ok(new { grossResult, netResult });
        }

        private double GetTaxRate(int months)
        {
            if (months <= 6) return 0.225;
            if (months <= 12) return 0.2;
            if (months <= 24) return 0.175;
            return 0.15;
        }
    }

    public class InvestmentData
    {
        public double InitialValue { get; set; }
        public int Months { get; set; }
    }
}

