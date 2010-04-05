using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Musica
    {
        public int id { get; set; }
        public Artista artista { get; set; }
        public Album album { get; set; }
        public string titulo { get; set; }
    }
}
