﻿using Word_Guesser.Data.Data.Entities;
using Word_Guesser.Services.DTOs;

namespace Word_Guesser.Services.Abstarctions
{
    public interface ITranslationsService
    {
        Task<List<TranslationDTO>> GetTranslationsAsync();
        Task<TranslationDTO> GetTranslationsByIdAsync(int id);
        Task<TranslationDTO> GetTranslationsByValueAsync(string value);
        Task AddTranslationsAsync(TranslationCreateOrEditDTO translation);
        Task DeleteTranslationsByIdAsync(int id);
        Task UpdateTranslationsAsync(TranslationCreateOrEditDTO translation);
        Task<TranslationCreateOrEditDTO> GetTranslationsEditByIdAsync(int value);
    }
}
