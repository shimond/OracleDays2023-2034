using MyCatalog.Apis;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

//builder.Configuration["dbConnection"];
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationDefaults();
builder.AddSqlServerDbContext<MainDbContext>("Catalog");

var app = builder.Build();

app.MapDefaultEndpoints();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<MainDbContext>();
dbContext.Database.EnsureCreated();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseOutputCache();
app.UseHttpsRedirection();
app.AddProductApis();

app.MapGet("/", () => Environment.OSVersion);

app.Run();





