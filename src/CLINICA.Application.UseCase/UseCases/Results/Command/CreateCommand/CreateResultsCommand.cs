using CLINICA.Application.UseCase.Commons.Base;
using MediatR;

namespace CLINICA.Application.UseCase.UseCases.Results.Command.CreateCommand
{
    public class CreateResultsCommand : IRequest<BaseResponse<bool>>
    {
        public int TakeExamId { get; set; }
        public IEnumerable<CreateResultDetailCommand>? ResultDetails { get; set; }
    
    }
    public class CreateResultDetailCommand
    {
        public int MyProperty { get; set; }

        public int MyProperty1 { get; set; }


    }
}
