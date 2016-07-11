// "IzbornikPoljaZaBrod.cs" u projekzu "PotapanjeBrodova"
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotapanjeBrodova
{
    public class TražilicaNizovaPolja
    {
        public IEnumerable<IEnumerable<Polje>> DajNizovePolja(IEnumerable<Polje> raspoloživaPolja, int duljina)
        {
            List<List<Polje>> nizovi = new List<List<Polje>>();
            nizovi.AddRange(DajHorizontalneNizovePolja(raspoloživaPolja, duljina));
            nizovi.AddRange(DajVertikalneNizovePolja(raspoloživaPolja, duljina));
            return nizovi;
        }

        private List<List<Polje>> DajHorizontalneNizovePolja(IEnumerable<Polje> raspoloživa, int duljina)
        {
            List<List<Polje>> nizovi = new List<List<Polje>>();
            foreach (Polje početno in raspoloživa)
            {
                List<Polje> polja = DajPoljaDesno(početno, raspoloživa, duljina);
                if (polja.Count > 0)
                    nizovi.Add(polja);
            }
            return nizovi;
        }

        private List<List<Polje>> DajVertikalneNizovePolja(IEnumerable<Polje> raspoloživa, int duljina)
        {
            List<List<Polje>> nizovi = new List<List<Polje>>();
            foreach (Polje početno in raspoloživa)
            {
                List<Polje> polja = DajPoljaIspod(početno, raspoloživa, duljina);
                if (polja.Count > 0)
                    nizovi.Add(polja);
            }
            return nizovi;
        }

        private List<Polje> DajPoljaDesno(Polje polje, IEnumerable<Polje> raspoloživa, int duljina)
        {
            List<Polje> polja = new List<Polje> { polje };
            int redak = polje.Redak;
            int stupac = polje.Stupac;
            for (int s = stupac + 1; s < stupac + duljina; ++s)
            {
                Polje nađeno = raspoloživa.FirstOrDefault(p => p.Redak == redak && p.Stupac == s);
                if (nađeno == null)
                    return new List<Polje>();
                polja.Add(nađeno);
            }
            return polja;
        }

        private List<Polje> DajPoljaIspod(Polje polje, IEnumerable<Polje> raspoloživa, int duljina)
        {
            List<Polje> polja = new List<Polje> { polje };
            int redak = polje.Redak;
            int stupac = polje.Stupac;
            for (int r = redak + 1; r < redak + duljina; ++r)
            {
                Polje nađeno = raspoloživa.FirstOrDefault(p => p.Redak == r && p.Stupac == stupac);
                if (nađeno == null)
                    return new List<Polje>();
                polja.Add(nađeno);
            }
            return polja;
        }

    }
}
