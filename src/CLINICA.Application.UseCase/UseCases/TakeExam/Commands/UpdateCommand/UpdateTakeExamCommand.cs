using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand
{
    public class UpdateTakeExamCommand : IRequest<BaseResponse<bool>>
    {
        public int TakeExamId { get; set; }
        public int PatientId { get; set; }
        public int MedicId { get; set; }

        public IEnumerable<UpdateTakeExamDetailsCommand>? takeExamDetails { get; set; }
    }

    public class UpdateTakeExamDetailsCommand
    {
        public int TakeExamDetailId { get; set; }
        public int ExamId { get; set; }
        public int AnalysisId { get; set; }
    }
}
