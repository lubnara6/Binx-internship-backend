using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using CardiacPatientMonitoring.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CardiacPatientMonitoring.Tests;

public class PatientApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PatientApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetPatient_ReturnsNotFound_WhenPatientDoesNotExist()
    {
        var response = await _client.GetAsync("/api/Patients/99999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetPatient_ReturnsPatient_WhenPatientExists()
    {
        var response = await _client.GetAsync("/api/Patients/1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var patient = await response.Content.ReadFromJsonAsync<Patient>();

        Assert.NotNull(patient);
        Assert.Equal(1, patient.Id);
        Assert.Equal("Ahmad Ali", patient.FullName);
        Assert.Equal(55, patient.Age);
        Assert.Equal("Male", patient.Gender);
    }

    [Fact]
    public async Task GetProtectedPatientData_ReturnsUnauthorized_WithoutToken()
    {
        // Act
        var response = await _client.GetAsync("/api/Patients/protected");

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
    private string GenerateTestJwt()
{
    var claims = new[]
    {
        new Claim(ClaimTypes.Name, "test-user")
    };

    var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes("ThisIsMySuperSecretKey1234567890"));

    var credentials = new SigningCredentials(
        key,
        SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        claims: claims,
        expires: DateTime.UtcNow.AddHours(1),
        signingCredentials: credentials);

    return new JwtSecurityTokenHandler().WriteToken(token);
}
[Fact]
public async Task GetProtectedPatientData_ReturnsOk_WithValidToken()
{
    // Arrange
    var token = GenerateTestJwt();

    _client.DefaultRequestHeaders.Authorization =
        new System.Net.Http.Headers.AuthenticationHeaderValue(
            "Bearer",
            token);

    // Act
    var response = await _client.GetAsync("/api/Patients/protected");

    // Assert
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
}
}