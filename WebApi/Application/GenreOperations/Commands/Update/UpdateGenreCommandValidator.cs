﻿using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.Update
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Id).GreaterThan(0);
            RuleFor(command => command.Model.IsActive).NotNull();
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3).MaximumLength(20);

        }
    }
}