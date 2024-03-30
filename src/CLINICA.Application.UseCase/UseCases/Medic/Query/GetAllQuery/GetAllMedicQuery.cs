using CLINICA.Application.Dtos.Medic.Response;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Medic.Query.GetAllQuery
{
    public class GetAllMedicQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
