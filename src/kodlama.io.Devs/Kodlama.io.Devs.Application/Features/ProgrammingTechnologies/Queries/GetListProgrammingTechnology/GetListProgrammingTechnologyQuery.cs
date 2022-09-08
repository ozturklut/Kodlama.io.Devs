using System;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnology
{
    public class GetListProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingTechnologyQueryHandler : IRequestHandler<GetListProgrammingTechnologyQuery, ProgrammingTechnologyListModel>
        {
            private readonly IProgrammingTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingTechnologyQueryHandler(IProgrammingTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingTechnologyListModel> Handle(GetListProgrammingTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingTechnology> programmingTechnologies = await _programmingLanguageTechnologyRepository.GetListAsync(include:
                                                                                                                                         m => m.Include(c => c.ProgrammingLanguage),
                                                                                                                                         index: request.PageRequest.Page,
                                                                                                                                         size: request.PageRequest.PageSize
                                                                                                                                         );
                ProgrammingTechnologyListModel programmingTechnologyListModel = _mapper.Map<ProgrammingTechnologyListModel>(programmingTechnologies);
                return programmingTechnologyListModel;
            }
        }
    }
}

