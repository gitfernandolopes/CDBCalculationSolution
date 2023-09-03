using CDBCalculationApi.Interfaces;
using CDBCalculationApi.Models;
using NUnit.Framework;

namespace CDBCalculationApi.Tests
{
    [TestFixture]
    public class CDIInvestmentCalculatorTests
    {
        [Test]
        public void Calculate_CalculatesInvestmentCorrectly()
        {

            CdiInvestmentCalculator calculator = new();
            InvestmentData data = new()
            {
                InitialValue = 1000,
                Months = 12
            };

            InvestmentResult result = calculator.Calculate(data);

            Assert.That(result.GrossResult, Is.EqualTo(1261.58).Within(0.01)); 
            Assert.That(result.NetResult, Is.EqualTo(1161.58).Within(0.01)); 
        }

        [Test]
        public void Calculate_CalculatesInvestmentWithDifferentValues()
        {
            CdiInvestmentCalculator calculator = new();

            InvestmentData data1 = new()
            {
                InitialValue = 2000,
                Months = 6
            };

            InvestmentData data2 = new()
            {
                InitialValue = 5000,
                Months = 24
            };

            InvestmentResult result1 = calculator.Calculate(data1);
            InvestmentResult result2 = calculator.Calculate(data2);

            Assert.That(result1.GrossResult, Is.EqualTo(2123.36).Within(0.01)); 
            Assert.That(result1.NetResult, Is.EqualTo(1943.36).Within(0.01)); 

            Assert.That(result2.GrossResult, Is.EqualTo(5456.83).Within(0.01));
            Assert.That(result2.NetResult, Is.EqualTo(4996.83).Within(0.01));
        }

    }
}
