using Microsoft.EntityFrameworkCore;
using StockInventoryDomain.Abstractions;
using StockInventoryInfrastructure.Persistence;
using StockInventoryInfrastructure.Persistence.Repositories;
using StockInventoryService.Endpoints;
using StockInventoryApplication;
using MediatR;
using StockInventoryApplication.Behaviors;
using StockInventoryService.Extensions;
using StockInventoryApplication.Common;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddStockApplication();

// Aspire PostgreSQL - Aspire otomatik connection string inject eder
builder.AddNpgsqlDbContext<AppDbContext>("ConnectionString");
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<INow, SystemNow>();
builder.Services.AddScoped<ICurrentUser, HttpContextCurrentUser>();

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(EfCommitBehavior<,>));

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

var cs = builder.Configuration.GetConnectionString("ConnectionString");
Console.WriteLine("[DBG] Effective CS: " + cs?.Replace("stockhouse123", "*****"));



builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentCors", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS middleware'ini endpoints'den önce ekle
app.UseCors("DevelopmentCors");

// Health Check endpoints
app.MapHealthChecks("/health");
app.MapHealthChecks("/health/ready", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("ready")
});

app.MapInventoryEndpoints();
app.MapCategoryEndpoints();
app.MapProductEndpoints();

app.Run();
