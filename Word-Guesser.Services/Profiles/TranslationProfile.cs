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
    public class TranslationProfile : Profile

    {
        public TranslationProfile()
        {
            CreateMap<Translation, TranslationDTO>()
                .ForMember(dest => dest.Word, opt => opt.MapFrom(item => item.Word.Identifier))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(item => item.Language.Name));

            CreateMap<TranslationCreateOrEditDTO, Translation>()
                .ReverseMap();
        }
    }
}
