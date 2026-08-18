namespace CardiacPatientMonitoring.Api.Models;

public class Patient
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Gender { get; set; } = string.Empty;
}