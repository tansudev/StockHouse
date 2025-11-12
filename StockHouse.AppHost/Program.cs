
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

// Configuration'dan connection string'lerini direkt oku
var stockDb = builder.AddConnectionString("ConnectionString");
var redis = builder.AddConnectionString("Redis");

// Backend API Service - Aspire managed project with service references
var api = builder.AddProject<StockInventoryService>("stockinventory-api")
    .WithReference(stockDb)
    .WithReference(redis);

// React Frontend - Path'i configuration'dan al
var reactProjectPath = builder.Configuration["ReactProjectPath"] ?? @"..\..\StockHouseUIApp";
var frontend = builder.AddExecutable("stockhouse-frontend", "npm", reactProjectPath, "run", "dev")
    .WithReference(api)
    .WithEnvironment("REACT_APP_API_URL", api.GetEndpoint("http"))
    .WithEnvironment("VITE_API_URL", api.GetEndpoint("http"))
    .WithEnvironment("PORT", "3000");


var app = builder.Build();

app.Run();
