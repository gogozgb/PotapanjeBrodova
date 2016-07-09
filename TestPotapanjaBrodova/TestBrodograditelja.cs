// "TestBrodograditelja.cs" u projektu "TestPotapanjaBrodova"
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestBrodograditelja
    {
        [TestMethod]
        public void Brodograditelj_SložiFlotu_VraćaFlotuSaBrodovimaZadanihDuljina()
        {
            int redaka = 10;
            int stupaca = 10;
            int[] duljineBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };

            Brodograditelj b = new Brodograditelj();
            Flota flota = b.SložiFlotu(redaka, stupaca, duljineBrodova);

            IEnumerable<Brod> brodovi = flota.Brodovi;
            Assert.AreEqual(10, brodovi.Count());
            // provjerimo koliko je brodova zadane duljine
            Assert.AreEqual(1, brodovi.Count(brod => brod.Polja.Count() == 5));
            Assert.AreEqual(2, brodovi.Count(brod => brod.Polja.Count() == 4));
            Assert.AreEqual(3, brodovi.Count(brod => brod.Polja.Count() == 3));
            Assert.AreEqual(4, brodovi.Count(brod => brod.Polja.Count() == 2));
        }
    }
}
