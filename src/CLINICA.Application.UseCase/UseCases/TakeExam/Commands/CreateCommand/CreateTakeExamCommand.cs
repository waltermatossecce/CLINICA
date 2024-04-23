using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand
{
    public  class CreateTakeExamCommand : IRequest<BaseResponse<bool>>
    {
        public int PatienId { get; set; }
        public int MedicId { get; set; }
        public IEnumerable<CreateTakeExamDetailResponseDto>? takeExamDetails { get; set; }
    }
    public class CreateTakeExamDetailResponseDto
    {
        public int ExamId { get; set; }
        public int AnalysisId { get; set; }
    }
}
