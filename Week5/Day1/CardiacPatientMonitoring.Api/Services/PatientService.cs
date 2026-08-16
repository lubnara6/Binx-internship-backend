namespace CardiacPatientMonitoring.Api.Services;

public class Patients
{
    public bool IsValidAge(int age)
    {
        return age >= 0 && age <= 120;
    }
}