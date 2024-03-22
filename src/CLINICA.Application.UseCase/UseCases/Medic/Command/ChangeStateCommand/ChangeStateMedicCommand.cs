using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Medic.Command.ChangeStateCommand
{
    public class ChangeStateMedicCommand : IRequest<BaseResponse<bool>>
    {
        public int MedicId { get; set; }
        public int State { get; set; }
    }
}
