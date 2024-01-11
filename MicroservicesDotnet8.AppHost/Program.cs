
using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var redisCache = builder.AddRedisContainer("RedisCache");

var rabbit = builder.AddRabbitMQContainer("RabbitMQ");
var mongo = builder.AddMongoDBContainer("MongoDB");
var sqlServer = builder.AddSqlServerContainer("SqlServer", "Nxprnzk9912", 1589)
    .AddDatabase("Catalog").WithServiceBinding(9912);

builder.AddProject<Projects.BasketApi>("basketapi")
    .WithReference(redisCache)
    .WithReference(rabbit);

builder.AddProject<Projects.MyCatalog>("mycatalog")
    .WithReference(sqlServer)
    .WithReference(mongo);

builder.Build().Run();
