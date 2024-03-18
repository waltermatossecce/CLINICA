using FluentValidation;

namespace CLINICA.Application.UseCase.UseCases.Examen.Command.CreateCommand
{
    public class CreateExamenValidators :AbstractValidator<CreateExamenCommand>
    {
        public CreateExamenValidators()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo nombre no puede estar vacio");

                //RuleFor(x => x.AnalysisId)
                //    .NotNull().WithMessage("El campo AnalysisId no puede ser nulo")
                //    .NotEmpty().WithMessage("El campo AnalysisId no puede estar vacio");

        }


    }
}
