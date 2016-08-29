// "IzbornikPoljaZaBrod.cs" u projektu "PotapanjeBrodova"
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PotapanjeBrodova
{
    // skraćeni sinonimi
    using NizoviPolja = IEnumerable<IEnumerable<Polje>>;
    using ListePolja = List<IEnumerable<Polje>>;
    using JesuLiUNizu = Func<Polje, Polje, bool>;
    using DovoljanOdmak = Func<Polje, Polje, bool>;

    public enum Smjer
    {
        Gore,
        Desno,
        Dolje,
        Lijevo
    }

    public class TražilicaNizovaPolja
    {
        public TražilicaNizovaPolja(Mreža mreža)
        {
            this.mreža = mreža;
        }

        public NizoviPolja DajNizovePolja(int duljina)
        {
            return DajNizove(duljina, JeLiDesno, DovoljnoOdmaknutoOdNajdesnijeg)
                .Concat(DajNizove(duljina, JeLiDolje, DovoljnoOdmaknutoOdNajdonjeg));
        }

        public IEnumerable<Polje> DajPoljaDo(Polje polje, int najvišePolja, Smjer smjer)
        {
            switch (smjer)
            {
                case Smjer.Gore:
                    return PoljaUNastavku(polje, najvišePolja, JeLiIznad);
                case Smjer.Desno:
                    return PoljaUNastavku(polje, najvišePolja, JeLiDesno);
                case Smjer.Dolje:
                    return PoljaUNastavku(polje, najvišePolja, JeLiDolje);
                case Smjer.Lijevo:
                    return PoljaUNastavku(polje, najvišePolja, JeLiLijevo);
            }
            throw new ArgumentOutOfRangeException("Nepodržani smjer.");
        }

        private NizoviPolja DajNizove(int duljina, JesuLiUNizu jeLiUNizu, DovoljanOdmak dovoljnoOdmaknuto)
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
                    List<Polje> poljaUNizu = new List<Polje> { početno };
                    poljaUNizu.AddRange(PoljaUNastavku(početno, duljina - 1, jeLiUNizu));
                    if (poljaUNizu.Count() == duljina)
                        liste.Add(poljaUNizu);
                }
            }
            return liste;
        }

        private List<Polje> PoljaUNastavku(Polje polje, int najvišePolja, JesuLiUNizu jeLiUNizu)
        {
            List<Polje> polja = new List<Polje>();
            while (najvišePolja-- > 0)
            {
                polje = mreža.RaspoloživaPolja.FirstOrDefault(p => jeLiUNizu(p, polje));
                if (polje == null)
                    break;
                polja.Add(polje);
            }
            return polja;
        }

        bool JeLiDesno(Polje polje, Polje prethodno)
        {
            return polje.Redak == prethodno.Redak && polje.Stupac == prethodno.Stupac + 1;
        }

        bool JeLiDolje(Polje polje, Polje prethodno)
        {
            return polje.Redak == prethodno.Redak + 1 && polje.Stupac == prethodno.Stupac;
        }

        bool JeLiLijevo(Polje polje, Polje prethodno)
        {
            return polje.Redak == prethodno.Redak && polje.Stupac == prethodno.Stupac - 1;
        }

        bool JeLiIznad(Polje polje, Polje prethodno)
        {
            return polje.Redak == prethodno.Redak - 1 && polje.Stupac == prethodno.Stupac;
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
