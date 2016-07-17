// "Flota.cs" u projektu "PotapanjeBrodova"
using System.Collections.Generic;

namespace PotapanjeBrodova
{
    public class Flota
{
    public void DodajBrod(IEnumerable<Polje> polja)
    {
        brodovi.Add(new Brod(polja));
    }

    public IEnumerable<Brod> Brodovi
    {
        get { return brodovi; }
    }

    private List<Brod> brodovi = new List<Brod>();
}
}
