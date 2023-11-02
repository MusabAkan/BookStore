using FluentValidation;
using WebApi.Application.BookOperations.Commands.Delete;

namespace WebApi.Application.BookOperations.Commands.Update;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(command => command.BookId).GreaterThan(0);
    }
}