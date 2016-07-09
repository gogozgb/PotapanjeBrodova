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
                new Polje(1, 2),
                new Polje(1, 3),
                new Polje(1, 4)
            };
            Brod b = new Brod(poljaZaBrod);
            IEnumerable<Polje> polja = b.Polja;
            Assert.AreEqual(1, polja.Count(p => p.Redak == 1 && p.Stupac == 2));
            Assert.AreEqual(1, polja.Count(p => p.Redak == 1 && p.Stupac == 3));
            Assert.AreEqual(1, polja.Count(p => p.Redak == 1 && p.Stupac == 4));
        }
    }
}
