using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Tests
{
    [TestClass]
    public class Inicializacoes
    {
        [TestMethod]
        public void Inicializa_Musica_Com_Album_E_Artista()
        {
            var artista = new Models.Artista { id = 1, biografia = string.Empty, titulo = "The Clash" };
            
            var album = new Models.Album(artista);
            album.id = 1;
            album.titulo = "London Calling";
            album.ano_lancamento = 1979;

            var musica = new Models.Musica(album);

            Assert.AreEqual(album, musica.album);
            Assert.AreEqual(artista, musica.album.artista);
        }

        [TestMethod]
        public void Inicializa_Album_Com_Artista()
        {
            var artista = new Models.Artista { id = 2, titulo = "The Cure", biografia = string.Empty };
            var album = new Models.Album(artista);

            Assert.AreEqual(artista, album.artista);
        }
    }
}
