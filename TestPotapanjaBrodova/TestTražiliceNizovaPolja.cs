// "TestTražilice
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestTražiliceNizovaPolja
    {
        [TestMethod]
        public void TražilicaNizovaPolja_Vraća2NizaDuljine3ZaHorizontalniNiz4Polja()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(0, 0), new Polje(0, 1), new Polje(0, 2), new Polje(0, 3)
            };
            int duljina = 3;
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja();
            var nizovi = tražilica.DajNizovePolja(polja, duljina);
            Assert.AreEqual(2, nizovi.Count());
            // svi nizovi moraju biti duljine jednake duljini broda
            Assert.AreEqual(true, nizovi.All(n => n.Count() == duljina));
            // polje [0, 0] smije se pojaviti samo jednom
            Assert.AreEqual(1, nizovi.Count(n => n.Count(p => p.Redak == 0 && p.Stupac == 0) == 1));
            // polje [0, 1] mora se pojaviti dva puta
            Assert.AreEqual(2, nizovi.Count(n => n.Count(p => p.Redak == 0 && p.Stupac == 1) == 1));
            // polje [0, 2] mora se pojaviti dva puta
            Assert.AreEqual(2, nizovi.Count(n => n.Count(p => p.Redak == 0 && p.Stupac == 2) == 1));
            // polje [0, 3] smije se pojaviti samo jednom
            Assert.AreEqual(1, nizovi.Count(n => n.Count(p => p.Redak == 0 && p.Stupac == 3) == 1));
        }

        [TestMethod]
        public void TražilicaNizovaPolja_Vraća3NizaDuljine3ZaVertikalniNiz5Polja()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(0, 0), new Polje(1, 0), new Polje(2, 0), new Polje(3, 0), new Polje(4, 0)
            };
            int duljina = 3;
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja();
            var nizovi = tražilica.DajNizovePolja(polja, duljina);
            Assert.AreEqual(3, nizovi.Count());
            // svi nizovi moraju biti duljine jednake duljini broda
            Assert.AreEqual(true, nizovi.All(n => n.Count() == duljina));
            // polje [0, 0] smije se pojaviti samo jednom
            Assert.AreEqual(1, nizovi.Count(n => n.Count(p => p.Redak == 0 && p.Stupac == 0) == 1));
            // polje [1, 0] mora se pojaviti dva puta
            Assert.AreEqual(2, nizovi.Count(n => n.Count(p => p.Redak == 1 && p.Stupac == 0) == 1));
            // polje [2, 0] mora se pojaviti tri puta
            Assert.AreEqual(3, nizovi.Count(n => n.Count(p => p.Redak == 2 && p.Stupac == 0) == 1));
            // polje [3, 0] smije se pojaviti dva puta
            Assert.AreEqual(2, nizovi.Count(n => n.Count(p => p.Redak == 3 && p.Stupac == 0) == 1));
            // polje [4, 0] smije se pojaviti samo jednom
            Assert.AreEqual(1, nizovi.Count(n => n.Count(p => p.Redak == 4 && p.Stupac == 0) == 1));
        }

        [TestMethod]
        public void TražilicaNizovaPolja_VraćaPrazanNizAkoNemaDovoljnoSlobodnihPolja()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(0, 0), new Polje(0, 1), new Polje(0, 2)
            };
            int duljina = 4;
            TražilicaNizovaPolja tražilica = new TražilicaNizovaPolja();
            var nizovi = tražilica.DajNizovePolja(polja, duljina);
            Assert.AreEqual(0, nizovi.Count());
        }
    }
}
