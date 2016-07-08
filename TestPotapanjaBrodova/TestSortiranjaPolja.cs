﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace TestPotapanjaBrodova
{
    [TestClass]
    public class TestSortiranjaPolja
    {
        [TestMethod]
        public void Sortiraj_ZaNizVertikalnihPoljaNajgornjePoljePostajePrvo()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(4, 3),
                new Polje(5, 3),
                new Polje(3, 3)
            };
            IEnumerable<Polje> sortirana = polja.Sortiraj();
            Assert.AreEqual(3, sortirana.First().Redak);
            Assert.AreEqual(5, sortirana.Last().Redak);
        }

        [TestMethod]
        public void Sortiraj_ZaNizHorizontalnihPoljaNajljevijePoljePostajePrvo()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(3, 4),
                new Polje(3, 5),
                new Polje(3, 3)
            };
            IEnumerable<Polje> sortirana = polja.Sortiraj();
            Assert.AreEqual(3, sortirana.First().Stupac);
            Assert.AreEqual(5, sortirana.Last().Stupac);
        }
    }
}