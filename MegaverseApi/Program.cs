using Microsoft.EntityFrameworkCore;
using MegaverseApi.Data;
using MegaverseApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connectionString));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


var poly = new Polyanet {
    Column = DateTime.Now.Year - 100,
    Row = DateTime.Now.Year - 99,
};

app.MapGet("api/polyanets", async(AppDbContext context) =>
{
    context.Polyanets.Add(poly);
    await context.SaveChangesAsync();
    var polys = await context.Polyanets.ToListAsync();
    return Results.Ok(polys);
})
.WithName("GetPolyanets")
.WithOpenApi();

app.Run();

