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
        public void Napipač_DajKandidate_VraćaSvaPoljaKojaMoguPripadatiBrodovimaDuljine3()
        {
            Mreža mreža = new Mreža(1, 5);
            int duljinaBroda = 3;
            Napipač napipač = new Napipač(mreža, duljinaBroda);
            var kandidati = napipač.DajKandidate();
            // broj kandidata 3 broda po 3 polja:
            Assert.AreEqual(9, kandidati.Count());
            Polje[] moguća = new Polje[] { new Polje(0, 0), new Polje(0, 1), new Polje(0, 2), new Polje(0, 3), new Polje(0, 4) };
            // preko presjeka provjeravamo sadrži li lista kandidata sva moguća polja:
            Assert.IsTrue(moguća.Except(kandidati).Count() == 0 && kandidati.Except(moguća).Count() == 0);
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
