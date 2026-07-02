using FluentValidation;
using TaksList.Models.Requests;

namespace TaksList.Validations.RequestValidations
{
    public class CreateRecurringTaskRequestValidator : AbstractValidator<RecurringTaskRequest>
    {
        public CreateRecurringTaskRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(50).WithMessage("O título não pode exceder 50 caracteres.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres");
            RuleFor(x => x.Days)
                .NotEmpty().WithMessage("O campo 'Days' é obrigatório.");
            RuleFor(x => x.Schedule)
                .Must(h => h == null || TimeSpan.TryParse(h, out _))
                .WithMessage("Horário inválido. Use o formato HH:mm ou (ex: 08:30 ou 15:00:00).");

        }
    }
}
