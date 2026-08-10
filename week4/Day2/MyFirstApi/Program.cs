using MyFirstApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MyFirstApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["Jwt:Key"]!
                )
            )
        };
    });
builder.Services.AddControllers();

builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton(TimeProvider.System);

builder.Services.AddIdentityCore<IdentityUser>()
    .AddSignInManager()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
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