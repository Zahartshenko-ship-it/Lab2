using System;
using System.Formats.Asn1;

namespace Lab2
{
    internal class Pistolet
    {
        private int ammocount;

        public Pistolet()
        {
            this.ammocount = 5;
        }

        public Pistolet(int ammocount)
        {
            this.ammocount = ammocount;
        }

        public int Ammocount
        {
            get { return this.ammocount; }
            set 
            { 
                if (value >= 0)
                {
                    this.ammocount = value;
                }
                else
                {
                    this.ammocount = 0;
                }
            }
        }

        public void Shoot()
        {
            if (this.ammocount > 0)
            {
                Console.WriteLine("Бах!");
                this.ammocount--;
            }
            else
            {
                Console.WriteLine("Клац!");
            }
        }

    }
    
    
}