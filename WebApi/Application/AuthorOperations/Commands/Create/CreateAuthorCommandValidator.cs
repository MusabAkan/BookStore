using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.Create
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(40);
            RuleFor(command => command.Model.SurName).NotEmpty().NotEmpty().MinimumLength(3).MaximumLength(40);
            RuleFor(command => command.Model.BirthDate).NotNull();
        }
    }
}
