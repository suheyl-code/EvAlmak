using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAlmak
{
    internal class Villa : Ev
    {
        private int _bahce;
        public int Bahce
        {
            get { return _bahce; }
            set { _bahce = value; }
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

        private bool _fitnessSalon;
        public bool FitnessSalon
        {
            get { return _fitnessSalon; }
            set { _fitnessSalon = value; }
        }

        public Villa(string cephe, int banyo, int balkon, bool kat, 
            int bahce, bool sauna, bool sumine, bool fitness) :
            base(cephe, banyo, balkon, kat)
        {
            this.Bahce = bahce;
            this.Sauna = sauna;
            this.Sumine = sumine;
            this.FitnessSalon = fitness;

            Console.Write("Evin hangı cephe'de olsun (güney/kozey)? ");

            Console.Write("Evinde kaç tane banyo var? ");

            Console.Write("Evin kaç katli olsun? ");

            Console.Write("Evin kaç tane balkon var?");
        }

        public double VillaFiyatHesaplama()
        {
            double EvGenelFiyatHesapla = EvGenelFiyatHesaplama();

            return
        }
    }
}
