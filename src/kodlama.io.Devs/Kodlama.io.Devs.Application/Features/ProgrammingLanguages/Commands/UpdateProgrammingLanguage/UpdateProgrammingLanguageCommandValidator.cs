using System;
using FluentValidation;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
	public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
	{
		public UpdateProgrammingLanguageCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();

			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Name).MinimumLength(1);
		}
	}
}

