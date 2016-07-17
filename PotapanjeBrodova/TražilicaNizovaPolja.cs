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
            najdesnijiStupac = raspoloživaPolja.Max(p => p.Stupac);
            najdonjiRedak = raspoloživaPolja.Max(p => p.Redak);
        }

        public NizoviPolja DajNizovePolja(int duljina)
        {
            return DajNizove(duljina, PoljaDesno, DovoljnoOdmaknutoOdNajdesnijeg)
                .Concat(DajNizove(duljina, PoljaDolje, DovoljnoOdmaknutoOdNajdonjeg));
        }

        private ListePolja DajNizove(int duljina, IteratorPolja traženaPolja, Func<Polje, int, bool> dovoljnoOdmaknuto)
        {
            ListePolja liste = new ListePolja();
            foreach (Polje početno in raspoloživaPolja)
            {
                if (dovoljnoOdmaknuto(početno, duljina - 1))
                {
                    List<Polje> polja = PoljaUNizu(početno, duljina, traženaPolja);
                    if (polja.Count == duljina)
                        liste.Add(polja);
                }
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

        private bool DovoljnoOdmaknutoOdNajdesnijeg(Polje polje, int duljina)
        {
            return polje.Stupac <= najdesnijiStupac - duljina;
        }

        private bool DovoljnoOdmaknutoOdNajdonjeg(Polje polje, int duljina)
        {
            return polje.Redak <= najdonjiRedak - duljina;
        }

        private IEnumerable<Polje> raspoloživaPolja;
        private int najdesnijiStupac;
        private int najdonjiRedak;
    }
}
