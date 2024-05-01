using CLINICA.Application.Dtos.TakeExam.Response;
using CLINICA.Domain.Entities;

namespace CLINICA.Application.Interfaces.Interfaces
{
    public interface ITakeExamRepository : IGenericRepository<TakeExam>
    {
        Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExams(string storedProcedure, object parameters);
        //Busca el examen por su Id
        Task<TakeExam> GetTakeExamById(int takeExamId);
        //Detalle del examen
        Task<IEnumerable<TakeExamDetail>> GetTakeExamDetailByTakeExamId(int takeExamId);
        //guarda takeExam
        Task<TakeExam> RegisterTakeExam(TakeExam takeExam);
        //guarda TakeExamDetails
        Task RegisterTakeExamDetail(TakeExamDetail takeExamDetail);
        Task EditTakeExam(TakeExam takeExam);
        Task EditTakeExamDetails(TakeExamDetail takeExamDetail);
        Task<bool> ChangeStateTakeExam(TakeExam takeExam);
    }
}
