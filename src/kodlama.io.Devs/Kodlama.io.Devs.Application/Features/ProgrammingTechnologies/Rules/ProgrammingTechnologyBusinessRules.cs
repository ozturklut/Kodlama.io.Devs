using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologyBusinessRules
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingTechnologyBusinessRules(IProgrammingTechnologyRepository programmingTechnologyRepository, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingTechnologyNameCanNotBeDuplicateWhenInserted(string name)
        {
            IPaginate<ProgrammingTechnology> result = await _programmingTechnologyRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming Technology name exists.");
        }

        public void ProgrammingTechnologyIdExist(int id)
        {
            ProgrammingTechnology programmingTechnology = _programmingTechnologyRepository.Get(x => x.Id == id);
            if (programmingTechnology == null) throw new BusinessException("Programming Technology does not exist");
        }

        public async Task ProgrammingLanguageExistWhenInserted(int ProgrammingLanguageId)
        {
            ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(b => b.Id == ProgrammingLanguageId);
            if (programmingLanguage == null) throw new BusinessException("Programming Language does not exist");

        }
        public async Task ProgrammingLanguageExistWhenUpdated(int ProgrammingLanguageId)
        {
            ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(b => b.Id == ProgrammingLanguageId);
            if (programmingLanguage == null) throw new BusinessException("Programming Language does not exist");

        }
    }
}
