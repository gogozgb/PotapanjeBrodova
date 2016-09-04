using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestSelektivnogNapipača
    {
        [TestMethod]
        public void SelektivniNapipač_UputiPucanj_VraćaPoljeKojeMožePripadatiNajvećemBrojuBrodovaDuljine3()
        {
            Mreža mreža = new Mreža(1, 5);
            int duljinaBroda = 3;
            Napipač napipač = new SelektivniNapipač(mreža, duljinaBroda);
            Polje gađanoPolje = napipač.UputiPucanj();
            Assert.AreEqual(new Polje(2, 0), gađanoPolje);
        }

        [TestMethod]
        public void SelektivniNapipač_DajKandidate_VraćaPoljaKojaMoguPripadatiNajvećemBrojuBrodovaDuljine5()
        {
            Mreža mreža = new Mreža(1, 7);
            int duljinaBroda = 5;
            Napipač napipač = new SelektivniNapipač(mreža, duljinaBroda);
            var kandidati = napipač.DajKandidate();
            Polje[] moguća = new Polje[] { new Polje(2, 0), new Polje(3, 0), new Polje(4, 0) };
            Assert.AreEqual(moguća.Count(), moguća.Intersect(kandidati).Count());
        }

    }
}
