using FluentValidation;

namespace CLINICA.Application.UseCase.UseCases.Pacientes.Command.CreateCommand
{
    public class CreatePatientValidators :AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidators()
        {
            RuleFor(x => x.Names)
                .NotNull().WithMessage("El campo Nombres no puede ser nulo")
                .NotEmpty().WithMessage("El campo Apellido no puede estar vacio");
        
            RuleFor(x => x.LastName)
                .NotNull().WithMessage("El campo Apellido Paterno no puede ser nulo")
                .NotEmpty().WithMessage("El campo Apellido Paterno no puede estar vacio");


            RuleFor(x => x.MotherMaidenName)
                 .NotNull().WithMessage("El campo Apellido Materno de la madre no puede ser nulo")
                 .NotEmpty().WithMessage("El campo Apellido Materno de la madre no puede estar vacio");

            RuleFor(x => x.DocumentNumber)
                .NotNull().WithMessage("El campo N° Documento no puede ser nulo")
                .NotEmpty().WithMessage("El campo N° Documento no puede estar vacio")
                .Must(BeNumeric).WithMessage("El campo de N° Documento debe contener solo numeros");

 
            RuleFor(x => x.Phono)
                .NotNull().WithMessage("El campo Teléfono no puede ser nulo")
                .NotEmpty().WithMessage("El campo Teléfono  no puede estar vacio")
                .Must(BeNumeric).WithMessage("El campo de Teléfono debe contener solo numeros");

        }
        private bool BeNumeric(string input)
        {
            return int.TryParse(input, out _);
        }
    }
}
