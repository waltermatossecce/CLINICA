using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Commands.CreateCommands
{
    public class CreateAnalysisCommand:IRequest<BaseResponse<bool>>
    {
       public string? Name { get; set; }
    }
}
