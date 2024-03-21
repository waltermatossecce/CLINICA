using CLINICA.Application.Dtos.Patients.Response;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Pacientes.Query.GetAllQuery
{
    public class GetAllPatientQuery : IRequest<BaseResponse<IEnumerable<GetAllPatientResponseDto>>>
    {
    }
}
