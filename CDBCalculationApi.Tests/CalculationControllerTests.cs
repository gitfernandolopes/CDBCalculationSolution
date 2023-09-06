using CDBCalculationApi.Interfaces;
using CDBCalculationApi.Models;
using CDBCalculatorApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CDBCalculationApi.Tests
{
    public class CalculationControllerTests
    {
        [Fact]
        public void Calculate_WithValidData_ReturnsOkResult()
        {
            // Arrange
            var calculatorMock = new Mock<IInvestmentCalculator>();
            calculatorMock.Setup(c => c.Calculate(It.IsAny<InvestmentData>())).Returns(new InvestmentResult
            {
                GrossResult = 107.01,
                NetResult = 5.60
            });
            var controller = new CalculationController(calculatorMock.Object);
            var data = new InvestmentData { InitialValue = 100, Months = 7 };

            // Act
            var result = controller.Calculate(data) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var investmentResult = result.Value as InvestmentResult;
            Assert.NotNull(investmentResult);
            Assert.Equal(107.01, investmentResult.GrossResult, 2);
            Assert.Equal(5.60, investmentResult.NetResult, 2);
        }
    }
}




