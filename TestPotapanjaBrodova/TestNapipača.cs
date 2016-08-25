// "TestNapipača.cs" u projektu "TestPotapanjaBrodova"
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestNapipača
    {
        [TestMethod]
        public void Napipač_UputiPucanj_VraćaPoljeKojeMožePripadatiNajvećemBrojuBrodovaDuljine3()
        {
            Mreža mreža = new Mreža(1, 5);
            int duljinaBroda = 3;
            Napipač napipač = new Napipač(mreža, duljinaBroda);
            Polje gađanoPolje = napipač.UputiPucanj();
            Assert.AreEqual(new Polje(0, 2), gađanoPolje);
        }

        [TestMethod]
        public void Napipač_DajKandidate_VraćaPoljaKojaMoguPripadatiNajvećemBrojuBrodovaDuljine5()
        {
            Mreža mreža = new Mreža(1, 7);
            int duljinaBroda = 5;
            Napipač napipač = new Napipač(mreža, duljinaBroda);
            var kandidati = napipač.DajKandidate();
            Polje[] moguća = new Polje[] { new Polje(0, 2), new Polje(0, 3), new Polje(0, 4) };
            Assert.AreEqual(moguća.Count(), moguća.Intersect(kandidati).Count());
        }

        [TestMethod]
        public void Napipač_UputiPucanj_UklanjaGađanoPoljeIzMreže()
        {
            Mreža mreža = new Mreža(10, 10);
            int duljinaBroda = 5;
            Napipač napipač = new Napipač(mreža, duljinaBroda);
            Polje gađanoPolje = napipač.UputiPucanj();
            Assert.IsFalse(mreža.RaspoloživaPolja.Contains(gađanoPolje));
        }

        [TestMethod]
        public void Napipač_EvidentirajRezultat_DodajePogađenoPoljeMeđuPogođenaPolja()
        {
            Mreža mreža = new Mreža(10, 10);
            int duljinaBroda = 5;
            Napipač napipač = new Napipač(mreža, duljinaBroda);
            Polje gađanoPolje = napipač.UputiPucanj();
            Assert.AreEqual(0, napipač.PogođenaPolja.Count());
            napipač.EvidentirajRezultat(RezultatGađanja.Pogodak);
            Assert.IsTrue(napipač.PogođenaPolja.Contains(gađanoPolje));
        }

        [TestMethod]
        public void Napipač_EvidentirajRezultat_DodajePotopljenoPoljeMeđuPogođenaPolja()
        {
            Mreža mreža = new Mreža(10, 10);
            int duljinaBroda = 5;
            Napipač napipač = new Napipač(mreža, duljinaBroda);
            Polje gađanoPolje = napipač.UputiPucanj();
            Assert.AreEqual(0, napipač.PogođenaPolja.Count());
            napipač.EvidentirajRezultat(RezultatGađanja.Potonuće);
            Assert.IsTrue(napipač.PogođenaPolja.Contains(gađanoPolje));
        }

        [TestMethod]
        public void Napipač_EvidentirajRezultat_NeDodajePromašajMeđuPogođenaPolja()
        {
            Mreža mreža = new Mreža(10, 10);
            int duljinaBroda = 5;
            Napipač napipač = new Napipač(mreža, duljinaBroda);
            Polje gađanoPolje = napipač.UputiPucanj();
            Assert.AreEqual(0, napipač.PogođenaPolja.Count());
            napipač.EvidentirajRezultat(RezultatGađanja.Promašaj);
            Assert.IsFalse(napipač.PogođenaPolja.Contains(gađanoPolje));
        }
    }
}
