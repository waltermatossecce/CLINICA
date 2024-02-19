using CLINICA.Application.Interfaces;
using CLINICA.Domain.Entities;
using CLINICA.Persistencia.Context;
using Dapper;
using System.Data;

namespace CLINICA.Persistencia.Repository
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly ApplicationDbContext _context;

        public AnalysisRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Analysis>> ListAnalysis()
        {
            //procedimiento almacenado de un listado
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisList";

            var analysis = await connection.QueryAsync<Analysis>(query, commandType: CommandType.StoredProcedure);

            return analysis;
        }
        public async Task<Analysis> AnalysisById(int AnalysisId)
        {
            //procedimiento almacenado buscando por el id
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisById";

            var parameters = new DynamicParameters();
            //parametros que yo requiero
            parameters.Add("AnalysisId", AnalysisId);

            var analysis = await 
            connection.QuerySingleOrDefaultAsync<Analysis>(query, param: parameters, commandType: CommandType.StoredProcedure);

            return analysis;

        }

        public async Task<bool> AnalysisRegister(Analysis analysis)
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisRegister";

            var parameters = new DynamicParameters();

            parameters.Add("Name", analysis.Name);
            parameters.Add("State", 1);
            parameters.Add("AudiCreateDate",DateTime.Now);

            var recordsaffected = await
            connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsaffected > 0;
        }

        public async Task<bool> AnalysisEdit(Analysis analysis)
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisEdit";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysis.AnalysisId);
            parameters.Add("Name", analysis.Name);

            var recordsAffected = await
            connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

            return recordsAffected > 0;
        }

        public async Task<bool> AnalysisDelete(int analysisId)
        {
            using var connection = _context.CreateConnection;

            var query = "uspAnalysisRemove";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysisId);

            var recorderAffected = await
                connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
        
            return recorderAffected > 0;
        }
    }
}
