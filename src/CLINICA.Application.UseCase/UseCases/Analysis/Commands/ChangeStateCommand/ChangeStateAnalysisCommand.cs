using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalysisCommand :IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set;}
        public int State { get; set; }
    }
}
