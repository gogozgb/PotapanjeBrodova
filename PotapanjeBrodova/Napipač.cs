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
            // za svaki slučaj: zadnjeGađano mora biti null
            Debug.Assert(zadnjeGađano == null);

            var kandidati = DajKandidate();
            int izbor = slučajni.Next(kandidati.Count());
            zadnjeGađano = kandidati.ElementAt(izbor);
            mreža.UkloniPolje(zadnjeGađano.Redak, zadnjeGađano.Stupac);
            return zadnjeGađano;
        }

        public void EvidentirajRezultat(RezultatGađanja rezultat)
        {
            // Napipač smije evidentirati samo jedno polje:
            Debug.Assert(pogođenaPolja.Count == 0);

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
            // sve nizove polja pretvara u jedinstvenu listu
            return tražilica.DajNizovePolja(duljinaBroda).SelectMany(polje => polje);
        }

        private readonly Mreža mreža;
        private readonly int duljinaBroda;
        private Polje zadnjeGađano;
        private readonly List<Polje> pogođenaPolja = new List<Polje>();
        private readonly TražilicaNizovaPolja tražilica;
        private readonly Random slučajni = new Random();
    }
}
