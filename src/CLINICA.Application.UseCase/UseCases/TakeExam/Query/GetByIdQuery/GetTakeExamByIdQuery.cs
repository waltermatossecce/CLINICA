using CLINICA.Application.Dtos.TakeExam.Response;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.TakeExam.Query.GetByIdQuery
{
    public class GetTakeExamByIdQuery : IRequest<BaseResponse<GetTakeExamByIdResponseDto>>
    {
        public int TakeExamById { get; set; }
    }
}
