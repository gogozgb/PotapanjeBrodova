using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PotapanjeBrodova
{
    using ListePolja = List<IEnumerable<Polje>>;

    public class KružniPucač : IPucač
    {
        public KružniPucač(Mreža mreža, int duljinaBroda, Polje pogođenoPolje)
        {
            this.mreža = mreža;
            this.duljinaBroda = duljinaBroda;
            this.tražilica = new TražilicaNizovaPolja(mreža);
            pogođenaPolja.Add(pogođenoPolje);
        }

        public Polje UputiPucanj()
        {
            Debug.Assert(zadnjeGađano == null);

            var kandidati = DajKandidate();
            int izbor = slučajni.Next(kandidati.Count());
            zadnjeGađano = kandidati.ElementAt(izbor);
            mreža.UkloniPolje(zadnjeGađano.Redak, zadnjeGađano.Stupac);
            return zadnjeGađano;
        }

        public void EvidentirajRezultat(RezultatGađanja rezultat)
        {
            if (rezultat != RezultatGađanja.Promašaj)
                pogođenaPolja.Add(zadnjeGađano);
            zadnjeGađano = null;
        }

        public IEnumerable<Polje> PogođenaPolja
        {
            get
            {
                return pogođenaPolja;
            }
        }

        public virtual IEnumerable<Polje> DajKandidate()
        {
            ListePolja nizoviPolja = new ListePolja();
            foreach (Smjer smjer in Enum.GetValues(typeof(Smjer)))
            {
                var nizPolja = tražilica.DajPoljaDo(pogođenaPolja.First(), duljinaBroda - 1, smjer);
                if (nizPolja.Count() >= 0)
                    nizoviPolja.Add(nizPolja);
            }
            // sortira po duljinama nizova
            var sortiraneGrupe = nizoviPolja.GroupBy(niz => niz).OrderByDescending(niz => niz.Count());
            // filtrira samo nizove koji su najveće duljine i vraća prve članove
            return sortiraneGrupe.TakeWhile(grupa => grupa.Key.Count() == sortiraneGrupe.First().Key.Count()).Select(grupa => grupa.Key.First());
        }

        private readonly Mreža mreža;
        private readonly int duljinaBroda;
        private Polje zadnjeGađano;
        private readonly List<Polje> pogođenaPolja = new List<Polje>();
        private readonly TražilicaNizovaPolja tražilica;
        private readonly Random slučajni = new Random();
    }
}
