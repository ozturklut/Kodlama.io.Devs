using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommand : IRequest<UpdatedProgrammingTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; } = string.Empty;

        public class UpdateProgrammingTechnologyCommandHandler : IRequestHandler<UpdateProgrammingTechnologyCommand, UpdatedProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public UpdateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<UpdatedProgrammingTechnologyDto> Handle(UpdateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                _programmingTechnologyBusinessRules.ProgrammingTechnologyIdExist(request.Id);
                await _programmingTechnologyBusinessRules.ProgrammingLanguageExistWhenUpdated(request.ProgrammingLanguageId);

                ProgrammingTechnology? programmingTechnology = await _programmingTechnologyRepository.GetAsync(x => x.Id == request.Id);

                _mapper.Map(request, programmingTechnology);
                ProgrammingTechnology updatedProgrammingTechnology = await _programmingTechnologyRepository.UpdateAsync(programmingTechnology);
                UpdatedProgrammingTechnologyDto updateProgrammingTechnologyDto = _mapper.Map<UpdatedProgrammingTechnologyDto>(programmingTechnology);
                return updateProgrammingTechnologyDto;
            }
        }
    }
}
