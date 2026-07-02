using FluentValidation.Results;

namespace TaksList.Exceptions
{
    public class ValidationException : Exception
    {
        public List<ValidationFailure> Errors { get; set; }

        public ValidationException(List<ValidationFailure> errors)
            : base("Um ou mais erros de validação ocorreram")
        {
            Errors = errors;
        }
    }
}
