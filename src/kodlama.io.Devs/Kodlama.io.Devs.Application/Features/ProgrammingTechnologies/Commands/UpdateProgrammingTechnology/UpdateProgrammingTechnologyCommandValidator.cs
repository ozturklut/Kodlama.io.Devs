using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommandValidator : AbstractValidator<UpdateProgrammingTechnologyCommand>
    {
        public UpdateProgrammingTechnologyCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ProgrammingLanguageId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
