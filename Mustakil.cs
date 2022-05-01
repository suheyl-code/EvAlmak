using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAlmak
{
    internal class Mustakil : Ev
    {
        private int _bahce;
        public int Bahce
        {
            get { return _bahce; }
            set { _bahce = value; }
        }

        public Mustakil(string cephe, int banyo, 
            int balkon, bool kat, int bahce) : 
            base(cephe, banyo, balkon, kat)
        {
            this.Bahce = bahce;

            Console.Write("Evin hangı cephe'de olsun (güney/kozey)? ");

            Console.Write("Evinde kaç tane banyo var? ");

            Console.Write("Evin kaç katli olsun? ");

            Console.Write("Evin kaç tane balkon var?");
        }

        public double MustakilFiyatHesaplama()
        {
            double EvGenelFiyatHesapla = EvGenelFiyatHesaplama();

            return
        }
    }
}
