using FluentValidation;
using TaksList.Models.Requests;

namespace TaksList.Validations.RequestValidators
{
    public class ChangeRecurringTaskStatusRequestValidator : AbstractValidator<ChangeRecurringTaskStatusRequest>
    {
        public ChangeRecurringTaskStatusRequestValidator() 
        {
         RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Status inválido. Use 'Active', 'Canceled' ou 'Paused'.");
            
        }
    }
}
