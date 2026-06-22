using FluentValidation;
using TaksList.Models.Requests;

namespace TaksList.Validations.RequestValidations
{
    public class TarefaAgendaRequestValidator : AbstractValidator<TarefaAgendaRequest>
    {
        public TarefaAgendaRequestValidator()
        {
            RuleFor(x => x.title)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(50).WithMessage("O título não pode exceder 50 caracteres.");
            RuleFor(x => x.description)
                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres");
            RuleFor(x => x.previsaoConclusao).NotNull().WithMessage("O campo 'previsão de conclusão' é obrigatório.")
                .GreaterThan(0).WithMessage("A previsão de conclusão deve ser um número positivo.");
        }
    }
}
