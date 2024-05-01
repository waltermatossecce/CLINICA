using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.TakeExam.Commands.ChangeStateCommand
{
    public  class ChangeStateTakeExamCommand : IRequest<BaseResponse<bool>>
    {
        public int TakeExamId { get; set; }
        public int State { get; set; }
    }
}
