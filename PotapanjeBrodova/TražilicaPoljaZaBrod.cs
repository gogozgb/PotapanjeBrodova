// "IzbornikPoljaZaBrod.cs" u projekzu "PotapanjeBrodova"
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotapanjeBrodova
{
    public class TražilicaPoljaZaBrod
    {
        public TražilicaPoljaZaBrod(Mreža mreža)
        {
            this.mreža = mreža;
        }

        public IEnumerable<IEnumerable<Polje>> DajNizovePolja(int duljinaBroda)
        {
            List<List<Polje>> nizovi = new List<List<Polje>>();
            nizovi.AddRange(DajHorizontalneNizovePolja(duljinaBroda));
            nizovi.AddRange(DajVertikalneNizovePolja(duljinaBroda));
            return nizovi;
        }

        private List<List<Polje>> DajHorizontalneNizovePolja(int duljinaBroda)
        {
            List<List<Polje>> nizovi = new List<List<Polje>>();
            IEnumerable<Polje> slobodnaPolja = mreža.DajRaspoloživaPolja();
            foreach (Polje početno in slobodnaPolja)
            {
                List<Polje> polja = DajPoljaDesno(početno, duljinaBroda);
                if (polja.Count > 0)
                    nizovi.Add(polja);
            }
            return nizovi;
        }

        private List<List<Polje>> DajVertikalneNizovePolja(int duljinaBroda)
        {
            List<List<Polje>> nizovi = new List<List<Polje>>();
            IEnumerable<Polje> slobodnaPolja = mreža.DajRaspoloživaPolja();
            foreach (Polje početno in slobodnaPolja)
            {
                List<Polje> polja = DajPoljaIspod(početno, duljinaBroda);
                if (polja.Count > 0)
                    nizovi.Add(polja);
            }
            return nizovi;
        }

        private List<Polje> DajPoljaDesno(Polje polje, int duljinaBroda)
        {
            List<Polje> polja = new List<Polje> { polje };
            int redak = polje.Redak;
            int stupac = polje.Stupac;
            IEnumerable<Polje> slobodna = mreža.DajRaspoloživaPolja();
            for (int s = stupac + 1; s < stupac + duljinaBroda; ++s)
            {
                Polje nađeno = slobodna.FirstOrDefault(p => p.Redak == redak && p.Stupac == s);
                if (nađeno == null)
                    return new List<Polje>();
                polja.Add(nađeno);
            }
            return polja;
        }

        private List<Polje> DajPoljaIspod(Polje polje, int duljinaBroda)
        {
            List<Polje> polja = new List<Polje> { polje };
            int redak = polje.Redak;
            int stupac = polje.Stupac;
            IEnumerable<Polje> slobodna = mreža.DajRaspoloživaPolja();
            for (int r = redak + 1; r < redak + duljinaBroda; ++r)
            {
                Polje nađeno = slobodna.FirstOrDefault(p => p.Redak == r && p.Stupac == stupac);
                if (nađeno == null)
                    return new List<Polje>();
                polja.Add(nađeno);
            }
            return polja;
        }

        private Mreža mreža;
    }
}
