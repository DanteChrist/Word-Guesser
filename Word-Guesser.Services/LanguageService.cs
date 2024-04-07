using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_Guesser.Data.Data.Entities;
using Word_Guesser.Data.Data.Repositories.Abstractions;
using Word_Guesser.Services.Abstarctions;
using Word_Guesser.Services.DTOs;

namespace Word_Guesser.Services
{
    public class LanguageService : ILanguagesService
    {
        private readonly IRepository<Language> _repository;
        private readonly IMapper _mapper;

        public LanguageService(IRepository<Language> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task AddLanguagesAsync(LanguageDTO LanguageDTO)
        {
            var language = _mapper.Map<Language>(LanguageDTO);
            await _repository.AddAsync(language);
        }

        public async  Task DeleteLanguagesByIdAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<List<LanguageDTO>> GetLanguagesAsync()
        {
            var languages = (await _repository.GetAllAsync()).ToList();
            return _mapper.Map<List<LanguageDTO>>(languages);
        }

        public async Task<LanguageDTO> GetLanguagesByIdAsync(int id)
        {
            var language = await _repository.GetByIdAsync(id);
            return _mapper.Map<LanguageDTO>(language);
        }

        public async Task UpdateLanguagesAsync(LanguageDTO LanguageDTO)
        {
            var language = _mapper.Map<Language>(LanguageDTO);
            await _repository.UpdateAsync(language);
        }
    }
}
