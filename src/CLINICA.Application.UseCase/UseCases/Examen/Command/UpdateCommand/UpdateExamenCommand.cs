using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Examen.Command.UpdateCommand
{
    public class UpdateExamenCommand :IRequest<BaseResponse<bool>>
    {
        public int ExamId { get; set; }
        public string? Name { get; set; }
        public int AnalysisId { get; set; }
    }
}
