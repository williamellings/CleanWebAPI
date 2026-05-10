using AutoMapper;
using CleanWebAPI.Application.Common.Behaviors;
using CleanWebAPI.Application.Common.Mappings;
using CleanWebAPI.Domain.Interfaces;
using CleanWebAPI.Infrastructure;
using CleanWebAPI.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// --- Services and Dependency Injection ---

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(typeof(CleanWebAPI.Application.Products.Commands.CreateProductCommand).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Setting up OpenAPI/Swagger for testing the API
builder.Services.AddOpenApi();

//MediatR 
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CleanWebAPI.Application.Products.Commands.CreateProductCommand).Assembly));

// Fetch the connection string from appsettings.json and configure SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register repositories so they can be injected into handlers or controllers
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// MediatR and AutoMapper registrations

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

var app = builder.Build();

// Middleware and Request Pipeline

// Enable the UI for testing endpoints in development mode
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// UseAuthorization is required for the [Authorize] attributes to work later
app.UseAuthorization();

// MapControllers allows the API to find the controllers in the Controllers folder
app.MapControllers();

app.Run();