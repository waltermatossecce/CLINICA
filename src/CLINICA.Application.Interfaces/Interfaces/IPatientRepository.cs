using CLINICA.Application.Dtos.Patients.Response;
using CLINICA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.Application.Interfaces.Interfaces
{
    public interface IPatientRepository :IGenericRepository<Patient>
    {
        Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatient(string storedProcedure);

    }
}
