using FluentValidation;
using TaksList.Models.Requests;

namespace TaksList.Validations.RequestValidations
{
    public class TarefaDiariaRequestValidator : AbstractValidator<TarefaDiariaRequest>
    {
        public TarefaDiariaRequestValidator()
        {
            RuleFor(x => x.title)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(50).WithMessage("O título não pode exceder 50 caracteres.");
            RuleFor(x => x.description)
                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres");
            RuleFor(x => x.dias)
                .NotEmpty().WithMessage("O campo 'dias' é obrigatório.");
            RuleFor(x => x.horario)
                .Must(h => h == null || TimeSpan.TryParse(h, out _))
                .WithMessage("Horário inválido. Use o formato HH:mm ou (ex: 08:30 ou 15:00:00).");

        }
    }
}
