﻿// "TestČistačaFlote.cs" u projektu "TestPotapanjaBrodova"
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestČistačaPolja
    {
        [TestMethod]
        public void ČistačPolja_UklanjaBrodskaIOkolnaPolja()
        {
            Mreža mreža = new Mreža(10, 10);
            List<Polje> brodskaPolja = new List<Polje>
            {
                new Polje(4, 3), new Polje(4, 4), new Polje(4, 5), new Polje(4, 6)
            };
            ČistačPolja e = new ČistačPolja(mreža);
            e.Ukloni(brodskaPolja);
            IEnumerable<Polje> polja = mreža.RaspoloživaPolja;
            Assert.AreEqual(82, polja.Count());
            // prvo provjerimo brodska polja:
            Assert.IsFalse(polja.Contains(new Polje(4, 3)));
            Assert.IsFalse(polja.Contains(new Polje(4, 4)));
            Assert.IsFalse(polja.Contains(new Polje(4, 5)));
            Assert.IsFalse(polja.Contains(new Polje(4, 6)));
            // potom provjerimo okolna polja (samo u uglovima):
            Assert.IsFalse(polja.Contains(new Polje(3, 2)));
            Assert.IsFalse(polja.Contains(new Polje(3, 7)));
            Assert.IsFalse(polja.Contains(new Polje(5, 2)));
            Assert.IsFalse(polja.Contains(new Polje(5, 7)));
        }

        [TestMethod]
        public void ČistačPolja_UklanjaBrodskaIOkolnaPoljaZaBrodULijevomGornjemKutu()
        {
            Mreža mreža = new Mreža(10, 10);
            List<Polje> brodskaPolja = new List<Polje>
            {
                new Polje(0, 0), new Polje(0, 1)
            };
            ČistačPolja e = new ČistačPolja(mreža);
            e.Ukloni(brodskaPolja);
            IEnumerable<Polje> polja = mreža.RaspoloživaPolja;
            Assert.AreEqual(94, polja.Count());
            // prvo provjerimo brodska polja:
            Assert.IsFalse(polja.Contains(new Polje(0, 0)));
            Assert.IsFalse(polja.Contains(new Polje(0, 1)));
            // potom provjerimo okolna polja (samo u uglovima):
            Assert.IsFalse(polja.Contains(new Polje(1, 0)));
            Assert.IsFalse(polja.Contains(new Polje(1, 2)));
            Assert.IsFalse(polja.Contains(new Polje(0, 2)));
        }

        [TestMethod]
        public void ČistačPolja_UklanjaBrodskaIOkolnaPoljaZaBrodUDesnomDonjemKutu()
        {
            Mreža mreža = new Mreža(10, 10);
            List<Polje> brodskaPolja = new List<Polje>
            {
                new Polje(9, 8), new Polje(9, 9)
            };
            ČistačPolja e = new ČistačPolja(mreža);
            e.Ukloni(brodskaPolja);
            IEnumerable<Polje> polja = mreža.RaspoloživaPolja;
            Assert.AreEqual(94, polja.Count());
            // prvo provjerimo brodska polja:
            Assert.IsFalse(polja.Contains(new Polje(8, 9)));
            Assert.IsFalse(polja.Contains(new Polje(9, 9)));
            // potom provjerimo okolna polja (samo u uglovima):
            Assert.IsFalse(polja.Contains(new Polje(9, 7)));
            Assert.IsFalse(polja.Contains(new Polje(8, 7)));
            Assert.IsFalse(polja.Contains(new Polje(8, 9)));
        }
    }
}
