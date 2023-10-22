using Microsoft.EntityFrameworkCore;
using MegaverseApi.Data;
using MegaverseApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactNative", builder =>
    {
        builder
            .WithOrigins("http://localhost:8081", "http://192.168.1.24:8081")
            //.WithOrigins("http://192.168.1.24:8081")
            //.WithOrigins("http://localhost:8081")
            //.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connectionString));



var app = builder.Build();
app.UseCors("AllowReactNative");
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

