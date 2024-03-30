using CLINICA.Application.Dtos.Examen.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Domain.Entities;
using CLINICA.Persistencia.Context;
using Dapper;
using System.Data;

namespace CLINICA.Persistencia.Repository
{
    public class ExamRepository : GenericRepository<Examen>, IExamenRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllExamenResponseDto>> GetAllExams(string storedProcedure, object parameters)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameters);
            var examen = await connection.QueryAsync<GetAllExamenResponseDto>(storedProcedure,param: objParam, commandType: CommandType.StoredProcedure);
            return examen;
        }

    }
}
