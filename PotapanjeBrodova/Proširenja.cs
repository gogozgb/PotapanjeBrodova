// "Proširenja.cs" u projektu "PotapanjeBrodova"
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotapanjeBrodova
{
    public static class Proširenja
    {
        private class VertikalnaPoravnatostPolja : IEqualityComparer<Polje>
        {
            public bool Equals(Polje x, Polje y)
            {
                return x.Stupac == y.Stupac;
            }

            public int GetHashCode(Polje obj)
            {
                return obj.Stupac.GetHashCode();
            }
        }

        private class HorizontalnaPoravnatostPolja : IEqualityComparer<Polje>
        {
            public bool Equals(Polje x, Polje y)
            {
                return x.Redak == y.Redak;
            }

            public int GetHashCode(Polje obj)
            {
                return obj.Redak.GetHashCode();
            }
        }

        public static IEnumerable<Polje> Sortiraj(this IEnumerable<Polje> polja)
        {
            if (polja.Count() <= 1)
                return polja;
            bool horizontalnoPoravnata = polja.Distinct(new HorizontalnaPoravnatostPolja()).Count() == 1;
            bool vertikalnoPoravnata = polja.Distinct(new VertikalnaPoravnatostPolja()).Count() == 1;
            if (horizontalnoPoravnata == vertikalnoPoravnata)
                throw new ArgumentException();
            return polja.OrderBy(p => p.Redak + p.Stupac);
        }
    }
}
