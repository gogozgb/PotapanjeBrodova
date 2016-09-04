// "TestČistačaFlote.cs" u projektu "TestPotapanjaBrodova"
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
                new Polje(3, 4), new Polje(4, 4), new Polje(5, 4), new Polje(6, 4)
            };
            ČistačPolja e = new ČistačPolja(mreža);
            e.Ukloni(brodskaPolja);
            IEnumerable<Polje> polja = mreža.RaspoloživaPolja;
            Assert.AreEqual(82, polja.Count());
            // prvo provjerimo brodska polja:
            Assert.IsFalse(polja.Contains(new Polje(3, 4)));
            Assert.IsFalse(polja.Contains(new Polje(4, 4)));
            Assert.IsFalse(polja.Contains(new Polje(5, 4)));
            Assert.IsFalse(polja.Contains(new Polje(6, 4)));
            // potom provjerimo okolna polja (samo u uglovima):
            Assert.IsFalse(polja.Contains(new Polje(2, 3)));
            Assert.IsFalse(polja.Contains(new Polje(7, 3)));
            Assert.IsFalse(polja.Contains(new Polje(2, 5)));
            Assert.IsFalse(polja.Contains(new Polje(7, 5)));
        }

        [TestMethod]
        public void ČistačPolja_UklanjaBrodskaIOkolnaPoljaZaBrodUzGornjiRubMreže()
        {
            Mreža mreža = new Mreža(10, 10);
            List<Polje> brodskaPolja = new List<Polje>
            {
                new Polje(3, 0), new Polje(4, 0)
            };
            ČistačPolja e = new ČistačPolja(mreža);
            e.Ukloni(brodskaPolja);
            IEnumerable<Polje> polja = mreža.RaspoloživaPolja;
            Assert.AreEqual(92, polja.Count());
            // prvo provjerimo brodska polja:
            Assert.IsFalse(polja.Contains(new Polje(3, 0)));
            Assert.IsFalse(polja.Contains(new Polje(4, 0)));
            // potom provjerimo okolna polja (samo u uglovima):
            Assert.IsFalse(polja.Contains(new Polje(2, 0)));
            Assert.IsFalse(polja.Contains(new Polje(2, 1)));
            Assert.IsFalse(polja.Contains(new Polje(5, 1)));
            Assert.IsFalse(polja.Contains(new Polje(5, 0)));
        }

        [TestMethod]
        public void ČistačPolja_UklanjaBrodskaIOkolnaPoljaZaBrodUzDesniRubMreže()
        {
            Mreža mreža = new Mreža(10, 10);
            List<Polje> brodskaPolja = new List<Polje>
            {
                new Polje(9, 3), new Polje(9, 4)
            };
            ČistačPolja e = new ČistačPolja(mreža);
            e.Ukloni(brodskaPolja);
            IEnumerable<Polje> polja = mreža.RaspoloživaPolja;
            Assert.AreEqual(92, polja.Count());
            // prvo provjerimo brodska polja:
            Assert.IsFalse(polja.Contains(new Polje(9, 3)));
            Assert.IsFalse(polja.Contains(new Polje(9, 4)));
            // potom provjerimo okolna polja (samo u uglovima):
            Assert.IsFalse(polja.Contains(new Polje(8, 2)));
            Assert.IsFalse(polja.Contains(new Polje(9, 2)));
            Assert.IsFalse(polja.Contains(new Polje(8, 5)));
            Assert.IsFalse(polja.Contains(new Polje(9, 5)));
        }

        [TestMethod]
        public void ČistačPolja_UklanjaBrodskaIOkolnaPoljaZaBrodUzDonjiRubMreže()
        {
            Mreža mreža = new Mreža(10, 10);
            List<Polje> brodskaPolja = new List<Polje>
            {
                new Polje(5, 7), new Polje(5, 8), new Polje(5, 9)
            };
            ČistačPolja e = new ČistačPolja(mreža);
            e.Ukloni(brodskaPolja);
            IEnumerable<Polje> polja = mreža.RaspoloživaPolja;
            Assert.AreEqual(88, polja.Count());
            // prvo provjerimo brodska polja:
            Assert.IsFalse(polja.Contains(new Polje(5, 7)));
            Assert.IsFalse(polja.Contains(new Polje(5, 8)));
            Assert.IsFalse(polja.Contains(new Polje(5, 9)));
            // potom provjerimo okolna polja (samo u uglovima):
            Assert.IsFalse(polja.Contains(new Polje(4, 6)));
            Assert.IsFalse(polja.Contains(new Polje(4, 9)));
            Assert.IsFalse(polja.Contains(new Polje(6, 6)));
            Assert.IsFalse(polja.Contains(new Polje(6, 9)));
        }

        [TestMethod]
        public void ČistačPolja_UklanjaBrodskaIOkolnaPoljaZaBrodUzLijeviRubMreže()
        {
            Mreža mreža = new Mreža(10, 10);
            List<Polje> brodskaPolja = new List<Polje>
            {
                new Polje(0, 5), new Polje(1, 5)
            };
            ČistačPolja e = new ČistačPolja(mreža);
            e.Ukloni(brodskaPolja);
            IEnumerable<Polje> polja = mreža.RaspoloživaPolja;
            Assert.AreEqual(91, polja.Count());
            // prvo provjerimo brodska polja:
            Assert.IsFalse(polja.Contains(new Polje(0, 5)));
            Assert.IsFalse(polja.Contains(new Polje(1, 5)));
            // potom provjerimo okolna polja (samo u uglovima):
            Assert.IsFalse(polja.Contains(new Polje(0, 4)));
            Assert.IsFalse(polja.Contains(new Polje(2, 4)));
            Assert.IsFalse(polja.Contains(new Polje(0, 6)));
            Assert.IsFalse(polja.Contains(new Polje(2, 6)));
        }

        [TestMethod]
        public void ČistačPolja_UklanjaBrodskaIOkolnaPoljaZaBrodULijevomGornjemKutu()
        {
            Mreža mreža = new Mreža(10, 10);
            List<Polje> brodskaPolja = new List<Polje>
            {
                new Polje(0, 0), new Polje(1, 0)
            };
            ČistačPolja e = new ČistačPolja(mreža);
            e.Ukloni(brodskaPolja);
            IEnumerable<Polje> polja = mreža.RaspoloživaPolja;
            Assert.AreEqual(94, polja.Count());
            // prvo provjerimo brodska polja:
            Assert.IsFalse(polja.Contains(new Polje(0, 0)));
            Assert.IsFalse(polja.Contains(new Polje(1, 0)));
            // potom provjerimo okolna polja (samo u uglovima):
            Assert.IsFalse(polja.Contains(new Polje(0, 1)));
            Assert.IsFalse(polja.Contains(new Polje(2, 1)));
            Assert.IsFalse(polja.Contains(new Polje(2, 0)));
        }

        [TestMethod]
        public void ČistačPolja_UklanjaBrodskaIOkolnaPoljaZaBrodUDesnomDonjemKutu()
        {
            Mreža mreža = new Mreža(10, 10);
            List<Polje> brodskaPolja = new List<Polje>
            {
                new Polje(8, 9), new Polje(9, 9)
            };
            ČistačPolja e = new ČistačPolja(mreža);
            e.Ukloni(brodskaPolja);
            IEnumerable<Polje> polja = mreža.RaspoloživaPolja;
            Assert.AreEqual(94, polja.Count());
            // prvo provjerimo brodska polja:
            Assert.IsFalse(polja.Contains(new Polje(9, 8)));
            Assert.IsFalse(polja.Contains(new Polje(9, 9)));
            // potom provjerimo okolna polja (samo u uglovima):
            Assert.IsFalse(polja.Contains(new Polje(7, 9)));
            Assert.IsFalse(polja.Contains(new Polje(7, 8)));
            Assert.IsFalse(polja.Contains(new Polje(9, 8)));
        }
    }
}
