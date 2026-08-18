using CardiacPatientMonitoring.Api.Data;
using CardiacPatientMonitoring.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CardiacPatientMonitoring.Api.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly PatientDbContext _context;

    public PatientRepository(PatientDbContext context)
    {
        _context = context;
    }

    public async Task<Patient?> GetByIdAsync(int id)
    {
        return await _context.Patients
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}