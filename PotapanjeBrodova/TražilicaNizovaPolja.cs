// "IzbornikPoljaZaBrod.cs" u projekzu "PotapanjeBrodova"
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotapanjeBrodova
{
    // skraćeni sinonimi
    using NizoviPolja = IEnumerable<IEnumerable<Polje>>;
    using ListePolja = List<IEnumerable<Polje>>;
    using PopisPolja = Func<Polje, int, IEnumerable<Polje>>;

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

        private NizoviPolja DajNizove(int duljina, PopisPolja traženaPolja, Func<Polje, int, bool> dovoljnoOdmaknuto)
        {
            ListePolja liste = new ListePolja();
            foreach (Polje početno in raspoloživaPolja)
            {
                if (dovoljnoOdmaknuto(početno, duljina - 1))
                {
                    List<Polje> polja = new List<Polje> { početno };
                    polja.AddRange(raspoloživaPolja.Intersect(traženaPolja(početno, duljina)));
                    if (polja.Count() == duljina)
                        liste.Add(polja);
                }
            }
            return liste;
        }

        private IEnumerable<Polje> PoljaDesno(Polje polje, int duljina)
        {
            List<Polje> polja = new List<Polje>();
            int stupac = polje.Stupac;
            for (int s = stupac + 1; s < stupac + duljina; ++s)
                polja.Add(new Polje(polje.Redak, s));
            return polja;
        }

        private IEnumerable<Polje> PoljaDolje(Polje polje, int duljina)
        {
            List<Polje> polja = new List<Polje>();
            int redak = polje.Redak;
            for (int r = redak + 1; r < redak + duljina; ++r)
                polja.Add(new Polje(r, polje.Stupac));
            return polja;
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
