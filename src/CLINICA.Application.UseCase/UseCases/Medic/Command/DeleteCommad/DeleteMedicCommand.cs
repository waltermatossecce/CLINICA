using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Medic.Command.DeleteCommad
{
    public class DeleteMedicCommand : IRequest<BaseResponse<bool>>
    {
        public int MedicId { get; set; }
    }
}
