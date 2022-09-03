using System;
using FluentValidation;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
	public class DeleteProgrammingLanguageCommandValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
	{
		public DeleteProgrammingLanguageCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
		}
	}
}

