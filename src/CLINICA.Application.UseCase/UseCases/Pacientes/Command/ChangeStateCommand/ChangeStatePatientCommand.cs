using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Pacientes.Command.ChangeStateCommand
{
    public class ChangeStatePatientCommand : IRequest<BaseResponse<bool>>
    {
        public int PatientId { get; set; }
        public int State { get; set; }
    }
}
