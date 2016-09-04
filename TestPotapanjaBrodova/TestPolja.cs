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
            Polje p = new Polje(2, 1);
            Assert.AreEqual(2, p.Stupac);
            Assert.AreEqual(1, p.Redak);
        }
    }
}
