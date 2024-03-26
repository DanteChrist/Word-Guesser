using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Guesser.Data.Data.Entities
{
    public class Translation : BaseEntity
    {
        public virtual Word? Word { get; set; }
        public int WordId { get; set; }
        public virtual Language? Language { get; set; }
        public int LanguageId { get; set; }
        public string Value { get; set; }
    }
}
