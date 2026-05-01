using CleanWebAPI.Domain.Interfaces;
using CleanWebAPI.Infrastructure;
using CleanWebAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- Services and Dependency Injection ---

builder.Services.AddControllers();

// Setting up OpenAPI/Swagger for testing the API
builder.Services.AddOpenApi();

// Fetch the connection string from appsettings.json and configure SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register repositories so they can be injected into handlers or controllers
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// MediatR and AutoMapper registrations

var app = builder.Build();

// Middleware and Request Pipeline

// Enable the UI for testing endpoints in development mode
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// UseAuthorization is required for the [Authorize] attributes to work later
app.UseAuthorization();

// MapControllers allows the API to find the controllers in the Controllers folder
app.MapControllers();

app.Run();