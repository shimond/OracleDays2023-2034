using BasketApi.Model;
using BasketApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BasketRepository>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.AddRedisDistributedCache("RedisCache");

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("addBasket/{userId}", async (BasketRepository service, string userId, BasketItem item) => {

    await service.SetItem(userId, item);
    return Results.Created($"/addBasket/{userId}", item);

});

app.MapGet("getBasket/{userId}", async (BasketRepository service, string userId) =>
{
    var item = await service.GetItem(userId);
    if (item is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(item);

});

app.Run();

