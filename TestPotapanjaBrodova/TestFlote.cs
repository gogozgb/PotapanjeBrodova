// "TestFlote.cs" u projektu "TestPotapanjaBrodova"
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestFlote
    {
        [TestMethod]
        public void Flota_DodajBrod_DodajeBrodUFlotu()
        {
            Flota f = new Flota();
            List<Polje> polja = new List<Polje>
            {
                new Polje(2, 1),
                new Polje(3, 1),
                new Polje(4, 1)
            };
            f.DodajBrod(polja);

            Assert.AreEqual(1, f.Brodovi.Count());
        }

        [TestMethod]
        public void Flota_DodajBrod_NakonDvaPozivaFlotaSadržiDvaBroda()
        {
            Flota f = new Flota();
            List<Polje> polja = new List<Polje>
            {
                new Polje(2, 1),
                new Polje(3, 1),
                new Polje(4, 1)
            };
            f.DodajBrod(polja);

            polja = new List<Polje>
            {
                new Polje(7, 2),
                new Polje(7, 3),
                new Polje(7, 4),
                new Polje(7, 5)
            };
            f.DodajBrod(polja);

            Assert.AreEqual(2, f.Brodovi.Count());
        }

        Flota SložiFlotu()
        {
            Flota f = new Flota();
            List<Polje> polja = new List<Polje>
            {
                new Polje(2, 1),
                new Polje(3, 1)
            };
            f.DodajBrod(polja);

            polja = new List<Polje>
            {
                new Polje(8, 5),
                new Polje(8, 6)
            };
            f.DodajBrod(polja);
            return f;
        }

        [TestMethod]
        public void Flota_Gađaj_VraćaPogodakZaPoljeBroda()
        {
            Flota f = SložiFlotu();
            Assert.AreEqual(RezultatGađanja.Pogodak, f.Gađaj(new Polje(2, 1)));
            Assert.AreEqual(RezultatGađanja.Pogodak, f.Gađaj(new Polje(8, 6)));
        }

        [TestMethod]
        public void Flota_Gađaj_VraćaPotonućeZaZadnjePoljeBroda()
        {
            Flota f = SložiFlotu();
            Assert.AreEqual(RezultatGađanja.Pogodak, f.Gađaj(new Polje(2, 1)));
            Assert.AreEqual(RezultatGađanja.Potonuće, f.Gađaj(new Polje(3, 1)));

            Assert.AreEqual(RezultatGađanja.Pogodak, f.Gađaj(new Polje(8, 6)));
            Assert.AreEqual(RezultatGađanja.Potonuće, f.Gađaj(new Polje(8, 5)));
        }

        [TestMethod]
        public void Flota_Gađaj_VraćaPromašajZaPoljeIzvanBroda()
        {
            Flota f = SložiFlotu();
            Assert.AreEqual(RezultatGađanja.Promašaj, f.Gađaj(new Polje(4, 1)));
        }
    }
}
