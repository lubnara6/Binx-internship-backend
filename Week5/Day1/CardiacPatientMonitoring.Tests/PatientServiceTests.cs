using CardiacPatientMonitoring.Api.Services;

namespace CardiacPatientMonitoring.Tests;

public class PatientServiceTests
{
    [Fact]
    public void IsHeartRateNormal_ReturnsTrue_WhenHeartRateIsNormal()
    {
        // Arrange
        var service = new PatientService();

        // Act
        var result = service.IsHeartRateNormal(80);

        // Assert
        Assert.True(result);
    }
    [Fact]
public void IsHeartRateNormal_ReturnsFalse_WhenHeartRateIsTooHigh()
{
    // Arrange
    var service = new PatientService();

    // Act
    var result = service.IsHeartRateNormal(120);

    // Assert
    Assert.False(result);
}
[Fact]
public void IsHeartRateNormal_ReturnsFalse_WhenHeartRateIsTooLow()
{
    // Arrange
    var service = new PatientService();

    // Act
    var result = service.IsHeartRateNormal(40);

    // Assert
    Assert.False(result);
}
[Theory]
[InlineData(60, true)]
[InlineData(80, true)]
[InlineData(120, false)]
public void IsHeartRateNormal_ReturnsExpectedResult(int heartRate, bool expected)
{
    // Arrange
    var service = new PatientService();

    // Act
    var result = service.IsHeartRateNormal(heartRate);

    // Assert
    Assert.Equal(expected, result);
}
}