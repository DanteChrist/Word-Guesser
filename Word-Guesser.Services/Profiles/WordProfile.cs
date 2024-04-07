using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_Guesser.Data.Data.Entities;
using Word_Guesser.Services.DTOs;

namespace Word_Guesser.Services.Profiles
{
    internal class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<Word, WordDTO>()
                .ReverseMap();
        }
    }
}
