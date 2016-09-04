// "TestBroda.cs" u projektu "TestPotapanjaBrodova"
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestBroda
    {
        [TestMethod]
        public void Brod_Polja_VraćaPoljaZadanaKonstruktorom()
        {
            List<Polje> poljaZaBrod = new List<Polje>
            {
                new Polje(2, 1),
                new Polje(3, 1),
                new Polje(4, 1)
            };
            Brod b = new Brod(poljaZaBrod);
            IEnumerable<Polje> polja = b.Polja;
            Assert.AreEqual(1, polja.Count(p => p.Stupac == 2 && p.Redak == 1));
            Assert.AreEqual(1, polja.Count(p => p.Stupac == 3 && p.Redak == 1));
            Assert.AreEqual(1, polja.Count(p => p.Stupac == 4 && p.Redak == 1));
        }

        [TestMethod]
        public void Brod_Gađaj_VraćaPogodakZaPoljeBroda()
        {
            List<Polje> poljaZaBrod = new List<Polje>
            {
                new Polje(2, 1),
                new Polje(3, 1),
                new Polje(4, 1)
            };
            Brod b = new Brod(poljaZaBrod);
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(2, 1)));
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(3, 1)));
        }

        [TestMethod]
        public void Brod_Gađaj_VraćaPromašajZaPoljeKojeNePripadaBrodu()
        {
            List<Polje> poljaZaBrod = new List<Polje>
            {
                new Polje(2, 1),
                new Polje(3, 1)
            };
            Brod b = new Brod(poljaZaBrod);
            Assert.AreEqual(RezultatGađanja.Promašaj, b.Gađaj(new Polje(2, 3)));
        }

        [TestMethod]
        public void Brod_Gađaj_VraćaPotonućeZaZadnjePoljeBroda()
        {
            List<Polje> poljaZaBrod = new List<Polje>
            {
                new Polje(2, 1),
                new Polje(3, 1),
                new Polje(4, 1)
            };
            Brod b = new Brod(poljaZaBrod);
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(2, 1)));
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(4, 1)));
            Assert.AreEqual(RezultatGađanja.Potonuće, b.Gađaj(new Polje(3, 1)));
        }

        [TestMethod]
        public void Brod_Gađaj_VraćaPogodakZaIstoPoljeBroda()
        {
            List<Polje> poljaZaBrod = new List<Polje>
            {
                new Polje(2, 1),
                new Polje(3, 1)
            };
            Brod b = new Brod(poljaZaBrod);
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(2, 1)));
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(2, 1)));
        }

        [TestMethod]
        public void Brod_Gađaj_VraćaPotonućeZaIstoZadnjePoljeBroda()
        {
            List<Polje> poljaZaBrod = new List<Polje>
            {
                new Polje(2, 1),
                new Polje(3, 1)
            };
            Brod b = new Brod(poljaZaBrod);
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(2, 1)));
            Assert.AreEqual(RezultatGađanja.Potonuće, b.Gađaj(new Polje(3, 1)));
            Assert.AreEqual(RezultatGađanja.Potonuće, b.Gađaj(new Polje(3, 1)));
        }
    }
}
