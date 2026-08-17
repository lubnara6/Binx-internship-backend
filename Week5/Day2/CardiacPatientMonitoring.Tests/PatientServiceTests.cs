using CardiacPatientMonitoring.Api.Models;
using CardiacPatientMonitoring.Api.Repositories;
using CardiacPatientMonitoring.Api.Services;
using Moq;

namespace CardiacPatientMonitoring.Tests;

public class PatientServiceTests
{
    [Fact]
    public void IsHeartRateNormal_ReturnsTrue_WhenHeartRateIsNormal()
    {
        // Arrange
        var mockRepository = new Mock<IPatientRepository>();
        var service = new PatientService(mockRepository.Object);

        // Act
        var result = service.IsHeartRateNormal(80);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsHeartRateNormal_ReturnsFalse_WhenHeartRateIsTooHigh()
    {
        // Arrange
        var mockRepository = new Mock<IPatientRepository>();
        var service = new PatientService(mockRepository.Object);

        // Act
        var result = service.IsHeartRateNormal(120);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsHeartRateNormal_ReturnsFalse_WhenHeartRateIsTooLow()
    {
        // Arrange
        var mockRepository = new Mock<IPatientRepository>();
        var service = new PatientService(mockRepository.Object);

        // Act
        var result = service.IsHeartRateNormal(40);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task GetPatientAsync_ReturnsPatient_WhenPatientExists()
    {
        // Arrange
        var patient = new Patient
        {
            Id = 1,
            FullName = "Ahmad"
        };

        var mockRepository = new Mock<IPatientRepository>();

        mockRepository
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(patient);

        var service = new PatientService(mockRepository.Object);

        // Act
        var result = await service.GetPatientAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
        Assert.Equal("Ahmad", result.FullName);
    }

    [Fact]
    public async Task GetPatientAsync_ReturnsNull_WhenPatientDoesNotExist()
    {
        // Arrange
        var mockRepository = new Mock<IPatientRepository>();

        mockRepository
            .Setup(r => r.GetByIdAsync(999))
            .ReturnsAsync((Patient?)null);

        var service = new PatientService(mockRepository.Object);

        // Act
        var result = await service.GetPatientAsync(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetPatientAsync_ThrowsException_WhenRepositoryFails()
    {
        // Arrange
        var mockRepository = new Mock<IPatientRepository>();

        mockRepository
            .Setup(r => r.GetByIdAsync(1))
            .ThrowsAsync(new Exception("Database error"));

        var service = new PatientService(mockRepository.Object);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(
            () => service.GetPatientAsync(1)
        );
    }

    [Fact]
    public async Task GetPatientAsync_CallsRepositoryExactlyOnce()
    {
        // Arrange
        var mockRepository = new Mock<IPatientRepository>();

        mockRepository
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new Patient
            {
                Id = 1,
                FullName = "Ahmad"
            });

        var service = new PatientService(mockRepository.Object);

        // Act
        await service.GetPatientAsync(1);

        // Assert
        mockRepository.Verify(
            r => r.GetByIdAsync(1),
            Times.Once
        );
    }
}