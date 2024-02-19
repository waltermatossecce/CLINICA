using CLINICA.Application.Dtos.Analysis.Response;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Query.GetAllQuery
{
    public class GetAllAnalysisQuery:IRequest<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {

    }
}
