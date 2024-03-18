using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Examen.Command.ChangeStateCommand
{
    public class ChangeStateExamenCommand :IRequest<BaseResponse<bool>>
    {
        public int ExamId { get; set; }
        public int State { get; set; }
    }
}
