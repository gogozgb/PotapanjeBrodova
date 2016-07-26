// "TestTražilice
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
            Assert.AreEqual(2, nizovi.Count(n => n.Contains(new Polje(0, 1))));
            // polje [0, 2] mora se pojaviti dva puta
            Assert.AreEqual(2, nizovi.Count(n => n.Contains(new Polje(0, 2))));
            // polje [0, 3] smije se pojaviti samo jednom
            Assert.AreEqual(1, nizovi.Count(n => n.Contains(new Polje(0, 3))));
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
            Assert.AreEqual(2, nizovi.Count(n => n.Contains(new Polje(1, 0))));
            // polje [2, 0] mora se pojaviti tri puta
            Assert.AreEqual(3, nizovi.Count(n => n.Contains(new Polje(2, 0))));
            // polje [3, 0] smije se pojaviti dva puta
            Assert.AreEqual(2, nizovi.Count(n => n.Contains(new Polje(3, 0))));
            // polje [4, 0] smije se pojaviti samo jednom
            Assert.AreEqual(1, nizovi.Count(n => n.Contains(new Polje(4, 0))));
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
    }
}
