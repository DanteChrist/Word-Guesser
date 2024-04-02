using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_Guesser.Services.DTOs;

namespace Word_Guesser.Services.Abstarctions
{
    public interface ILanguagesService
    {
        Task<List<LanguageDTO>> GetLanguagesAsync();
        Task<LanguageDTO> GetLanguagesByIdAsync(int id);
        Task AddLanguagesAsync(LanguageDTO Language);
        Task DeleteLanguagesByIdAsync(int id);
        Task UpdateLanguagesAsync(LanguageDTO Language);

    }
}
