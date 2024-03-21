using CLINICA.Application.Dtos.Patients.Response;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Pacientes.Query.GetByIdQuery
{
    public class GetPatientByIdQuery : IRequest<BaseResponse<GetPatientByIdResponseDto>>
    {
        public int PatientId { get; set; }
    }
}
