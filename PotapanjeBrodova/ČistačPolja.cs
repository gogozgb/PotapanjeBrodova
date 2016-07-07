using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotapanjeBrodova
{
    public class ČistačPolja
    {
        public ČistačPolja(Mreža mreža)
        {
            this.mreža = mreža;
        }

        public void Ukloni(IEnumerable<Polje> brodskaPolja)
        {
            throw new NotImplementedException();
        }

        private Mreža mreža;
    }
}
