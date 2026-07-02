using FluentValidation.Results;

namespace TaksList.Exceptions
{
    public class RequestValidationException : Exception
    {
        public List<ValidationFailure> Errors { get; set; }

        public RequestValidationException(List<ValidationFailure> errors)
            : base("Um ou mais erros de validação ocorreram")
        {
            Errors = errors;
        }
    }
}
