using CDBCalculationApi.Interfaces;
using CDBCalculationApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Cálculo do CDB",
        Version = "v1",
        Description = "Esta API permite calcular o rendimento bruto e líquido de um investimento em CDB com base em parâmetros fornecidos. " +
                      "Os valores de entrada são:\n" +
                      "- 'initialValue': O valor inicial do investimento em reais (deve ser um valor positivo).\n" +
                      "- 'months': O prazo em meses para resgate do investimento (deve ser maior que 1).",
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

