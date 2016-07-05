// "Mreža.cs" u projektu "PotapanjeBrodova"
using System.Collections.Generic;
using System;

namespace PotapanjeBrodova
{
    using DvaDPolja = RječnikSDvaKljuča<int, int, Polje>;

    public class Mreža
    {
        public Mreža(int redaka, int stupaca)
        {
            Redaka = redaka;
            Stupaca = stupaca;
            for (int r = 0; r < Redaka; ++r)
            {
                for (int s = 0; s < Stupaca; ++s)
                    polja[r, s] = new Polje(r, s);
            }
        }

        public IEnumerable<Polje> DajRaspoloživaPolja()
        {
            return polja.Vrijednosti;
        }

        public void EliminirajPolje(int redak, int stupac)
        {
            if (polja.Ukloni(redak, stupac))
                return;
            if (redak < 0 || redak >= Redaka)
                throw new ArgumentOutOfRangeException(string.Format("Redak {0} je izvan dozvoljenog rapona vrijednosti", redak));
            if (stupac < 0 || stupac >= Stupaca)
                throw new ArgumentOutOfRangeException(string.Format("Stupac {0} je izvan dozvoljenog rapona vrijednosti", stupac));
        }

        private DvaDPolja polja = new DvaDPolja();

        public readonly int Redaka;
        public readonly int Stupaca;
    }
}
