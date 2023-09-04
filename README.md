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

```json
{
"initialValue": 1000.0,
"months": 12
}

[initialValue: The initial investment (must be a positive value).
months: The investment duration in months for redemption (must be greater than 0).
The API response will include the gross and net yield of the investment in JSON format:]

{
  "grossResult": 1104.71,
  "netResult": 1049.77
}

Remember to adjust security and production settings before deploying the API to a production environment.

API Documentation
API documentation is available using Swagger. You can access it by navigating to https://localhost:5001/swagger (or http://localhost:5000/swagger) in your browser

Additional Notes
The CORS policy has been configured to allow all origins (*). In a production environment, adjust this configuration as needed to enhance security.
Be sure to handle errors appropriately in your application, especially the exceptions defined in the code, such as InvestmentCalculatorException.
You are now ready to run the CDB Calculation API solution in a local environment.
