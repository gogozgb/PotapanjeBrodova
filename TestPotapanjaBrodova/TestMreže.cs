﻿// "TestMreže.cs" u projektu "TestPotapanjaBrodova"
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestMreže
    {
        [TestMethod]
        public void Mreža_RaspoloživaPolja_NaPočetkuVraćaSvaPolja()
        {
            Mreža m = new Mreža(5, 5);
            IEnumerable<Polje> polja = m.RaspoloživaPolja;
            Assert.AreEqual(25, polja.Count());
            // provjeravamo postoji li (samo jedno) polje [0, 0]
            Assert.AreEqual(1, polja.Count(p => p.Stupac == 0 && p.Redak == 0));
            // provjeravamo postoji li (samo jedno) polje [4, 4]
            Assert.AreEqual(1, polja.Count(p => p.Stupac == 4 && p.Redak == 4));
        }

        [TestMethod]
        public void Mreža_EliminirajPolje_UklanjaPoljeIzMreže()
        {
            Mreža m = new Mreža(5, 5);
            m.UkloniPolje(3, 1);
            IEnumerable<Polje> polja = m.RaspoloživaPolja;
            Assert.AreEqual(24, polja.Count());
            // provjeravamo da polje [1, 3] ne postoji u listi raspoloživih polja
            Assert.IsFalse(polja.Contains(new Polje(3, 1)));
        }

        [TestMethod]
        public void Mreža_EliminirajPolje_BacaIznimkuZaRedakIzvanMreže()
        {
            Mreža m = new Mreža(5, 5);
            try
            {
                m.UkloniPolje(2, 5);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.AreEqual(25, m.RaspoloživaPolja.Count());
            }

            try
            {
                m.UkloniPolje(2, -1);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.AreEqual(25, m.RaspoloživaPolja.Count());
            }
        }

        [TestMethod]
        public void Mreža_EliminirajPolje_BacaIznimkuZaStupacIzvanMreže()
        {
            Mreža m = new Mreža(5, 5);
            try
            {
                m.UkloniPolje(5, 2);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.AreEqual(25, m.RaspoloživaPolja.Count());
            }

            try
            {
                m.UkloniPolje(-1, 2);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.AreEqual(25, m.RaspoloživaPolja.Count());
            }
        }

        [TestMethod]
        public void Mreža_EliminirajPolje_NeBacaIznimkuZaVećEliminiranoPoljeUnutarMreže()
        {
            Mreža m = new Mreža(5, 5);
            m.UkloniPolje(2, 1);
            m.UkloniPolje(2, 1);
            IEnumerable<Polje> polja = m.RaspoloživaPolja;
            Assert.AreEqual(24, polja.Count());
            Assert.IsFalse(polja.Contains(new Polje(2, 1)));
        }
    }
}
