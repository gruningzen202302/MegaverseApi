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

app.MapGet("api/polyanets", async(AppDbContext context) =>
{
    var polys = await context.Polyanets.ToListAsync();
    return Results.Ok(polys);
})
.WithName("GetPolyanets")
.WithOpenApi();

app.MapPost("api/polyanets", async (AppDbContext context, Polyanet polyanet) =>
{
    await context.Polyanets.AddAsync(polyanet);
    await context.SaveChangesAsync();
    return Results.Created($"api/polyanets/{polyanet.Id}", polyanet);
})
.WithName("PostPolyanets")
.WithOpenApi();

app.MapDelete("api/polyanets/{id}", async (int id, AppDbContext context) =>
{
    var existingPolyanet = await context.Polyanets.FindAsync(id);

    if (existingPolyanet == null)
    {
        return Results.NotFound();
    }

    context.Polyanets.Remove(existingPolyanet);
    await context.SaveChangesAsync();

    return Results.Ok(existingPolyanet);
})
.WithName("DeletePolyanets")
.WithOpenApi();


app.Run();

