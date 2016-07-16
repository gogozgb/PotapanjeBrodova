// "IzbornikPoljaZaBrod.cs" u projekzu "PotapanjeBrodova"
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotapanjeBrodova
{
    // skraćeni sinonimi
    using NizoviPolja = IEnumerable<IEnumerable<Polje>>;
    using ListePolja = List<List<Polje>>;
    using IteratorPolja = Func<Polje, int, IEnumerable<Polje>>;

    public class TražilicaNizovaPolja
    {
        public TražilicaNizovaPolja(IEnumerable<Polje> raspoloživaPolja)
        {
            this.raspoloživaPolja = raspoloživaPolja;
        }

        public NizoviPolja DajNizovePolja(int duljina)
        {
            return DajNizove(duljina, PoljaDesno)
                .Concat(DajNizove(duljina, PoljaDolje));
        }

        private ListePolja DajNizove(int duljina, IteratorPolja traženaPolja)
        {
            ListePolja liste = new ListePolja();
            foreach (Polje početno in raspoloživaPolja)
            {
                List<Polje> polja = PoljaUNizu(početno, duljina, traženaPolja);
                if (polja.Count == duljina)
                    liste.Add(polja);
            }
            return liste;
        }

        private List<Polje> PoljaUNizu(Polje polje, int duljina, IteratorPolja traženaPolja)
        {
            List<Polje> polja = new List<Polje> { polje };
            foreach (Polje traženo in traženaPolja(polje, duljina))
            {
                if (raspoloživaPolja.Contains(traženo))
                    polja.Add(traženo);
            }
            return polja;
        }

        private IEnumerable<Polje> PoljaDesno(Polje polje, int duljina)
        {
            int stupac = polje.Stupac;
            for (int s = stupac + 1; s < stupac + duljina; ++s)
                yield return new Polje(polje.Redak, s);
        }

        private IEnumerable<Polje> PoljaDolje(Polje polje, int duljina)
        {
            int redak = polje.Redak;
            for (int r = redak + 1; r < redak + duljina; ++r)
                yield return new Polje(r, polje.Stupac);
        }

        private IEnumerable<Polje> raspoloživaPolja;
    }
}
