using Word_Guesser.Services.DTOs;

namespace Word_Guesser.Services.Abstarctions
{
    public interface ITranslationsService
    {
        Task<List<TranslationDTO>> GetTranslationsAsync();
        Task<TranslationDTO> GetTranslationsByIdAsync(int id);
        Task<TranslationDTO> GetTranslationsByValueAsync(string value);
        Task AddTranslationsAsync(TranslationDTO translation);
        Task DeleteTranslationsByIdAsync(int id);
        Task UpdateTranslationsAsync(TranslationDTO translation);
    }
}
