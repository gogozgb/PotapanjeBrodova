// "TestTražiliceNizovaPolja.cs" u projektu "TestPotapanjaBrodova"
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace TestPotapanjaBrodova
{
    using NizoviPolja = IEnumerable<IEnumerable<Polje>>;

    [TestClass]
    public class TestTražiliceNizovaPolja
    {
        [TestMethod]
        public void TražilicaNizovaPolja_Vraća2NizaDuljine3ZaHorizontalniNiz4Polja()
        {
            Mreža mreža = new Mreža(1, 4);
            int duljina = 3;
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja(mreža);
            NizoviPolja nizovi = tražilica.DajNizovePolja(duljina);
            Assert.AreEqual(2, nizovi.Count());
            // svi nizovi moraju biti duljine jednake duljini broda
            Assert.AreEqual(true, nizovi.All(n => n.Count() == duljina));
            // polje [0, 0] smije se pojaviti samo jednom
            Assert.AreEqual(1, nizovi.Count(n => n.Contains(new Polje(0, 0))));
            // polje [0, 1] mora se pojaviti dva puta
            Assert.AreEqual(2, nizovi.Count(n => n.Contains(new Polje(1, 0))));
            // polje [0, 2] mora se pojaviti dva puta
            Assert.AreEqual(2, nizovi.Count(n => n.Contains(new Polje(2, 0))));
            // polje [0, 3] smije se pojaviti samo jednom
            Assert.AreEqual(1, nizovi.Count(n => n.Contains(new Polje(3, 0))));
        }

        [TestMethod]
        public void TražilicaNizovaPolja_Vraća3NizaDuljine3ZaVertikalniNiz5Polja()
        {
            Mreža mreža = new Mreža(5, 1);
            int duljina = 3;
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja(mreža);
            NizoviPolja nizovi = tražilica.DajNizovePolja(duljina);
            Assert.AreEqual(3, nizovi.Count());
            // svi nizovi moraju biti duljine jednake duljini broda
            Assert.AreEqual(true, nizovi.All(n => n.Count() == duljina));
            // polje [0, 0] smije se pojaviti samo jednom
            Assert.AreEqual(1, nizovi.Count(n => n.Contains(new Polje(0, 0))));
            // polje [1, 0] mora se pojaviti dva puta
            Assert.AreEqual(2, nizovi.Count(n => n.Contains(new Polje(0, 1))));
            // polje [2, 0] mora se pojaviti tri puta
            Assert.AreEqual(3, nizovi.Count(n => n.Contains(new Polje(0, 2))));
            // polje [3, 0] smije se pojaviti dva puta
            Assert.AreEqual(2, nizovi.Count(n => n.Contains(new Polje(0, 3))));
            // polje [4, 0] smije se pojaviti samo jednom
            Assert.AreEqual(1, nizovi.Count(n => n.Contains(new Polje(0, 4))));
        }

        [TestMethod]
        public void TražilicaNizovaPolja_VraćaPrazanNizAkoNemaDovoljnoSlobodnihPolja()
        {
            Mreža mreža = new Mreža(1, 3);
            int duljina = 4;
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja(mreža);
            NizoviPolja nizovi = tražilica.DajNizovePolja(duljina);
            Assert.AreEqual(0, nizovi.Count());
        }

        [TestMethod]
        public void TražilicaNizovaPolja_VraćaMaximalno5PoljaIznadPoljaRedak5Stupac5()
        {
            Mreža m = new Mreža(10, 10);
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja(m);
            var poljaIznad = tražilica.DajPoljaUNastavku(new Polje(5, 5), Smjer.Gore);
            Assert.AreEqual(5, poljaIznad.Count());
            Assert.IsTrue(poljaIznad.Contains(new Polje(5, 4)));
            Assert.IsTrue(poljaIznad.Contains(new Polje(5, 3)));
            Assert.IsTrue(poljaIznad.Contains(new Polje(5, 2)));
            Assert.IsTrue(poljaIznad.Contains(new Polje(5, 1)));
            Assert.IsTrue(poljaIznad.Contains(new Polje(5, 0)));
        }

        [TestMethod]
        public void TražilicaNizovaPolja_Vraća3PoljaIznadPoljaRedak5Stupac5()
        {
            Mreža m = new Mreža(10, 10);
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja(m);
            var poljaIznad = tražilica.DajPoljaUNastavku(new Polje(5, 5), Smjer.Gore);
            Assert.AreEqual(5, poljaIznad.Count());
            Assert.IsTrue(poljaIznad.Contains(new Polje(5, 4)));
            Assert.IsTrue(poljaIznad.Contains(new Polje(5, 3)));
            Assert.IsTrue(poljaIznad.Contains(new Polje(5, 2)));
        }

        [TestMethod]
        public void TražilicaPoljaUNastavku_UVraćenomNizuPoljaIznadPoljaRedak5Stupac5PrvoPoljeJeURetku4()
        {
            Mreža m = new Mreža(10, 10);
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja(m);
            var poljaIznad = tražilica.DajPoljaUNastavku(new Polje(5, 5), Smjer.Gore);
            Assert.AreEqual(new Polje(5, 4), poljaIznad.First());
        }

        [TestMethod]
        public void TražilicaPoljaUNastavku_Vraća4PoljaDesnoOdPoljaRedak5Stupac5()
        {
            Mreža m = new Mreža(10, 10);
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja(m);
            var poljaDesno = tražilica.DajPoljaUNastavku(new Polje(5, 5), Smjer.Desno);
            Assert.AreEqual(4, poljaDesno.Count());
            Assert.IsTrue(poljaDesno.Contains(new Polje(6, 5)));
            Assert.IsTrue(poljaDesno.Contains(new Polje(9, 5)));
        }

        [TestMethod]
        public void TražilicaPoljaUNastavku_UVraćenomNizuPoljaDesnoOdPoljaRedak5Stupac5PrvoJePoljeUStupcu6()
        {
            Mreža m = new Mreža(10, 10);
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja(m);
            var poljaDesno = tražilica.DajPoljaUNastavku(new Polje(5, 5), Smjer.Desno);
            Assert.AreEqual(new Polje(6, 5), poljaDesno.First());
        }

        [TestMethod]
        public void TražilicaPoljaUNastavku_Vraća4PoljaIspodPoljaRedak5Stupac5()
        {
            Mreža m = new Mreža(10, 10);
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja(m);
            var poljaIspod = tražilica.DajPoljaUNastavku(new Polje(5, 5), Smjer.Dolje);
            Assert.AreEqual(4, poljaIspod.Count());
            Assert.IsTrue(poljaIspod.Contains(new Polje(5, 6)));
            Assert.IsTrue(poljaIspod.Contains(new Polje(5, 9)));
        }

        [TestMethod]
        public void TražilicaPoljaUNastavku_UVraćenomNizuPoljaIspodPoljaRedak5Stupac5PrvoJePoljeURetku6()
        {
            Mreža m = new Mreža(10, 10);
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja(m);
            var poljaIspod = tražilica.DajPoljaUNastavku(new Polje(5, 5), Smjer.Dolje);
            Assert.AreEqual(new Polje(5, 6), poljaIspod.First());
        }

    }
}
