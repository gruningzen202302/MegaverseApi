using Microsoft.EntityFrameworkCore;
using MegaverseApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("SqlitrConnection")));

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

