using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestKružnogPucača
    {
        [TestMethod]
        public void KružniPucač_DajKandidate_VraćaSvaOkolnaPoljaAkoSuDuljineNizovaUNastavkuVećeOdDuljineBroda()
        {
            Mreža mreža = new Mreža(10, 10);
            Polje pogođenoPolje = new Polje(2, 2);
            KružniPucač pucač = new KružniPucač(mreža, 3, pogođenoPolje);
            IEnumerable<Polje> kandidati = pucač.DajKandidate();
            Assert.AreEqual(4, kandidati.Count());
            Assert.IsTrue(kandidati.Contains(new Polje(2, 1)));
            Assert.IsTrue(kandidati.Contains(new Polje(3, 2)));
            Assert.IsTrue(kandidati.Contains(new Polje(2, 3)));
            Assert.IsTrue(kandidati.Contains(new Polje(1, 2)));
        }

        [TestMethod]
        public void KružniPucač_DajKandidate_VraćaSamoPoljeUSmjeruUKojemJeDuljinaNizaVećaOdDuljineBroda()
        {
            Mreža mreža = new Mreža(10, 10);
            // simuliramo potpoljeni brod lijevo
            mreža.UkloniPolje(6, 8);
            Polje pogođenoPolje = new Polje(8, 8);
            KružniPucač pucač = new KružniPucač(mreža, 3, pogođenoPolje);
            IEnumerable<Polje> kandidati = pucač.DajKandidate();
            Assert.AreEqual(1, kandidati.Count());
            Assert.IsTrue(kandidati.Contains(new Polje(8, 7)));
        }

        [TestMethod]
        public void KružniPucač_DajKandidate_VraćaPoljaUNajduljemSmjeruAkoSuDuljineNizovaManjeOdDuljineBroda()
        {
            Mreža mreža = new Mreža(10, 10);
            // simuliramo potpoljeni brod desno i ispod
            mreža.UkloniPolje(2, 4);
            mreža.UkloniPolje(4, 2);
            Polje pogođenoPolje = new Polje(2, 2);
            KružniPucač pucač = new KružniPucač(mreža, 4, pogođenoPolje);
            IEnumerable<Polje> kandidati = pucač.DajKandidate();
            Assert.AreEqual(2, kandidati.Count());
            Assert.IsTrue(kandidati.Contains(new Polje(1, 2)));
            Assert.IsTrue(kandidati.Contains(new Polje(2, 1)));
        }
    }
}
