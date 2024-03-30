using CLINICA.Application.Dtos.Medic.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Domain.Entities;
using CLINICA.Persistencia.Context;
using Dapper;
using System.Data;

namespace CLINICA.Persistencia.Repository
{
    public class MedicRepository : GenericRepository<Medic>, IMedicRepository
    {

        private readonly ApplicationDbContext _context;

        public MedicRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllMedicResponseDto>> GetMedicAllAsync(string storedProcedure, object parameters)
        {
            var connection = _context.CreateConnection;

            var objParam = new DynamicParameters(parameters);
            var response = await connection.
                QueryAsync<GetAllMedicResponseDto>(storedProcedure, param:objParam,commandType: CommandType.StoredProcedure);

            return response;
        }
    }
}
