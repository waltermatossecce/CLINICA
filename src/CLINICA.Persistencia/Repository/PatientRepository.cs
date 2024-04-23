using CLINICA.Application.Dtos.Patients.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Domain.Entities;
using CLINICA.Persistencia.Context;
using Dapper;
using System.Data;

namespace CLINICA.Persistencia.Repository
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatient(string storedProcedure)
        {
            var connection = _context.CreateConnection;

            var patient = await connection.QueryAsync<GetAllPatientResponseDto>
                (storedProcedure, commandType: CommandType.StoredProcedure);

            return patient;
        }


    }
}
