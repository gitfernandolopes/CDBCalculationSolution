using CDBCalculationApi.Models;


namespace CDBCalculationApi.Interfaces
{
    public interface IInvestmentCalculator
    {
        InvestmentResult Calculate(InvestmentData data);
    }

    public class CDIInvestmentCalculator : IInvestmentCalculator
    {
        public InvestmentResult Calculate(InvestmentData data)
        {
            const double TB = 1.08;
            const double CDI = 0.009;
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

            InvestmentResult result = new InvestmentResult
            {
                GrossResult = grossResult,
                NetResult = netResult
            };

            return result;
        }
        
        private double GetTaxRate(int months)
        {
            if (months <= 6) return 0.225;
            if (months <= 12) return 0.2;
            if (months <= 24) return 0.175;
            return 0.15;
        }
    }

}


