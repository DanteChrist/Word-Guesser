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
    public class PictureService : IPictureService
    {
        private readonly IRepository<Picture> _repository;
        private readonly IMapper _mapper;

        public PictureService(IRepository<Picture> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task AddPicturesAsync(PictureCreateOrEditDTO PictureDTO)
        {
            var Picture = _mapper.Map<Picture>(PictureDTO);
            await _repository.AddAsync(Picture);
        }

        public async Task DeletePicturesByIdAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<List<PictureDTO>> GetPicturesAnswersAsync(int wordId)
        {
            var correct = await _repository.GetAsync(item=>item.WordId == wordId);

            var items = await _repository.GetRandomAsync(item => item.WordId != wordId, 3);

            var result = new List<Picture>(correct).Concat(items);

            result = result.OrderBy(r => Guid.NewGuid()).ToList();

            return _mapper.Map<List<PictureDTO>>(result);
        }

        public async Task<List<PictureDTO>> GetPicturesAsync()
        {
            var Pictures = (await _repository.GetAllAsync()).ToList();
            return _mapper.Map<List<PictureDTO>>(Pictures);
        }

        public async Task<PictureDTO> GetPicturesByIdAsync(int id)
        {
            var Picture = await _repository.GetByIdAsync(id);
            return _mapper.Map<PictureDTO>(Picture);
        }

        public async Task UpdatePicturesAsync(PictureCreateOrEditDTO pictureDTO)
        {
            var Picture = _mapper.Map<Picture>(pictureDTO);
            await _repository.UpdateAsync(Picture);
        }
    }
}