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
using Word_Guesser.Services.Profiles;

namespace Word_Guesser.Services
{
    public class TranslationService : ITranslationsService
    {

        private readonly IRepository<Translation> _repository;
        private readonly IMapper _mapper;
        public TranslationService(IRepository<Translation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddTranslationsAsync(TranslationDTO translationDTO)
        {
            var translation = _mapper.Map<Translation>(translationDTO);
            await _repository.AddAsync(translation);
        }

        public async Task DeleteTranslationsByIdAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<List<TranslationDTO>> GetTranslationsAsync()
        {
            var translations = (await _repository.GetAllAsync()).ToList();
            return _mapper.Map<List<TranslationDTO>>(translations);
        }

        public async Task<TranslationDTO> GetTranslationsByValueAsync(string value)
        {
            var translation = await _repository.GetAsync(item => item.Value == value);
            return _mapper.Map<TranslationDTO>(translation.FirstOrDefault());
        }

        public async Task<TranslationDTO> GetTranslationsByIdAsync(int id)
        {
            var translation = await _repository.GetByIdAsync(id);
            return _mapper.Map<TranslationDTO>(translation);
        }

        public async Task UpdateTranslationsAsync(TranslationDTO translationDTO)
        {
            var translation = _mapper.Map<Translation>(translationDTO);
            await _repository.UpdateAsync(translation);
        }
    }
}
