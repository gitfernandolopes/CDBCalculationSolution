using CDBCalculationApi.Interfaces;
using CDBCalculationApi.Models;
using CDBCalculationApi.Exceptions;

namespace CDBCalculationApi.Services
{
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
            try
            {
                if (data.InitialValue <= 0)
                {
                    throw new InvestmentCalculatorException("The initial investment value must be a positive amount!");
                }

                if (data.Months <= 1)
                {
                    throw new InvestmentCalculatorException("The redemption period for the investment must be greater than 1 month");
                }

                double grossResult = data.InitialValue;

                for (int i = 0; i < data.Months; i++)
                {
                    grossResult *= (1 + (CDI * TB));
                }

                double taxRate = GetTaxRate(data.Months);
                double earnings = grossResult - data.InitialValue;
                double netResult = data.InitialValue + earnings * (1 - taxRate);

                InvestmentResult result = new()
                {
                    GrossResult = grossResult,
                    NetResult = netResult,
                };

                return result;
            }
            catch (InvestmentCalculatorException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new InvestmentCalculatorException("Internal error in investment calculation.");
            }
        }

        public double GetTaxRate(int months)
        {
            if (months <= 6) return TaxRate6Months;
            if (months <= 12) return TaxRate12Months;
            if (months <= 24) return TaxRate24Months;
            return DefaultTaxRate;
        }
    }
}
