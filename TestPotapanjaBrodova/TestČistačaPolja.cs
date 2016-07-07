using System;
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
            ČistačPolja e = new ČistačPolja(mreža);
            List<Polje> brodskaPolja = new List<Polje>
            {
                new Polje(4, 3), new Polje(4, 4), new Polje(4, 5), new Polje(4, 6)
            };
            e.Ukloni(brodskaPolja);
            IEnumerable<Polje> polja = mreža.DajRaspoloživaPolja();
            Assert.AreEqual(82, polja.Count());
            // prvo provjerimo brodska polja:
            Assert.AreEqual(0, polja.Count(p => p.Redak == 4 && p.Stupac == 3));
            Assert.AreEqual(0, polja.Count(p => p.Redak == 4 && p.Stupac == 4));
            Assert.AreEqual(0, polja.Count(p => p.Redak == 4 && p.Stupac == 5));
            Assert.AreEqual(0, polja.Count(p => p.Redak == 4 && p.Stupac == 6));
            // potom provjerimo okolna polja (samo u uglovima):
            Assert.AreEqual(0, polja.Count(p => p.Redak == 3 && p.Stupac == 2));
            Assert.AreEqual(0, polja.Count(p => p.Redak == 3 && p.Stupac == 7));
            Assert.AreEqual(0, polja.Count(p => p.Redak == 5 && p.Stupac == 2));
            Assert.AreEqual(0, polja.Count(p => p.Redak == 5 && p.Stupac == 7));
        }

        [TestMethod]
        public void ČistačPolja_UklanjaBrodskaIOkolnaPoljaZaBrodULijevomGornjemKutu()
        {
            Mreža mreža = new Mreža(10, 10);
            ČistačPolja e = new ČistačPolja(mreža);
            List<Polje> brodskaPolja = new List<Polje>
            {
                new Polje(4, 3), new Polje(4, 4), new Polje(4, 5), new Polje(4, 6)
            };
            e.Ukloni(brodskaPolja);
            IEnumerable<Polje> polja = mreža.DajRaspoloživaPolja();
            Assert.AreEqual(82, polja.Count());
            // prvo provjerimo brodska polja:
            Assert.AreEqual(0, polja.Count(p => p.Redak == 4 && p.Stupac == 3));
            Assert.AreEqual(0, polja.Count(p => p.Redak == 4 && p.Stupac == 4));
            Assert.AreEqual(0, polja.Count(p => p.Redak == 4 && p.Stupac == 5));
            Assert.AreEqual(0, polja.Count(p => p.Redak == 4 && p.Stupac == 6));
            // potom provjerimo okolna polja (samo u uglovima):
            Assert.AreEqual(0, polja.Count(p => p.Redak == 3 && p.Stupac == 2));
            Assert.AreEqual(0, polja.Count(p => p.Redak == 3 && p.Stupac == 7));
            Assert.AreEqual(0, polja.Count(p => p.Redak == 5 && p.Stupac == 2));
            Assert.AreEqual(0, polja.Count(p => p.Redak == 5 && p.Stupac == 7));
        }
    }
}
