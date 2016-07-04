// 'Brod.cs' u projektu 'PotapanjeBrodova'
using System.Collections.Generic;

namespace PotapanjeBrodova
{
    public class Brod
    {
        public Brod(IEnumerable<Polje> polja)
        {
            Polja = polja;
        }

        public readonly IEnumerable<Polje> Polja;
    }
}
