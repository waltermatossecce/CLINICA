using FluentValidation;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisValidators : AbstractValidator<UpdateAnalysisCommand>
    { 
        public UpdateAnalysisValidators()
        {
            RuleFor(x => x.AnalysisId)
                .NotNull().WithMessage("El campo AnalysisId no puede ser nulo")
                .NotEmpty().WithMessage("El campo AnalysisId  no puede estar vacio");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo nombre no puede ser vacio");
        }
    }
}
