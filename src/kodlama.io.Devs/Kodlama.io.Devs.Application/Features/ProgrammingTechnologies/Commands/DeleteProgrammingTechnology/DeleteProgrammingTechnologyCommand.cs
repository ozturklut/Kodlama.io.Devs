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

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology
{
    public class DeleteProgrammingTechnologyCommand : IRequest<DeletedProgrammingTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingTechnologyCommandHandler : IRequestHandler<DeleteProgrammingTechnologyCommand, DeletedProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public DeleteProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<DeletedProgrammingTechnologyDto> Handle(DeleteProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                _programmingTechnologyBusinessRules.ProgrammingTechnologyIdExist(request.Id);

                ProgrammingTechnology? programmingTechnology = await _programmingTechnologyRepository.GetAsync(x => x.Id == request.Id);

                ProgrammingTechnology deletedProgrammingTechnology = await _programmingTechnologyRepository.DeleteAsync(programmingTechnology);
                DeletedProgrammingTechnologyDto deleteProgrammingTechnologyDto = _mapper.Map<DeletedProgrammingTechnologyDto>(deletedProgrammingTechnology);

                return (deleteProgrammingTechnologyDto);
            }
        }
    }
}
