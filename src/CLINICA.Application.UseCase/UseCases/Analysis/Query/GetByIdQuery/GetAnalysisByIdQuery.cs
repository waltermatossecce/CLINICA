using CLINICA.Application.Dtos.Analysis.Response;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Query.GetByIdQuery
{
    public class GetAnalysisByIdQuery :IRequest<BaseResponse<GetAnalysisByIdResponseDto>>
    {
        public int AnalysisId { get; set; }

    }
}
