// "Mreža.cs" u projektu "PotapanjeBrodova"
using System;
using System.Collections.Generic;

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
            for (int r = 0; r < Redaka; ++r)
            {
                for (int s = 0; s < Stupaca; ++s)
                {
                    if (polja[r, s] != null)
                        raspoloživa.Add(polja[r, s]);
                }
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
