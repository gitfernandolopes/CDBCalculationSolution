using CDBCalculationApi.Exceptions;
using CDBCalculationApi.Interfaces;
using CDBCalculationApi.Models;
using CDBCalculationApi.Services;

namespace CDBCalculationApi.Tests
{
    public class CdiInvestmentCalculatorTests
    {
        [Fact]
        public void Calculate_WithValidData_ReturnsCorrectResults()
        {
            // Arrange
            IInvestmentCalculator calculator = new CdiInvestmentCalculator();
            InvestmentData data = new()
            {
                InitialValue = 100,  // Initial investment value
                Months = 7           // Number of months
            };

            // Act
            InvestmentResult result = calculator.Calculate(data);

            // Assert
            // Verify if the gross result (GrossResult) is close to 107.0056502195483
            Assert.Equal(107.01, result.GrossResult, 2);

            // Verify if the net result (NetResult) is close to 105.60452017563864
            Assert.Equal(105.60, result.NetResult, 2);
        }

        [Fact]
        public void Calculate_WithOneMonth_ThrowsInvestmentCalculatorException()
        {
            // Arrange
            IInvestmentCalculator calculator = new CdiInvestmentCalculator();
            InvestmentData data = new()
            {
                InitialValue = 1000,
                Months = 1   // month less than or equal to 1, throws exception
            };

            // Act & Assert
            Assert.Throws<InvestmentCalculatorException>(() => calculator.Calculate(data));
        }

        [Fact]
        public void Calculate_WithNegativeInitialValue_ThrowsInvestmentCalculatorException()
        {
            // Arrange
            IInvestmentCalculator calculator = new CdiInvestmentCalculator();
            InvestmentData data = new()
            {
                InitialValue = -100,  // Negative initial value, invalid
                Months = 12
            };

            // Act & Assert
            Assert.Throws<InvestmentCalculatorException>(() => calculator.Calculate(data));
        }

        [Fact]
        public void Calculate_WithNegativeMonths_ThrowsInvestmentCalculatorException()
        {
            // Arrange
            IInvestmentCalculator calculator = new CdiInvestmentCalculator();
            InvestmentData data = new()
            {
                InitialValue = 1000,
                Months = -6  // Negative months, invalid
            };

            // Act & Assert
            Assert.Throws<InvestmentCalculatorException>(() => calculator.Calculate(data));
        }

        [Theory]
        [InlineData(0, 12)] // Invalid InitialValue
        [InlineData(1000, 0)] // Invalid Months
        public void Calculate_WithInvalidData_ThrowsInvestmentCalculatorException(double initialValue, int months)
        {
            // Arrange
            IInvestmentCalculator calculator = new CdiInvestmentCalculator();
            InvestmentData data = new()
            {
                InitialValue = initialValue,
                Months = months
            };

            // Act & Assert
            Assert.Throws<InvestmentCalculatorException>(() => calculator.Calculate(data));
        }

        [Theory]
        [InlineData(6, 0.225)] // 6 months, TaxRate6Months
        [InlineData(12, 0.2)]  // 12 months, TaxRate12Months
        [InlineData(24, 0.175)] // 24 months, TaxRate24Months
        [InlineData(25, 0.15)]  // More than 24 months, DefaultTaxRate
        public void GetTaxRate_ReturnsCorrectTaxRate(int months, double expectedTaxRate)
        {
            // Arrange
            CdiInvestmentCalculator calculator = new();

            // Act
            double taxRate = calculator.GetTaxRate(months);

            // Assert
            Assert.Equal(expectedTaxRate, taxRate, 4); // 4 decimal places for precision
        }
    }
}
