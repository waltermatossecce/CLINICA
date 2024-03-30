using CLINICA.Application.Dtos.Patients.Response;
using CLINICA.Domain.Entities;

namespace CLINICA.Application.Interfaces.Interfaces
{
    public interface IPatientRepository :IGenericRepository<Patient>
    {
        Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatient(string storedProcedure);

    }
}
