﻿namespace PotapanjeBrodova
{
    public enum RezultatGađanja
    {
        Promašaj,
        Pogodak,
        Potonuće
    }

    public interface IGađani
    {
        RezultatGađanja Gađaj(Polje p);
    }
}
