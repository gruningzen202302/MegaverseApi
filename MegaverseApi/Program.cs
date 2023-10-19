using Microsoft.EntityFrameworkCore;
using MegaverseApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connectionString));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/weatherforecast", () =>
{
    var forecast = new[] { "hello", "world" };
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

