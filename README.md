# Instructions for Running the CDB Calculation API Solution

This guide provides the necessary instructions for running the CDB Calculation API solution in an environment with .NET 7.0. The API allows you to calculate the gross and net yield of a CDB investment based on provided parameters.

## Prerequisites

Make sure you have the following prerequisites installed:

1. .NET 7.0 SDK - You can download it [here](https://dotnet.microsoft.com/download/dotnet/7.0).

## Steps to Run

Follow these steps to run the CDB Calculation API solution:

1. Clone the repository to your local system:

git clone [Repository URL]

2. Navigate to the project directory:

cd CDBCalculationApi

3. Open the project in Visual Studio Code or your preferred IDE.

4. Ensure that project dependencies are restored by running the following command:

dotnet restore

5. Run the application with the following command:

dotnet run

The API is now running locally at `https://localhost:5001` (HTTPS) or `http://localhost:5000` (HTTP).

## Using the API

You can use the API to calculate the gross and net yield of a CDB investment by making a POST request to the `/api/calculation/calculate` endpoint. Here are the request details:

- Method: POST
- URL: `https://localhost:5001/api/calculation/calculate` (or `http://localhost:5000/api/calculation/calculate`)
- Request Body (JSON):

{
"initialValue": 100,
"months": 7
}

initialValue: The initial investment (must be a positive value).
months: The investment duration in months for redemption (must be greater than 0).
The API response will include the gross and net yield of the investment in JSON format:

{
  "grossResult": 107.01,
  "netResult": 105.60
}

Remember to adjust security and production settings before deploying the API to a production environment.

API Documentation
API documentation is available using Swagger. You can access it by navigating to https://localhost:5001/swagger (or http://localhost:5000/swagger) in your browser

Additional Notes
In a production environment, adjust this configuration as needed to enhance security.
Be sure to handle errors appropriately in your application, especially the exceptions defined in the code, such as InvestmentCalculatorException.
You are now ready to run the CDB Calculation API solution in a local environment.

# CDB Calculation API Testing Guide

This guide provides instructions on how to run tests for the CDB Calculation API solution. The tests are written using xUnit and are located in the `CDBCalculationApi.Tests` project.

## Prerequisites

Before running the tests, make sure you have the following prerequisites installed:

1. [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) - The tests are written in C# and require the SDK do .NET 7.0 for execution.

## Running the Tests

To run the tests, follow these steps:

1. Open a terminal or command prompt.

2. Navigate to the root directory of the `CDBCalculationApi` solution.

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

- `Calculate_WithValidData_ReturnsOkResult`: Tests the Calculate method in the CalculationController class with valid input data and checks if it returns an OK result with the correct investment results.



