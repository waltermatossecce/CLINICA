using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Examen.Command.DeleteCommand
{
    public class DeleteExamenCommand :IRequest<BaseResponse<bool>>
    {
        public int ExamId { get; set; }
    }
}
