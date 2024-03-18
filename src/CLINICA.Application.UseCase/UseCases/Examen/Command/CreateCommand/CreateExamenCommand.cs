using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Examen.Command.CreateCommand
{
    public class CreateExamenCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
        public int AnalysisId { get; set; }
        
        
    }
}
