using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_Guesser.Services.DTOs;

namespace Word_Guesser.Services.Abstarctions
{
    public interface IPictureService
    {
        Task<List<PictureDTO>> GetPicturesAsync();
        Task<List<PictureDTO>> GetPicturesAnswersAsync(int wordId);
        Task<PictureDTO> GetPicturesByIdAsync(int id);
        Task AddPicturesAsync(PictureCreateOrEditDTO pictureDTO);
        Task DeletePicturesByIdAsync(int id);
        Task UpdatePicturesAsync(PictureCreateOrEditDTO pictureDTO);
        
    }
}
