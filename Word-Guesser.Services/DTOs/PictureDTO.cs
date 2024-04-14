using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Guesser.Services.DTOs
{
    public class PictureDTO : BaseDTO
    {
        public string Filename { get; set; }
        public WordDTO? Word { get; set; }
    }
}
