using Microsoft.EntityFrameworkCore;
using StockInventoryDomain.Abstractions;
using StockInventoryInfrastructure.Persistence;
using StockInventoryInfrastructure.Persistence.Repositories;
using StockInventoryService.Endpoints;
using StockInventoryApplication;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStockApplication();

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));


if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("PostgreSQL connection string 'ConnectionString' not found.");

// DI registrations MUST be before Build()
builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(connectionString));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(EfCommitBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapInventoryEndpoints();
app.MapCategoryEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
