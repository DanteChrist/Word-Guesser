using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_Guesser.Services.DTOs;

namespace Word_Guesser.Services.Abstarctions
{
    public interface IWordsService
    {
        Task<WordDTO> GetRandomWordAsync();
        Task<List<WordDTO>> GetWordsAsync();
        Task<WordDTO> GetWordsByIdAsync(int id);
        Task AddWordsAsync(WordDTO Word);
        Task DeleteWordsByIdAsync(int id);
        Task UpdateWordsAsync(WordDTO Word);
    }
}
