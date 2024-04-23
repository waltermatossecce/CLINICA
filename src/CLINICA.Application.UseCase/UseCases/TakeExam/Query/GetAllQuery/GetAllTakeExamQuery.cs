using CLINICA.Application.Dtos.TakeExam.Response;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.TakeExam.Query.GetAllQuery
{
    public class GetAllTakeExamQuery :IRequest<BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
