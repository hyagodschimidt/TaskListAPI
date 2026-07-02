using FluentValidation;
using TaksList.Models.Requests;

namespace TaksList.Validations.RequestValidations
{
    public class CreateScheduledTaskRequestValidator : AbstractValidator<ScheduledTaskRequest>
    {
        public CreateScheduledTaskRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(50).WithMessage("O título não pode exceder 50 caracteres.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres");
            RuleFor(x => x.DueDate).NotNull().WithMessage("O campo 'data de vencimento' é obrigatório.")
                .GreaterThan(DateTime.UtcNow).WithMessage("A data de vencimento deve ser uma data futura.");
        }
    }
}
