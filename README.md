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

