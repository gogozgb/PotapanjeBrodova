// "Brodograditelj.cs" u projektu "PotapanjeBrodova"
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotapanjeBrodova
{
    public class Brodograditelj
    {
        public Brodograditelj()
        {
            izbornik = new NasumičniIzbornikPolja();
            čistač = new ČistačPolja();
        }

        public Flota SložiFlotu(int redaka, int stupaca, IEnumerable<int> duljineBrodova)
        {
            // za svaki slučaj sortiramo duljine od najveće prema namanjoj
            duljineBrodova = duljineBrodova.OrderByDescending(d => d);
            int brojPokušaja = 5;
            for (int i = 0; i < brojPokušaja; ++i)
            {
                try
                {
                    Mreža m = new Mreža(redaka, stupaca);
                    return SložiBrodove(m, duljineBrodova);
                }
                catch (ApplicationException)
                {
                }
            }
            var poruka = string.Format("Nije uspio složiti flotu ni nakon {0} pokušaja", brojPokušaja);
            throw new ApplicationException(poruka);
        }

        private Flota SložiBrodove(Mreža mreža, IEnumerable<int> duljineBrodova)
        {
            Flota f = new Flota();
            var tražilica = new TražilicaNizovaPolja(mreža);
            foreach (int duljina in duljineBrodova)
            {
                var kandidati = tražilica.DajNizovePolja(duljina);
                if (kandidati.Count() == 0)
                    throw new ApplicationException();
                var izbor = izbornik.Izaberi(kandidati);
                f.DodajBrod(izbor);
                čistač.Ukloni(mreža, izbor);
            }
            return f;
        }

        private NasumičniIzbornikPolja izbornik;
        private ČistačPolja čistač;
    }
}
