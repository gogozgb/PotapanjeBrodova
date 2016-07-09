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
                new Polje(1, 2),
                new Polje(1, 3),
                new Polje(1, 4)
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
                new Polje(1, 2),
                new Polje(1, 3),
                new Polje(1, 4)
            };
            f.DodajBrod(polja);

            polja = new List<Polje>
            {
                new Polje(2, 7),
                new Polje(3, 7),
                new Polje(4, 7),
                new Polje(5, 7)
            };
            f.DodajBrod(polja);

            Assert.AreEqual(2, f.Brodovi.Count());
        }
    }
}
