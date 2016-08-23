using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestNapipača
    {
        [TestMethod]
        public void Napipač_UputiPucanj_VraćaPoljeKojeMožePripadatiNajvećemBrojuBrodovaDuljine3()
        {
            Mreža m = new Mreža(1, 5);
            int duljinaBroda = 3;
            Napipač n = new Napipač(m, duljinaBroda);
            Polje p = n.UputiPucanj();
            Assert.AreEqual(new Polje(0, 2), p);
        }

        [TestMethod]
        public void Napipač_UputiPucanj_VraćaJednoOd3PoljaKojeMožePripadatiNajvećemBrojuBrodovaDuljine5()
        {
            Mreža m = new Mreža(1, 8);
            int duljinaBroda = 5;
            Napipač n = new Napipač(m, duljinaBroda);
            Polje p = n.UputiPucanj();
            Polje[] moguća = new Polje[] { new Polje(0, 3), new Polje(0, 4), new Polje(0, 5) };
            Assert.IsTrue(moguća.Contains(p));
        }

        [TestMethod]
        public void Napipač_EvidentirajRezultat_UklanjaGađanoPoljeIzMrežeZaPromašaj()
        {
            Mreža m = new Mreža(10, 10);
            int duljinaBroda = 5;
            Napipač n = new Napipač(m, duljinaBroda);
            Polje gađanoPolje = n.UputiPucanj();
            Assert.IsTrue(m.RaspoloživaPolja.Contains(gađanoPolje));
            n.EvidentirajRezultat(RezultatGađanja.Promašaj);
            Assert.IsFalse(m.RaspoloživaPolja.Contains(gađanoPolje));
        }

        [TestMethod]
        public void Napipač_EvidentirajRezultat_UklanjaGađanoPoljeIzMrežeZaPogodak()
        {
            Mreža m = new Mreža(10, 10);
            int duljinaBroda = 5;
            Napipač n = new Napipač(m, duljinaBroda);
            Polje gađanoPolje = n.UputiPucanj();
            Assert.IsTrue(m.RaspoloživaPolja.Contains(gađanoPolje));
            n.EvidentirajRezultat(RezultatGađanja.Pogodak);
            Assert.IsFalse(m.RaspoloživaPolja.Contains(gađanoPolje));
        }

        [TestMethod]
        public void Napipač_EvidentirajRezultat_UklanjaGađanoPoljeIzMrežeZaPotonuće()
        {
            Mreža m = new Mreža(10, 10);
            int duljinaBroda = 5;
            Napipač n = new Napipač(m, duljinaBroda);
            Polje gađanoPolje = n.UputiPucanj();
            Assert.IsTrue(m.RaspoloživaPolja.Contains(gađanoPolje));
            n.EvidentirajRezultat(RezultatGađanja.Potonuće);
            Assert.IsFalse(m.RaspoloživaPolja.Contains(gađanoPolje));
        }

        [TestMethod]
        public void Napipač_EvidentirajRezultat_DodajePogađenoPoljeMeđuPogođenaPolja()
        {
            Mreža m = new Mreža(10, 10);
            int duljinaBroda = 5;
            Napipač n = new Napipač(m, duljinaBroda);
            Polje gađanoPolje = n.UputiPucanj();
            Assert.AreEqual(0, n.PogođenaPolja.Count());
            n.EvidentirajRezultat(RezultatGađanja.Pogodak);
            Assert.IsTrue(n.PogođenaPolja.Contains(gađanoPolje));
        }
    }
}
