using FluentValidation;
using WebApi.Application.AuthorOperations.Commands.Delete;

namespace WebApi.Application.AuthorOperations.Commands.Create
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}
