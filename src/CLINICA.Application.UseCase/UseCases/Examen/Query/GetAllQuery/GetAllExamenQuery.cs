using CLINICA.Application.Dtos.Examen.Response;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Examen.Query.GetAllQuery
{
    public class GetAllExamenQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllExamenResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
