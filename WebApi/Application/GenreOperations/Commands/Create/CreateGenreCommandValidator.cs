using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.Create;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(command => command.Model.Id).GreaterThan(0);
        RuleFor(command => command.Model.IsActive).NotNull();
        RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3).MaximumLength(30);


    }
}