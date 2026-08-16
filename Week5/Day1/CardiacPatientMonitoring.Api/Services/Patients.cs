namespace CardiacPatientMonitoring.Api.Services;

public class PatientService
{
    public bool IsHeartRateNormal(int heartRate)
    {
        return heartRate >= 60 && heartRate <= 100;
    }
}