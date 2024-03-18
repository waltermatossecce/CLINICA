using CLINICA.Application.Dtos.Examen.Response;
using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Examen.Query.GetByIdQuery
{
    public class GetExamenByIdQuery :IRequest<BaseResponse<GetExamenByIdResponseDto>>
    {
        public int ExamId { get; set; }
    }
}
