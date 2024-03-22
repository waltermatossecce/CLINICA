using CLINICA.Application.Dtos.Medic.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Domain.Entities;
using CLINICA.Persistencia.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.Persistencia.Repository
{
    public class MedicRepository : GenericRepository<Medic>, IMedicRepository
    {

        private readonly ApplicationDbContext _context;

        public MedicRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllMedicResponseDto>> GetMedicAllAsync(string storedProcedure)
        {
            var connection = _context.CreateConnection;

            var response = await connection.
                QueryAsync<GetAllMedicResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);

            return response;
        }
    }
}
