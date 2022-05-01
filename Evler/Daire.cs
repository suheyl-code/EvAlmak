using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAlmak.Evler
{
    internal class Daire : Ev
    {
        public Daire(string cephe, int banyo, int kat, int balkon) : base(cephe, banyo, balkon, kat)
        {

        }

        public double DaireFiyatHesaplama()
        {
            double EvGenelFiyatHesapla = EvGenelFiyatHesaplama();

            return EvGenelFiyatHesapla;
        }
    }
}
