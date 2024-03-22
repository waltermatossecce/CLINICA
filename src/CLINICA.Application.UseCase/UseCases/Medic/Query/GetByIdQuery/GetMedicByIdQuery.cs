using CLINICA.Application.Dtos.Medic.Response;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Medic.Query.GetByIdQuery
{
    public class GetMedicByIdQuery : IRequest<BaseResponse<GetMedicByIdResponseDto>>
    {
        public int MedicId { get; set; }
    }
}
