using CardiacPatientMonitoring.Api.Models;

namespace CardiacPatientMonitoring.Api.Repositories;

public interface IPatientRepository
{
    Task<Patient?> GetByIdAsync(int id);
}