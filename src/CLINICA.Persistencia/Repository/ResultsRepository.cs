using CLINICA.Application.Dtos.Results.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Domain.Entities;
using CLINICA.Persistencia.Context;
using Dapper;
using System.Data;

namespace CLINICA.Persistencia.Repository
{
    public class ResultsRepository : GenericRepository<Results>, IResultsRepository
    {

        private readonly ApplicationDbContext _context;

        public ResultsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllResultsResponseDto>> GetAllResults(string storedProcedure, object parameters)
        {
            var connection = _context.CreateConnection;

            var objParam = new DynamicParameters(parameters);
            var results = await connection.QueryAsync<GetAllResultsResponseDto>
                (storedProcedure, param:objParam, commandType:CommandType.StoredProcedure);
                          
            return results;
        }

       
    }
}
