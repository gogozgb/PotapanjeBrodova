// "Mreža.cs" u projektu "PotapanjeBrodova"
using System.Collections.Generic;
using System.Linq;

namespace PotapanjeBrodova
{
    public class Mreža
    {
        public Mreža(int redaka, int stupaca)
        {
            Redaka = redaka;
            Stupaca = stupaca;
            polja = new Polje[Redaka, Stupaca];
            for (int r = 0; r < Redaka; ++r)
            {
                for (int s = 0; s < Stupaca; ++s)
                    polja[r, s] = new Polje(r, s);
            }
        }

        public IEnumerable<Polje> DajRaspoloživaPolja()
        {
            List<Polje> raspoloživa = new List<Polje>();
            foreach (Polje p in polja)
            {
                if (p != null)
                    raspoloživa.Add(p);
            }
            return raspoloživa;
        }

        public void EliminirajPolje(int redak, int stupac)
        {
            polja[redak, stupac] = null;
        }

        private Polje[,] polja;

        public readonly int Redaka;
        public readonly int Stupaca;
    }
}
