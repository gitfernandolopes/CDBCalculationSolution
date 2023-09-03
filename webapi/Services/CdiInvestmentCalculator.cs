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
                if (data.InitialValue <= 0 || data.Months <= 0)
                {
                    throw new InvestmentCalculatorException("Valores de entrada inválidos.");
                }

                double grossResult = data.InitialValue; 
                
                for (int i = 0; i < data.Months; i++)
                {
                    grossResult *= (1 + (CDI * TB));                    
                }

                double taxRate = GetTaxRate(data.Months);
                double netResult = grossResult * (1 - taxRate);

                InvestmentResult result = new()
                {
                    GrossResult = Math.Round(grossResult, 2),
                    NetResult = Math.Round(netResult, 2)
                };

                return result;
            }
            catch (InvestmentCalculatorException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new InvestmentCalculatorException("Erro interno no cálculo do investimento.");
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
