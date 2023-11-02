using FluentValidation;
using WebApi.Application.GenreOperations.Commands.Delete;

namespace WebApi.Application.GenreOperations.Commands.Update
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
        }
    }
}