using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Guesser.Services.DTOs
{
    public class PictureCreateOrEditDTO : BaseDTO
    {
        public string Filename { get; set; }
        public int WordId { get; set; }
    }
}
