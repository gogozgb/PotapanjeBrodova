// "Mreža.cs" u projektu "PotapanjeBrodova"
using System.Collections.Generic;
using System.Linq;

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
            return polja.DajVrijednosti();
        }

        public void EliminirajPolje(int redak, int stupac)
        {
            polja.Ukloni(redak, stupac);
        }

        private DvaDPolja polja = new DvaDPolja();

        public readonly int Redaka;
        public readonly int Stupaca;
    }
}
