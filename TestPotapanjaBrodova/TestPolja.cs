// "TestPolja.cs" u projektu "TestPotapanjaBrodova"
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestPolja
    {
        [TestMethod]
        public void Polje_RedakIStupacJednakiSuArgumentimaKonstruktora()
        {
            Polje p = new Polje(1, 2);
            Assert.AreEqual(1, p.Redak);
            Assert.AreEqual(2, p.Stupac);
        }
    }
}
