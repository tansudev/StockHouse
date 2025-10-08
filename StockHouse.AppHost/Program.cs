var builder = DistributedApplication.CreateBuilder(args);

var pg = builder.AddConnectionString("ConnectionString");
builder.AddProject<Projects.StockInventoryService>("StockInventoryService")
       .WithReference(pg);

builder.Build().Run();
