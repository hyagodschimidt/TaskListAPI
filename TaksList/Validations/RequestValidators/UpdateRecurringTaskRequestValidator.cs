using FluentValidation;
using TaksList.Enuns;
using TaksList.Models.Requests;

namespace TaksList.Validations.RequestValidators
{
    public class UpdateRecurringTaskRequestValidator : AbstractValidator<UpdateRecurringTaskRequest>
    {
        public UpdateRecurringTaskRequestValidator()
        {
            RuleFor(x => x.Days)
                .Must(Days => Days  == null || Days.Any())
                .WithMessage("Se informado, o campo 'Days' deve conter pelo menos um dia da semana.");
            RuleFor(x => x.Schedule)
                .Must(h => h == null || TimeSpan.TryParse(h, out _))
                .WithMessage("Horário inválido. Use o formato HH:mm ou (ex: 08:30 ou 15:00:00).");
        }
    }
}
