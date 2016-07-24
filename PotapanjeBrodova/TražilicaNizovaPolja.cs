﻿// "IzbornikPoljaZaBrod.cs" u projekzu "PotapanjeBrodova"
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotapanjeBrodova
{
    // skraćeni sinonimi
    using NizoviPolja = IEnumerable<IEnumerable<Polje>>;
    using ListePolja = List<IEnumerable<Polje>>;
    using PopisPolja = Func<Polje, int, IEnumerable<Polje>>;
    using DovoljanOdmak = Func<Polje, Polje, bool>;

    public class TražilicaNizovaPolja
    {
        public NizoviPolja DajNizovePolja(IEnumerable<Polje> raspoloživa,
                                          int duljina)
        {
            return DajNizove(raspoloživa, duljina, PoljaDesno, DovoljnoOdmaknutoOdNajdesnijeg)
                .Concat(DajNizove(raspoloživa, duljina, PoljaDolje, DovoljnoOdmaknutoOdNajdonjeg));
        }

        private NizoviPolja DajNizove(IEnumerable<Polje> raspoloživa, int duljina, PopisPolja traženaPolja, DovoljanOdmak dovoljnoOdmaknuto)
        {
            int najdesnijiStupac = raspoloživa.Max(p => p.Stupac);
            int najdonjiRedak = raspoloživa.Max(p => p.Redak);
            Polje granica = new Polje(najdonjiRedak - duljina + 1, najdesnijiStupac - duljina + 1);
            ListePolja liste = new ListePolja();
            foreach (Polje početno in raspoloživa)
            {
                // dodatni uvjet kojim izbjegavamo jalova pretraživanja:
                if (dovoljnoOdmaknuto(početno, granica))
                {
                    List<Polje> polja = new List<Polje> { početno };
                    polja.AddRange(raspoloživa.Intersect(traženaPolja(početno, duljina)));
                    if (polja.Count() == duljina)
                        liste.Add(polja);
                }
            }
            return liste;
        }

        private IEnumerable<Polje> PoljaDesno(Polje polje, int duljina)
        {
            List<Polje> polja = new List<Polje>();
            int krajnjiStupac = polje.Stupac + duljina;
            for (int s = polje.Stupac + 1; s < krajnjiStupac; ++s)
                polja.Add(new Polje(polje.Redak, s));
            return polja;
        }
        // ... i ispod
        private IEnumerable<Polje> PoljaDolje(Polje polje, int duljina)
        {
            List<Polje> polja = new List<Polje>();
            int krajnjiRedak = polje.Redak + duljina;
            for (int r = polje.Redak + 1; r < krajnjiRedak; ++r)
                polja.Add(new Polje(r, polje.Stupac));
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
    }
}
