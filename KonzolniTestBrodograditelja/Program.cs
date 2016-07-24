using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PotapanjeBrodova;

namespace KonzolniTestBrodograditelja
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; ; ++i)
                {
                    int redaka = 10;
                    int stupaca = 10;
                    int[] duljineBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };

                    Brodograditelj b = new Brodograditelj();
                    Flota flota = b.SložiFlotu(redaka, stupaca, duljineBrodova);
                    Console.WriteLine(i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
