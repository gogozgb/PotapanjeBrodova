// "TestTražilice
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestTražilicePoljaZaBrod
    {
    [TestMethod]
    public void TražilicaPoljaZaBrod_Vraća2NizaDuljine3ZaHorizontalniNiz4Polja()
    {
        Mreža m = new Mreža(1, 4);
        int duljinaBroda = 3;
        TražilicaPoljaZaBrod pp = new TražilicaPoljaZaBrod(m);
        var nizovi = pp.DajNizovePolja(duljinaBroda);
        Assert.AreEqual(2, nizovi.Count());
        // svi nizovi moraju biti duljine jednake duljini broda
        Assert.AreEqual(true, nizovi.All(n => n.Count() == duljinaBroda));
        // polje [0, 0] smije se pojaviti samo jednom
        Assert.AreEqual(1, nizovi.Count(n => n.Count(p => p.Redak == 0 && p.Stupac == 0) == 1));
        // polje [0, 1] mora se pojaviti dva puta
        Assert.AreEqual(2, nizovi.Count(n => n.Count(p => p.Redak == 0 && p.Stupac == 1) == 1));
        // polje [0, 2] mora se pojaviti dva puta
        Assert.AreEqual(2, nizovi.Count(n => n.Count(p => p.Redak == 0 && p.Stupac == 2) == 1));
        // polje [0, 3] smije se pojaviti samo jednom
        Assert.AreEqual(1, nizovi.Count(n => n.Count(p => p.Redak == 0 && p.Stupac == 3) == 1));
    }

        [TestMethod]
        public void TražilicaPoljaZaBrod_Vraća3NizaDuljine3ZaVertikalniNiz5Polja()
        {
            Mreža m = new Mreža(5, 1);
            int duljinaBroda = 3;
            TražilicaPoljaZaBrod pp = new TražilicaPoljaZaBrod(m);
            var nizovi = pp.DajNizovePolja(duljinaBroda);
            Assert.AreEqual(3, nizovi.Count());
            // svi nizovi moraju biti duljine jednake duljini broda
            Assert.AreEqual(true, nizovi.All(n => n.Count() == duljinaBroda));
            // polje [0, 0] smije se pojaviti samo jednom
            Assert.AreEqual(1, nizovi.Count(n => n.Count(p => p.Redak == 0 && p.Stupac == 0) == 1));
            // polje [1, 0] mora se pojaviti dva puta
            Assert.AreEqual(2, nizovi.Count(n => n.Count(p => p.Redak == 1 && p.Stupac == 0) == 1));
            // polje [2, 0] mora se pojaviti tri puta
            Assert.AreEqual(3, nizovi.Count(n => n.Count(p => p.Redak == 2 && p.Stupac == 0) == 1));
            // polje [3, 0] smije se pojaviti dva puta
            Assert.AreEqual(2, nizovi.Count(n => n.Count(p => p.Redak == 3 && p.Stupac == 0) == 1));
            // polje [4, 0] smije se pojaviti samo jednom
            Assert.AreEqual(1, nizovi.Count(n => n.Count(p => p.Redak == 4 && p.Stupac == 0) == 1));
        }
    }
}
