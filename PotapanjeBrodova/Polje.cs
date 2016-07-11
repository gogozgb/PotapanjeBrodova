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

        public bool Equals(Polje drugo)
        {
            return Redak == drugo.Redak && Stupac == drugo.Stupac;
        }

        public readonly int Redak;
        public readonly int Stupac;
    }
}
