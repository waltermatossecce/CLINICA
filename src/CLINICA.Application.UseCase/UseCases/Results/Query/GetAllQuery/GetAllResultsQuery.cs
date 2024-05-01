using CLINICA.Application.Dtos.Results.Response;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Results.Query.GetAllQuery
{
    public class GetAllResultsQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllResultsResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
