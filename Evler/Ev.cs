using EvAlmak.ColorConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAlmak.Evler
{
    internal class Ev
    {
        private string _cephe;
        public string Cephe
        {
            get { return _cephe; }
            set
            {
                if (value.ToLower().Contains("guney"))
                    _cephe = value;
                else if (value.ToLower().Contains("kuzey"))
                    _cephe = value;
                else
                    _cephe = "hicbiri";
            }
        }

        private int _banyo;
        public int Banyo
        {
            get { return _banyo; }
            set
            {
                _banyo = value;
            }
        }

        private int _balkon;
        public int Balkon
        {
            get { return _balkon; }
            set { _balkon = value; }
        }

        private int _kat;
        public int Kat
        {
            get { return _kat; }
            set { _kat = value; }
        }


        public Ev(string cephe, int banyo, int balkon, int kat)
        {
            this.Cephe = cephe;
            this.Banyo = banyo;
            this.Balkon = balkon;
            this.Kat = kat;


        }

        public double EvGenelFiyatHesaplama()
        {
            double toplam = 20_000;
            if (this.Cephe.ToLower() == "guney")
            {
                toplam += 15_000d;
            }
            else if (this.Cephe.ToLower() == "kuzey")
            {
                toplam += 10_000d;
            }
            else
            {
                toplam += 5_000d;
            }

            if (this.Banyo > 1)
            {
                toplam += (Banyo * 2_000d);
            }

            if (this.Balkon == 1)
            {
                toplam += 4_000d;
            }
            else if (this.Balkon > 1)
            {
                toplam += (Balkon * 2_000d);
            }

            if (this.Kat > 1)
            {
                toplam += (Kat * 30_000d);
            }
            else if(this.Kat == 0)
            {
                toplam += 5_000d;
            }

            return toplam;
        }
    }
}
