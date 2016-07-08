using System.Collections.Generic;
using System.Linq;

namespace PotapanjeBrodova
{
    public static class Proširenja
    {
        public static IEnumerable<Polje> Sortiraj(this IEnumerable<Polje> polja)
        {
            return polja.OrderBy(p => p.Redak + p.Stupac);
        }
    }
}
