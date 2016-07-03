// "TestMreže.cs" u projektu "TestPotapanjaBrodova"
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestMreže
    {
        [TestMethod]
        public void Mreža_DajRaspoloživaPolja_NaPočetkuVraćaSvaPolja()
        {
            Mreža m = new Mreža(5, 5);
            IEnumerable<Polje> polja = m.DajRaspoloživaPolja();
            Assert.AreEqual(25, polja.Count());
            // provjeravamo postoji li (samo jedno) polje [0, 0]
            Assert.AreEqual(1, polja.Count(p => p.Redak == 0 && p.Stupac == 0));
            // provjeravamo postoji li (samo jedno) polje [4, 4]
            Assert.AreEqual(1, polja.Count(p => p.Redak == 4 && p.Stupac == 4));
        }

        [TestMethod]
        public void Mreža_EliminirajPolje_UklanjaPoljeIzMreže()
        {
            Mreža m = new Mreža(5, 5);
            m.EliminirajPolje(1, 3);
            IEnumerable<Polje> polja = m.DajRaspoloživaPolja();
            Assert.AreEqual(24, polja.Count());
            // provjeravamo da polje [1, 3] ne postoji u listi raspoloživih polja
            Assert.AreEqual(0, polja.Count(p => p.Redak == 1 && p.Stupac == 3));
        }
    }
}
