using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Guesser.Data.Data.Entities
{
    public class Picture : BaseEntity
    {
        public string Filename { get; set; }
        public int WordId { get; set; }
        public virtual Word? Word { get; set; }
    }
}
