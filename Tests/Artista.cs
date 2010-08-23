using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Moq;
using DAL;
using DAL.Base;

namespace Tests
{
    [TestClass]
    public class Artista
    {
        [TestMethod]
        public void Verificar_Insercao()
        {
            var artista = new Models.Artista();
            artista.titulo = "Gavin Degraw";
            artista.biografia = String.Empty;
            artista.id = 0;

            var meuMockDeVerdadeVerdadeira = new Mock<DALInterface>();
            meuMockDeVerdadeVerdadeira.Setup(l => l.executarScalar(It.IsAny<String>())).Returns(88);

            var artistaDAL = new ArtistaDAL(meuMockDeVerdadeVerdadeira.Object);
            artistaDAL.salvar(artista);

            meuMockDeVerdadeVerdadeira.VerifyAll();
            Assert.AreNotEqual(0, artista.id);
        }

        [TestMethod]
        public void Verificar_Atualizacao()
        {
            var artista = new Models.Artista();
            artista.titulo = "La Roux";
            artista.biografia = String.Empty;
            artista.id = 10;

            var mockDAL = new Mock<DALInterface>();
            mockDAL.Setup(l => l.executarScalar(It.IsAny<String>())).Returns(88);

            var artistaDAL = new ArtistaDAL(mockDAL.Object);
            artistaDAL.salvar(artista);
            
            mockDAL.Verify(d => d.executar(It.IsAny<String>()), Times.Once());
            Assert.AreEqual(10, artista.id);
        }

        [TestMethod]
        public void Atualizar_Contendo_Objeto_Nulo()
        {
            var artista = new Models.Artista();
            artista.id = 7;

            var mockDAL = new Mock<DALInterface>();
            var artistaDAL = new ArtistaDAL(mockDAL.Object);

            artistaDAL.salvar(artista);
            mockDAL.VerifyAll();
        }
    }
}
