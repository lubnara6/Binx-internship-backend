using MyFirstApi.Services;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

    await next();
});
app.MapControllers();
app.MapGet("/products", () =>
{
    var products = new List<string>
    {
        "Laptop",
        "Mouse",
        "Keyboard"
    };

    return products;
});
app.MapGet("/products/{id}", (int id) =>
{
    var products = new List<string>
    {
        "Laptop",
        "Mouse",
        "Keyboard"
    };

    if (id < 1 || id > products.Count)
    {
        return Results.NotFound();
    }

    return Results.Ok(products[id - 1]);
});
app.Run();