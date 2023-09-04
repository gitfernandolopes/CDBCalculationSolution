# CDB Calculation API Testing Guide

This guide provides instructions on how to run tests for the CDB Calculation API solution. The tests are written using xUnit and are located in the `CDBCalculationApi.Tests` project.

## Prerequisites

Before running the tests, make sure you have the following prerequisites installed:

1. [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) - The tests are written in C# and require the SDK do .NET 7.0 for execution.

## Running the Tests

To run the tests, follow these steps:

1. Open a terminal or command prompt.

2. Navigate to the root directory of the `CDBCalculation` solution.

3. Change the directory to the `CDBCalculationApi.Tests` project:

cd CDBCalculationApi.Tests

4. Run the tests using the following command:

dotnet test


This command will execute all the tests in the project.

5. After running the tests, you will see the test results displayed in the terminal. Make sure that all tests pass without any errors.

## Test Cases

Here is an overview of the test cases available in the `CdiInvestmentCalculatorTests` class:

- `Calculate_WithValidData_ReturnsCorrectResults`: Tests the calculation of gross and net results with valid input data.

- `Calculate_WithNegativeInitialValue_ThrowsInvestmentCalculatorException`: Tests the handling of a negative initial investment value.

- `Calculate_WithNegativeMonths_ThrowsInvestmentCalculatorException`: Tests the handling of a negative number of months.

- `Calculate_WithInvalidData_ThrowsInvestmentCalculatorException`: Tests various combinations of invalid data, such as zero initial value or zero months.

- `GetTaxRate_ReturnsCorrectTaxRate`: Tests the calculation of tax rates for different numbers of months.

## Test Output

The test output includes information about each test case, including whether it passed or failed. The output will also display any error messages or exceptions if a test fails.

Make sure to review the test output to ensure the correctness of the API calculations and error handling.

## Additional Notes

- The tests are designed to cover various scenarios and edge cases to ensure the robustness of the CDB Calculation API.

- If you encounter any issues or failures during testing, refer to the error messages and the test code for debugging and troubleshooting.

- Ensure that the API and its dependencies are properly configured before running the tests.
