﻿using System;
using System.Collections.Generic;

namespace PotapanjeBrodova
{
    class RječnikSDvaKljuča<Ključ1, Ključ2, Vrijednost>
    {
        private readonly Dictionary<Tuple<Ključ1, Ključ2>, Vrijednost> rječnik = new Dictionary<Tuple<Ključ1, Ključ2>, Vrijednost>();
        // svojstvo kojim pristupamo elementima pomoću dva ključa
        public Vrijednost this[Ključ1 ključ1, Ključ2 ključ2]
        {
            get { return rječnik[new Tuple<Ključ1, Ključ2>(ključ1, ključ2)]; }
            set { rječnik[new Tuple<Ključ1, Ključ2>(ključ1, ključ2)] = value; }
        }

        public IEnumerable<Vrijednost> DajVrijednosti()
        {
            return rječnik.Values;
        }

        public void Ukloni(Ključ1 ključ1, Ključ2 ključ2)
        {
            rječnik.Remove(new Tuple<Ključ1, Ključ2>(ključ1, ključ2));
        }
    }
}
