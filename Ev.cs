using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAlmak
{
    internal class Ev
    {
        private string _cephe;
        public string Cephe
        {
            get { return _cephe; }
            set { _cephe = value; }
        }

        private int _banyo;
        public int Banyo
        {
            get { return _banyo; }
            set { _banyo = value; }
        }

        private int _balkon;
        public int Balkon
        {
            get { return _balkon; }
            set { _balkon = value; }
        }

        private bool _kat;
        public bool Kat
        {
            get { return _kat; }
            set { _kat = value; }
        }


        public Ev(string cephe, int banyo, int balkon, bool kat)
        {
            this.Cephe = cephe;
            this.Banyo = banyo;
            this.Balkon = balkon;
            this.Kat = kat;
        }

        public double EvGenelFiyatHesaplama()
        {
            double toplam = default;
            if(this.Cephe == "Güney")
            {
                toplam += 10_000d;
            }

            if(this.Banyo > 1)
            {
                toplam += (Banyo * 3_000d);
            }


            if (this.Balkon > 1)
            {
                toplam += (Balkon * 2_000d);
            }

            if(this.Kat)
            {
                toplam += 20_000;
            }

            return toplam;
        }
    }
}
