using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand
{
    public  class CreateTakeExamCommand : IRequest<BaseResponse<bool>>
    {
        public int PatientId { get; set; }
        public int MedicId { get; set; }
        public IEnumerable<CreateTakeExamDetailCommand>? takeExamDetails { get; set; }
    }
    public class CreateTakeExamDetailCommand
    {
        public int ExamId { get; set; }
        public int AnalysisId { get; set; }
    }
}
