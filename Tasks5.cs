using System;
using System.Formats.Asn1;

namespace Lab2
{
    internal class Pistolet
    {
        private int _ammocount;

        public Pistolet()
        {
            this._ammocount = 5;
        }

        public Pistolet(int _ammocount)
        {
            this._ammocount = _ammocount;
        }

        public int Ammocount
        {
            get { return this._ammocount; }
            set 
            { 
                if (value >= 0)
                {
                    this._ammocount = value;
                }
                else
                {
                    this._ammocount = 0;
                }
            }
        }

        public void Shoot()
        {
            if (this._ammocount > 0)
            {
                Console.WriteLine("Бах!");
                this._ammocount--;
            }
            else
            {
                Console.WriteLine("Клац!");
            }
        }

    }
    
    
}
