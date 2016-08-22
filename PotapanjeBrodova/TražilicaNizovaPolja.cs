// "IzbornikPoljaZaBrod.cs" u projekzu "PotapanjeBrodova"
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotapanjeBrodova
{
    // skraćeni sinonimi
    using NizoviPolja = IEnumerable<IEnumerable<Polje>>;
    using ListePolja = List<IEnumerable<Polje>>;
    using PoljaUNizu = Func<Polje, int, IEnumerable<Polje>>;
    using DovoljanOdmak = Func<Polje, Polje, bool>;
    using System.Diagnostics;

    public class TražilicaNizovaPolja
    {
        public TražilicaNizovaPolja(Mreža mreža)
        {
            this.mreža = mreža;
        }

        public NizoviPolja DajNizovePolja(int duljina)
        {
            return DajNizove(duljina, PoljaDesno, DovoljnoOdmaknutoOdNajdesnijeg)
                .Concat(DajNizove(duljina, PoljaDolje, DovoljnoOdmaknutoOdNajdonjeg));
        }

        private NizoviPolja DajNizove(int duljina, PoljaUNizu poljaUNizu, DovoljanOdmak dovoljnoOdmaknuto)
        {
            int najdesnijiStupac = mreža.RaspoloživaPolja.Max(p => p.Stupac);
            int najdonjiRedak = mreža.RaspoloživaPolja.Max(p => p.Redak);
            Polje granica = new Polje(najdonjiRedak - duljina + 1, najdesnijiStupac - duljina + 1);
            ListePolja liste = new ListePolja();
            foreach (Polje početno in mreža.RaspoloživaPolja)
            {
                // dodatni uvjet kojim izbjegavamo jalova pretraživanja:
                if (dovoljnoOdmaknuto(početno, granica))
                {
                    IEnumerable<Polje> polja = poljaUNizu(početno, duljina);
                    Debug.Assert(polja.Count() <= duljina);
                    if (polja.Count() == duljina)
                        liste.Add(polja);
                }
            }
            return liste;
        }

        private IEnumerable<Polje> PoljaDesno(Polje polje, int duljina)
        {
            List<Polje> polja = new List<Polje> { polje };
            while (--duljina > 0)
            {
                polje = mreža.RaspoloživaPolja.FirstOrDefault(p => p.Redak == polje.Redak && p.Stupac == polje.Stupac + 1);
                if (polje == null)
                    break;
                polja.Add(polje);
            }
            return polja;
        }

        private IEnumerable<Polje> PoljaDolje(Polje polje, int duljina)
        {
            List<Polje> polja = new List<Polje> { polje };
            while (--duljina > 0)
            {
                polje = mreža.RaspoloživaPolja.FirstOrDefault(p => p.Redak == polje.Redak + 1 && p.Stupac == polje.Stupac);
                if (polje == null)
                    break;
                polja.Add(polje);
            }
            return polja;
        }

        private bool DovoljnoOdmaknutoOdNajdesnijeg(Polje polje, Polje granica)
        {
            return polje.Stupac <= granica.Stupac;
        }

        private bool DovoljnoOdmaknutoOdNajdonjeg(Polje polje, Polje granica)
        {
            return polje.Redak <= granica.Redak;
        }

        private Mreža mreža;
    }
}
