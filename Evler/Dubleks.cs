using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAlmak.Evler
{
    internal class Dubleks : Ev
    {
        private int _bahce;
        public int Bahce
        {
            get { return _bahce; }
            set { _bahce = value; }
        }

        public Dubleks(string cephe, int banyo, int balkon, int kat, int bahce) : base(cephe, banyo, balkon, kat)
        {
            this.Bahce = bahce;
        }

        public double DubleksFiyatHesaplama()
        {
            double toplam = EvGenelFiyatHesaplama();
            toplam += 30_000d;

            if (Bahce > 0)
            {
                toplam += (Bahce * 3_000d);
            }
            else if (Bahce <= 0)
            {
                // Hiç bir şey yapma!
            }

            return toplam;
        }
    }
}
