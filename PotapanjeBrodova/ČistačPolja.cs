﻿// "ČistačPolja.cs" u projektu "PotapanjeBrodova"
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotapanjeBrodova
{
    public class ČistačPolja
    {
        public void Ukloni(Mreža mreža, IEnumerable<Polje> brodskaPolja)
        {
            brodskaPolja = brodskaPolja.Sortiraj();
            Polje prvo = brodskaPolja.First();
            int r1 = Math.Max(prvo.Redak - 1, 0);
            int s1 = Math.Max(prvo.Stupac - 1, 0);
            Polje zadnje = brodskaPolja.Last();
            int r2 = Math.Min(zadnje.Redak + 2, mreža.Redaka);
            int s2 = Math.Min(zadnje.Stupac + 2, mreža.Stupaca);
            for (int r = r1; r < r2; ++r)
            {
                for (int s = s1; s < s2; ++s)
                    mreža.UkloniPolje(r, s);
            }
        }
    }
}
