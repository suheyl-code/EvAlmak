using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAlmak.Evler
{
    internal class Villa : Ev
    {
        private int _bahce;
        public int Bahce
        {
            get { return _bahce; }
            set 
            {
                if (value < 0)
                    _bahce = 0;
                else
                    _bahce = value; 
            }
        }

        private bool _sauna;
        public bool Sauna
        {
            get { return _sauna; }
            set { _sauna = value; }
        }

        private bool _sumine;
        public bool Sumine
        {
            get { return _sumine; }
            set { _sumine = value; }
        }

        private int _numberOfChimney;
        public int NumberOfChimney
        {
            get { return _numberOfChimney; }
            set { _numberOfChimney = value; }
        }

        private bool _fitnessSalon;
        public bool FitnessSalon
        {
            get { return _fitnessSalon; }
            set { _fitnessSalon = value; }
        }

        public Villa(string cephe, int banyo, int balkon, int kat, 
            int bahce, bool sauna, bool sumine, int numberOfChimney, bool fitness) :
            base(cephe, banyo, balkon, kat)
        {
            this.Bahce = bahce;
            this.Sauna = sauna;
            this.Sumine = sumine;
            this.NumberOfChimney = numberOfChimney;
            this.FitnessSalon = fitness;

        }

        public virtual double VillaFiyatHesaplama()
        {
            double toplam = EvGenelFiyatHesaplama();
            // Villa fiyat başlangiç seviyesi
            toplam += 40_000d;

            if(Bahce > 0)
            {
                toplam += (Bahce * 800d);
            }
            else if(Bahce <= 0)
            {
                // hiçbir şey yapma!
            }

            if (Sauna)
                toplam += 12_000d;

            if (Sumine)
                toplam += 3_000d;

            if(NumberOfChimney != 0)
                toplam += NumberOfChimney * 5_000d;
            else
                // Hiçbir Şey Yapma!

            if (FitnessSalon)
                toplam += 18_000d;
            
            return toplam;
        }
    }
}
