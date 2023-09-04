# CDB Calculation API Solution Execution Guide

This guide provides instructions on how to run the CDB Calculation API solution using .NET 7.0. Please ensure that you have the .NET 7.0 SDK installed in your environment before starting.

## Prerequisites

Before running the solution, make sure you have the following prerequisites installed:

1. [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) - The .NET 7.0 SDK is required to build and run the application.

## Running the Solution

Follow these steps to run the CDB Calculation API solution:

1. Open a terminal or command prompt.

2. Navigate to the root directory of the solution project, where the `.csproj` file is located.

3. Run the following command to build the application:

dotnet build

4. After a successful build, run the following command to start the application:

dotnet run


5. The application will start and be available at `http://localhost:5000` (or another port, depending on the configuration).

## Testing the API

After starting the application, you can test the CDB Calculation API. The API exposes an endpoint for calculating the yield of a CDB investment:

- Endpoint: `http://localhost:5000/api/Calculation/calculate`
- Method: POST
- Request Body (JSON):
```json
{
   "InitialValue": 1000.00,
   "Months": 12
}

Replace the values in the request body as needed for your test.

## API Documentation
The API has automatically generated documentation using Swagger. To access the documentation, follow these steps:

Open a web browser.

Go to http://localhost:5000/swagger/index.html (or the URL of the configured port).

You will see the API documentation with information about available endpoints and how to use them.

## Ending Execution

To stop the application, press Ctrl+C in the terminal where the application is running. This will terminate the API server.

Ensure that the prerequisites are installed and follow the above instructions to run and test the CDB Calculation API.

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
