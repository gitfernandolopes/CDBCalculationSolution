using CDBCalculationApi.Models;

namespace CDBCalculationApi.Interfaces
{
    public interface IInvestmentCalculator
    {
        InvestmentResult Calculate(InvestmentData data);
    }
}


