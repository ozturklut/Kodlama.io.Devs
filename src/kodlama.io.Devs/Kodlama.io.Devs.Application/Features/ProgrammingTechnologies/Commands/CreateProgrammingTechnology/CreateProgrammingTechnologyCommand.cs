using System;
using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommand : IRequest<CreateProgrammingTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }

        public string Name { get; set; } = string.Empty;

        public class CreateProgrammingTechnologyCommandHandler : IRequestHandler<CreateProgrammingTechnologyCommand, CreateProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;
            public CreateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<CreateProgrammingTechnologyDto> Handle(CreateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _programmingTechnologyBusinessRules.ProgrammingTechnologyNameCanNotBeDuplicateWhenInserted(request.Name);
                await _programmingTechnologyBusinessRules.ProgrammingLanguageExistWhenInserted(request.ProgrammingLanguageId);

                ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology createdProgrammingTechnology = await _programmingTechnologyRepository.AddAsync(mappedProgrammingTechnology);

                CreateProgrammingTechnologyDto createProgrammingTechnologyDto = _mapper.Map<CreateProgrammingTechnologyDto>(createdProgrammingTechnology);

                return createProgrammingTechnologyDto;
            }
        }
    }
}

