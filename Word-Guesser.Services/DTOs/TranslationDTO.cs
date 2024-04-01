using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Word_Guesser.Services.DTOs
{
    public class TranslationDTO : BaseDTO
    {
        public int WordId { get; set; }
        public int LanguageId { get; set; }
        public string Value { get; set; }
    }
}
