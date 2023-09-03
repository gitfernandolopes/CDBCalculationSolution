using CDBCalculationApi.Models;

namespace CDBCalculationApi.Interfaces
{
    public interface IInvestmentCalculator
    {
        InvestmentResult Calculate(InvestmentData data);
    }

    public class CdiInvestmentCalculator : IInvestmentCalculator
    {
        private static readonly double TB = 1.08;
        private static readonly double CDI = 0.009;
        private static readonly double TaxRate6Months = 0.225;
        private static readonly double TaxRate12Months = 0.2;
        private static readonly double TaxRate24Months = 0.175;
        private static readonly double DefaultTaxRate = 0.15;

        public InvestmentResult Calculate(InvestmentData data)
        {
            double currentPrincipal = data.InitialValue;
            double grossResult = currentPrincipal;
            double netResult = currentPrincipal;

            for (int i = 0; i < data.Months; i++)
            {
                grossResult = currentPrincipal * (1 + CDI * TB);
                double taxRate = GetTaxRate(i + 1);
                netResult = grossResult * (1 - taxRate);

                currentPrincipal = netResult;
            }

            InvestmentResult result = new()
            {
                GrossResult = grossResult,
                NetResult = netResult
            };

            return result;
        }

        private double GetTaxRate(int months)
        {
            if (months <= 6) return TaxRate6Months;
            if (months <= 12) return TaxRate12Months;
            if (months <= 24) return TaxRate24Months;
            return DefaultTaxRate;
        }
    }
}


