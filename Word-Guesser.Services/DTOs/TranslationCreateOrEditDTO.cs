using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Guesser.Services.DTOs
{
    public class TranslationCreateOrEditDTO : BaseDTO
    {
            public int WordId { get; set; }
            public int LanguageId { get; set; }
            public string Value { get; set; }
        
    }
}
