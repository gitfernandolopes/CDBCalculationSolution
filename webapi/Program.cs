using CDBCalculationApi.Interfaces;
using CDBCalculationApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CDB Calculation API",
        Version = "v1",
        Description = "This API allows you to calculate the gross and net yield of a CDB investment based on provided parameters. " +
                  "The input values include:\n" +
                  "- 'initialValue': The initial investment amount (must be a positive value).\n" +
                  "- 'months': The investment duration in months for redemption (must be greater than 1).",
    });
});
builder.Services.AddScoped<IInvestmentCalculator, CdiInvestmentCalculator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CDBCalculationApi.v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

