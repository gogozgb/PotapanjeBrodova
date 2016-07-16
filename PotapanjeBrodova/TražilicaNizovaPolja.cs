// "IzbornikPoljaZaBrod.cs" u projekzu "PotapanjeBrodova"
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotapanjeBrodova
{
    // skraćeni sinonimi
    using NizoviPolja = IEnumerable<IEnumerable<Polje>>;
    using ListePolja = List<List<Polje>>;

    public class TražilicaNizovaPolja
    {
        public NizoviPolja DajNizovePolja(IEnumerable<Polje> raspoloživaPolja, int duljina)
        {
            return DajHorizontalneNizove(raspoloživaPolja, duljina)
                .Concat(DajVertikalneNizove(raspoloživaPolja, duljina));
        }

        private ListePolja DajHorizontalneNizove(IEnumerable<Polje> raspoloživa, int duljina)
        {
            ListePolja liste = new ListePolja();
            foreach (Polje početno in raspoloživa)
            {
                List<Polje> polja = PoljaUdesno(početno, raspoloživa, duljina);
                if (polja.Count == duljina)
                    liste.Add(polja);
            }
            return liste;
        }

        private ListePolja DajVertikalneNizove(IEnumerable<Polje> raspoloživa, int duljina)
        {
            ListePolja liste = new ListePolja();
            foreach (Polje početno in raspoloživa)
            {
                List<Polje> polja = PoljaNadolje(početno, raspoloživa, duljina);
                if (polja.Count == duljina)
                    liste.Add(polja);
            }
            return liste;
        }

        private List<Polje> PoljaUdesno(Polje polje, IEnumerable<Polje> raspoloživa, int duljina)
        {
            List<Polje> polja = new List<Polje> { polje };
            int redak = polje.Redak;
            int stupac = polje.Stupac;
            for (int s = stupac + 1; s < stupac + duljina; ++s)
            {
                Polje nađeno = raspoloživa.FirstOrDefault(p => p.Redak == redak && p.Stupac == s);
                if (nađeno == null)
                    break;
                polja.Add(nađeno);
            }
            return polja;
        }

        private List<Polje> PoljaNadolje(Polje polje, IEnumerable<Polje> raspoloživa, int duljina)
        {
            List<Polje> polja = new List<Polje> { polje };
            int redak = polje.Redak;
            int stupac = polje.Stupac;
            for (int r = redak + 1; r < redak + duljina; ++r)
            {
                Polje nađeno = raspoloživa.FirstOrDefault(p => p.Redak == r && p.Stupac == stupac);
                if (nađeno == null)
                    break;
                polja.Add(nađeno);
            }
            return polja;
        }
    }
}
