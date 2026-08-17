using CardiacPatientMonitoring.Api.Models;

namespace CardiacPatientMonitoring.Api.Repositories;

public class PatientRepository : IPatientRepository
{
    public Task<Patient?> GetByIdAsync(int id)
    {
        var patient = new Patient
        {
            Id = id,
            FullName = "Ahmad Ali",
            Age = 55,
            Gender = "Male"
        };

        return Task.FromResult<Patient?>(patient);
    }
}