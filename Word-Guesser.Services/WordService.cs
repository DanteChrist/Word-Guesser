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
    public class WordService : IWordsService
    {
        private readonly IRepository<Word> _repository;
        private readonly IMapper _mapper;
        public WordService(IRepository<Word> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddWordsAsync(WordDTO WordDTO)
        {
            var Word = _mapper.Map<Word>(WordDTO);
            await _repository.AddAsync(Word);
        }

        public async Task DeleteWordsByIdAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<WordDTO> GetRandomWordAsync()
        {
            var word = (await _repository.GetRandomAsync(item => item.Id > 0, 1)).FirstOrDefault();
            return _mapper.Map<WordDTO>(word);
        }

        public async Task<List<WordDTO>> GetWordsAsync()
        {
            var Words = (await _repository.GetAllAsync()).ToList();
            return _mapper.Map<List<WordDTO>>(Words);
        }

        public async Task<WordDTO> GetWordsByIdAsync(int id)
        {
            var Word = await _repository.GetByIdAsync(id);
            return _mapper.Map<WordDTO>(Word);
        }

        public async Task UpdateWordsAsync(WordDTO WordDTO)
        {
            var Word = _mapper.Map<Word>(WordDTO);
            await _repository.UpdateAsync(Word);
        }
    }
}
