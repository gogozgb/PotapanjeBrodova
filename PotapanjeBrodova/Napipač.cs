using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PotapanjeBrodova
{
    public class Napipač : IPucač
    {
        public Napipač(Mreža mreža, int duljinaBroda)
        {
            this.mreža = mreža;
            this.duljinaBroda = duljinaBroda;
            this.tražilica = new TražilicaNizovaPolja(mreža);
        }

        public Polje UputiPucanj()
        {
            var kandidati = DajKandidate();
            int izbor = slučajni.Next(kandidati.Count());
            zadnjeGađano = kandidati.ElementAt(izbor);
            return zadnjeGađano;
        }

        public void EvidentirajRezultat(RezultatGađanja rezultat)
        {
            // Napipač smije evidentirati samo jedno polje:
            Debug.Assert(pogođenaPolja.Count == 0);

            if (rezultat != RezultatGađanja.Promašaj)
            {
                pogođenaPolja.Add(zadnjeGađano);
            }
            mreža.UkloniPolje(zadnjeGađano.Redak, zadnjeGađano.Stupac);
        }

        public IEnumerable<Polje> PogođenaPolja
        {
            get
            {
                return pogođenaPolja;
            }
        }

        private IEnumerable<Polje> DajKandidate()
        {
            var svaPolja = tražilica.DajNizovePolja(duljinaBroda).SelectMany(p => p).ToList();
            var sortiraneGrupe = svaPolja.GroupBy(polje => polje).OrderByDescending(grupa => grupa.Count());
            return sortiraneGrupe.TakeWhile(grupa => grupa.Count() == sortiraneGrupe.First().Count()).Select(grupa => grupa.Key);
        }

        private Mreža mreža;
        private int duljinaBroda;
        private Polje zadnjeGađano;
        private List<Polje> pogođenaPolja = new List<Polje>();
        private TražilicaNizovaPolja tražilica;
        private Random slučajni = new Random();
    }
}
