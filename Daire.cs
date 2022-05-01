using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAlmak
{
    internal class Daire : Ev
    {
        public Daire(string cephe, int banyo, bool kat, int balkon) : base(cephe, banyo, balkon, kat)
        {
            Console.Write("Evin hangı cephe'de olsun (güney/kozey)? ");

            Console.Write("Evinde kaç tane banyo var? ");

            Console.Write("Evin kaç katli olsun? ");

            Console.Write("Evin kaç tane balkon var?");

        }

        public double DaireFiyatHesaplama()
        {
            double EvGenelFiyatHesapla = EvGenelFiyatHesaplama();

            return
        }
    }
}
