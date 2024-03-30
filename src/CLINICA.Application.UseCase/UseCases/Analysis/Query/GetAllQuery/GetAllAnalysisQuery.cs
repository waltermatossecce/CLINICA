  using CLINICA.Application.Dtos.Analysis.Response;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Query.GetAllQuery
{
    public class GetAllAnalysisQuery:IRequest<BasePaginationResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
