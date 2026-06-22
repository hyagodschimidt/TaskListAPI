using FluentValidation;
using TaksList.Models.Requests;

namespace TaksList.Validations.RequestValidations
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve conter pelo menos 3 caracteres.");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Número de telefone é obrigatório.")
                .Length(11).WithMessage("Coloque somente os números sem espaços ou parenteses (EX: 11999999999).")
                .Must(p => p.All(char.IsDigit)).WithMessage("Telefone deve conter apenas números.");
        }
    }
}
