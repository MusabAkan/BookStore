using FluentValidation;
using WebApi.Application.AuthorOperations.Commands.Delete;
using WebApi.Application.AuthorOperations.Commands.Update;

namespace WebApi.Application.AuthorOperations.Commands.Create
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(40);
            RuleFor(command => command.Model.SurName).NotEmpty().NotEmpty().MinimumLength(3).MaximumLength(40);
            RuleFor(command => command.Model.BirthDate).NotNull();
        }
    }
}
