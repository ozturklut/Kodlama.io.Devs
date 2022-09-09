using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology
{
    public class DeleteProgrammingTechnologyCommandValidator : AbstractValidator<DeleteProgrammingTechnologyCommand>
    {
        public DeleteProgrammingTechnologyCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
