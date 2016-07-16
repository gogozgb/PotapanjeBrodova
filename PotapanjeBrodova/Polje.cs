// "Polje.cs" u projektu "PotapanjeBrodova"
using System;

namespace PotapanjeBrodova
{
    public class Polje : IEquatable<Polje>
    {
        public Polje(int redak, int stupac)
        {
            Redak = redak;
            Stupac = stupac;
        }

        // tipski sigurna metoda Equals:
        public bool Equals(Polje drugo)
        {
            if (drugo == null)
                return false;
            return Redak == drugo.Redak && Stupac == drugo.Stupac;
        }

        // tipski nesigurna metoda Equals:
        public override bool Equals(object drugi)
        {
            if (drugi == null)
                return false;
            if (GetType() != drugi.GetType())
                return false;
            // poziva tipski sigurnu izvedbu: 
            return Equals((Polje)drugi);
        }

        public readonly int Redak;
        public readonly int Stupac;
    }
}
