using CoacehlTraining.Core.DTO;
using FluentValidation;

namespace CoacehlTraining.Core.Validators
{
    public class PersonValidator : AbstractValidator<PersonInfo>
    {
        public PersonValidator(int step)
        {
            if (step == 1)
            {
                RuleFor(x => x.Identification)
                    .NotEmpty().WithMessage("El campo de Identification esta vacio")
                    .MinimumLength(13).WithMessage("El campo DNI requiere de al menos 13 caracteres");

                RuleFor(x => x.FirstName)
                    .NotEmpty().WithMessage("El campo FirstName esta vacio")
                    .MinimumLength(2).WithMessage("El campo FirstName requiere de al menos 2 caracteres");

                RuleFor(x => x.LastName)
                    .NotEmpty().WithMessage("El campo FirstName esta vacio")
                    .MinimumLength(2).WithMessage("El campo FirstName requiere de al menos 2 caracteres");
            }
            else
            {
                RuleFor(x => x.FirstName)
                    .NotEmpty().WithMessage("El campo FirstName esta vacio")
                    .MinimumLength(2).WithMessage("El campo FirstName requiere de al menos 2 caracteres");

                RuleFor(x => x.LastName)
                    .NotEmpty().WithMessage("El campo FirstName esta vacio")
                    .MinimumLength(2).WithMessage("El campo FirstName requiere de al menos 2 caracteres");
            }
        }
    }
}
