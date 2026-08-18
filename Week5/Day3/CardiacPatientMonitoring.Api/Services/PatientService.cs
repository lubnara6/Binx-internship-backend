using CardiacPatientMonitoring.Api.Models;
using CardiacPatientMonitoring.Api.Repositories;

namespace CardiacPatientMonitoring.Api.Services;

public class PatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Patient?> GetPatientAsync(int id)
    {
        return await _patientRepository.GetByIdAsync(id);
    }

    public bool IsHeartRateNormal(int heartRate)
    {
        return heartRate >= 60 && heartRate <= 100;
    }
}