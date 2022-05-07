using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAlmak.Evler
{
    internal class Dubleks : Villa
    {
        public Dubleks(string cephe, int banyo, int balkon, 
            int bahce, bool sauna, bool sumine, int numberOfChimney, bool fitness) : 
            base(cephe, banyo, balkon, 2, bahce, sauna, sumine, numberOfChimney, fitness)
        {

        }

        /// <summary>
        /// Dubleks Ev Muhasebe İşlemleri: Villa (base - virtual), bu (Override)
        /// </summary>
        /// <returns>double</returns>
        public override double VillaFiyatHesaplama()
        {
            double toplam = EvGenelFiyatHesaplama();
            // Dubleks fiyat başlangiç seviyesi
            toplam += 20_000d;

            if (Bahce > 0)
            {
                toplam += (Bahce * 700d);
            }
            else if (Bahce <= 0)
            {
                // Hiçbir şey yapma!
            }

            if (Sauna)
                toplam += 10_000d;

            if (Sumine)
                toplam += 3_000d;

            if (NumberOfChimney != 0)
                toplam += NumberOfChimney * 5_000d;

            if (FitnessSalon)
                toplam += 15_000d;

            return toplam;
        }
    }
}
