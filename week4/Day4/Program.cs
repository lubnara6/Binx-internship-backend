using MyFirstApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MyFirstApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// JWT Authentication
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
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireRole("Admin");
    });
});
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookRequestValidator>();

builder.Services.AddScoped<IItemService, ItemService>();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddSingleton(TimeProvider.System);

// Identity + Roles
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddSignInManager()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddEndpointsApiExplorer();

// Swagger + JWT
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(
        "Bearer",
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description = "Enter your JWT token"
        });

    options.AddSecurityRequirement(
        new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Reference =
                        new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                },
                Array.Empty<string>()
            }
        });
});

var app = builder.Build();

// Create Roles + Assign Users
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider
        .GetRequiredService<RoleManager<IdentityRole>>();

    // Create User role
    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(
            new IdentityRole("User")
        );
    }

    // Create Admin role
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(
            new IdentityRole("Admin")
        );
    }

    var userManager = scope.ServiceProvider
        .GetRequiredService<UserManager<IdentityUser>>();

    // Assign Admin role
 // Assign Admin role
var adminUser = await userManager.FindByEmailAsync(
    "validation@test.com"
);

if (adminUser != null &&
    !await userManager.IsInRoleAsync(adminUser, "Admin"))
{
    await userManager.AddToRoleAsync(
        adminUser,
        "Admin"
    );
}

    // Assign User role
    var normalUser = await userManager.FindByEmailAsync(
        "user@gmail.com"
    );

    if (normalUser != null &&
        !await userManager.IsInRoleAsync(normalUser, "User"))
    {
        await userManager.AddToRoleAsync(
            normalUser,
            "User"
        );
    }
}

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
    Console.WriteLine(
        $"Request: {context.Request.Method} {context.Request.Path}"
    );

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