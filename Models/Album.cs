using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Album
    {
        public int id { get; set; }
        public Artista artista { get; set; }
        public string titulo { get; set; }
        public int ano_lancamento { get; set; }
    }
}
