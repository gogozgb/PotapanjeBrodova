using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestTamanitelja
    {
        [TestMethod]
        public void Tamanitelj_DajKandidate_ZaDvaPoljaUNastavkuVraćaObaPoljaAkoUNjihovimSmjerovimaImaVišePoljaOdPreostaleDuljineBroda()
        {
            Mreža mreža = new Mreža(10, 10);
            int duljinaBroda = 3;
            List<Polje> pogođenaPolja = new List<Polje> { new Polje(4, 3), new Polje(4, 4) };
            Tamanitelj pucač = new Tamanitelj(mreža, duljinaBroda, pogođenaPolja);
            IEnumerable<Polje> kandidati = pucač.DajKandidate();
            Assert.AreEqual(2, kandidati.Count());
            Assert.IsTrue(kandidati.Contains(new Polje(4, 2)));
            Assert.IsTrue(kandidati.Contains(new Polje(4, 5)));
        }

        [TestMethod]
        public void Tamanitelj_DajKandidate_ZaDvaPoljaUNastavkuVraćaSamoOnoUČijemSmjeruImaVišePoljaOdPreostaleDuljineBroda()
        {
            Mreža mreža = new Mreža(10, 10);
            int duljinaBroda = 4;
            List<Polje> pogođenaPolja = new List<Polje> { new Polje(4, 1), new Polje(4, 2) };
            Tamanitelj pucač = new Tamanitelj(mreža, duljinaBroda, pogođenaPolja);
            IEnumerable<Polje> kandidati = pucač.DajKandidate();
            Assert.AreEqual(1, kandidati.Count());
            Assert.IsTrue(kandidati.Contains(new Polje(4, 3)));
        }

        [TestMethod]
        public void Tamanitelj_DajKandidate_ZaDvaPoljaUNastavkuVraćaObaPoljaAkoUNjihovimSmjerovimaImajednakoPoljaAliManjeOdPreostaleDuljineBroda()
        {
            Mreža mreža = new Mreža(6, 6);
            int duljinaBroda = 5;
            List<Polje> pogođenaPolja = new List<Polje> { new Polje(2, 4), new Polje(3, 4) };
            Tamanitelj pucač = new Tamanitelj(mreža, duljinaBroda, pogođenaPolja);
            IEnumerable<Polje> kandidati = pucač.DajKandidate();
            Assert.AreEqual(2, kandidati.Count());
            Assert.IsTrue(kandidati.Contains(new Polje(1, 4)));
            Assert.IsTrue(kandidati.Contains(new Polje(4, 4)));
        }

        [TestMethod]
        public void Tamanitelj_DajKandidate_ZaDvaPoljaUNastavkuVraćaOnoPoljeUČijemSmjeruImaVišePoljaAliManjeOdPreostaleDuljineBroda()
        {
            Mreža mreža = new Mreža(5, 5);
            int duljinaBroda = 5;
            List<Polje> pogođenaPolja = new List<Polje> { new Polje(2, 4), new Polje(3, 4) };
            Tamanitelj pucač = new Tamanitelj(mreža, duljinaBroda, pogođenaPolja);
            IEnumerable<Polje> kandidati = pucač.DajKandidate();
            Assert.AreEqual(1, kandidati.Count());
            Assert.IsTrue(kandidati.Contains(new Polje(1, 4)));
        }

        [TestMethod]
        public void Tamanitelj_DajKandidate_ZaBrodOdGornjegRubaMrežeVraćaPoljeIspod()
        {
            Mreža mreža = new Mreža(6, 6);
            int duljinaBroda = 5;
            List<Polje> pogođenaPolja = new List<Polje> { new Polje(2, 0), new Polje(2, 1) };
            Tamanitelj pucač = new Tamanitelj(mreža, duljinaBroda, pogođenaPolja);
            IEnumerable<Polje> kandidati = pucač.DajKandidate();
            Assert.AreEqual(1, kandidati.Count());
            Assert.IsTrue(kandidati.Contains(new Polje(2, 2)));
        }

        [TestMethod]
        public void Tamanitelj_DajKandidate_ZaBrodOdDesnogRubaMrežeVraćaPoljeLijevo()
        {
            Mreža mreža = new Mreža(6, 6);
            int duljinaBroda = 5;
            List<Polje> pogođenaPolja = new List<Polje> { new Polje(4, 3), new Polje(5, 3) };
            Tamanitelj pucač = new Tamanitelj(mreža, duljinaBroda, pogođenaPolja);
            IEnumerable<Polje> kandidati = pucač.DajKandidate();
            Assert.AreEqual(1, kandidati.Count());
            Assert.IsTrue(kandidati.Contains(new Polje(3, 3)));
        }

        [TestMethod]
        public void Tamanitelj_DajKandidate_ZaBrodOdDonjegRubaMrežeVraćaPoljeIznad()
        {
            Mreža mreža = new Mreža(6, 6);
            int duljinaBroda = 5;
            List<Polje> pogođenaPolja = new List<Polje> { new Polje(2, 4), new Polje(2, 5) };
            Tamanitelj pucač = new Tamanitelj(mreža, duljinaBroda, pogođenaPolja);
            IEnumerable<Polje> kandidati = pucač.DajKandidate();
            Assert.AreEqual(1, kandidati.Count());
            Assert.IsTrue(kandidati.Contains(new Polje(2, 3)));
        }

        [TestMethod]
        public void Tamanitelj_DajKandidate_ZaBrodOdLijevogRubaMrežeVraćaPoljeDesno()
        {
            Mreža mreža = new Mreža(6, 6);
            int duljinaBroda = 5;
            List<Polje> pogođenaPolja = new List<Polje> { new Polje(0, 4), new Polje(1, 4) };
            Tamanitelj pucač = new Tamanitelj(mreža, duljinaBroda, pogođenaPolja);
            IEnumerable<Polje> kandidati = pucač.DajKandidate();
            Assert.AreEqual(1, kandidati.Count());
            Assert.IsTrue(kandidati.Contains(new Polje(2, 4)));
        }
    }
}
