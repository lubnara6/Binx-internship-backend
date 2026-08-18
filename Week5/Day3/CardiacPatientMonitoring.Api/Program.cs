using CardiacPatientMonitoring.Api.Data;
using Microsoft.EntityFrameworkCore;
using CardiacPatientMonitoring.Api.Repositories;
using CardiacPatientMonitoring.Api.Services;
using CardiacPatientMonitoring.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("ThisIsMySuperSecretKey1234567890"))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddDbContext<PatientDbContext>(options =>
    options.UseInMemoryDatabase("PatientTestDb"));
// Services
builder.Services.AddControllers();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<PatientService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PatientDbContext>();

    db.Patients.Add(new Patient
    {
        Id = 1,
        FullName = "Ahmad Ali",
        Age = 55,
        Gender = "Male"
    });

    db.SaveChanges();
}

// HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();


public partial class Program
{
    
}