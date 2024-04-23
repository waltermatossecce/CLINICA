using CLINICA.Application.Dtos.TakeExam.Response;
using CLINICA.Application.Interfaces.Interfaces;
using CLINICA.Domain.Entities;
using CLINICA.Persistencia.Context;
using Dapper;
using System.Data;
using Entidad = CLINICA.Domain.Entities;
namespace CLINICA.Persistencia.Repository
{
    public class TakeExamRepository : GenericRepository<TakeExam>, ITakeExamRepository
    {

        private readonly ApplicationDbContext _context;

        public TakeExamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExams(string storedProcedure, object parameters)
        {
            using var connection = _context.CreateConnection;

            var objParam = new DynamicParameters(parameters);
            
            var takeExams= await connection.
                QueryAsync<GetAllTakeExamResponseDto>(storedProcedure, param:objParam,commandType: CommandType.StoredProcedure);

            return takeExams;
        }

        public async Task<TakeExam> GetTakeExamById(int takeExamId)
        {
            var connection = _context.CreateConnection;

            var sql = @"SELECT TakeExamId, PatientId, MedicId  FROM TakeExam Where TakeExamId = @TakeExamId";
            
            var parameters = new DynamicParameters();
            
            parameters.Add("TakeExamId", takeExamId);

            var TakeExam = await connection.QuerySingleOrDefaultAsync<TakeExam>(sql, param: parameters);

            return TakeExam;
        }

        public async Task<IEnumerable<TakeExamDetail>> GetTakeExamDetailByTakeExamId(int takeExamId)
        {
            var connection = _context.CreateConnection;

            var sql = "SELECT TakeExamDetailId, TakeExamId, ExamId, AnalysisId  FROM TakeExamDetail Where TakeExamId = @TakeExamId";

            var parameters = new DynamicParameters();

            parameters.Add("TakeExamId", takeExamId);

            var TakeExamDetail = await connection.QueryAsync<TakeExamDetail>(sql, param: parameters);

            return TakeExamDetail;


        }

        public async Task<TakeExam> RegisterTakeExam(TakeExam takeExam)
        {
            var connection = _context.CreateConnection;

            var query = @"INSERT INTO TakeExam(PatientId, MedicId, State, AuditCreateDate)
                        VALUES (@PatientId, @MedicId, @State, @AuditCreateDate)
                        SELECT CAST(SCOPE_IDENTITY() AS INT)";

            var parameters = new DynamicParameters();
            parameters.Add("PatientId", takeExam.PatientId);
            parameters.Add("MedicId", takeExam.MedicId);
            parameters.Add("State", 1);
            parameters.Add("AuditCreateDate", DateTime.Now);

            var takeExamId = await connection.QuerySingleOrDefaultAsync<int>(query, param: parameters);
            takeExam.TakeExamId = takeExamId;

            return takeExam;
        }

        public async Task RegisterTakeExamDetail(TakeExamDetail takeExamDetail)
        {
            var connection = _context.CreateConnection;

            var sql = @"INSERT INTO TakeExamDetail(TakeExamId, ExamId, AnalysisId)
                        VALUES (@TakeExamId, @ExamId, @AnalysisId);";

            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId",takeExamDetail.TakeExamId);
            parameters.Add("ExamId",takeExamDetail.ExamId);
            parameters.Add("AnalysisId", takeExamDetail.AnalysisId);

            await connection.ExecuteAsync(sql, param: parameters);


        }
    }
}
