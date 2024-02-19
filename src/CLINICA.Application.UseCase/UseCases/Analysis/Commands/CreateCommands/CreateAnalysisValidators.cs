using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.Application.UseCase.UseCases.Analysis.Commands.CreateCommands
{
    public class CreateAnalysisValidators : AbstractValidator<CreateAnalysisCommand>
    {
        public CreateAnalysisValidators()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo nombre no puede ser vacio");
        }

    }
}
