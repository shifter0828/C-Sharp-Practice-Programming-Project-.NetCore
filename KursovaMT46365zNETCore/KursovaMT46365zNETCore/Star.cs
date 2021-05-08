using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovaMT46365zNETCore
{
    class Star : Galaxy
    {
        float mass;
        float size;
        int temp;
        float luminosity;
        string starclass;

        public string StarClassCalculator { get; set; }

        public string ParentGalaxy { get; set; }

        public float Mass
        {
            get { return this.mass; }
            set { this.mass = value; }
        }
        public float Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
        public int Temp
        {
            get { return this.temp; }
            set { this.temp = value; }
        }
        public float Luminosity
        {
            get { return this.luminosity; }
            set { this.luminosity = value; }
        }
        /*public string Starclass
        {
            get { return this.starclass; }
            //set { this.starclass = value; }
        }*/

        public Star() { }

        public Star(string name, string type) : base(name, type)
        {

        }

        public Star(string name, float mass, float size, int temp, float luminosity) : base(name)
        {
            this.mass = mass;
            this.size = size;
            this.temp = temp;
            this.luminosity = luminosity;
        }

        public string classCalculator()
        {
            if (temp < 2400 || mass < 0.08)
            {
                starclass = "Too Small values";
            }
            else if ((temp >= 2400 && temp <= 3700) && luminosity <= 0.08 && (mass >= 0.08 && mass <= 0.45) && (size <= 0.7))
            {
                starclass = "M";
            }
            else if ((temp >= 3700 && temp <= 5200) && (luminosity >= 0.08 && luminosity <= 0.6) && (mass >= 0.45 && mass <= 0.8) && (size >= 0.7 && size <= 0.96))
            {
                starclass = "K";
            }
            else if ((temp >= 5200 && temp <= 6000) && (luminosity >= 0.06 && luminosity <= 1.5) && (mass >= 0.8 && mass <= 1.04) && (size >= 0.7 && size <= 1.15))
            {
                starclass = "G";
            }
            else if ((temp >= 6000 && temp <= 7500) && (luminosity >= 1.5 && luminosity <= 5) && (mass >= 1.04 && mass <= 1.4) && (size >= 1.15 && size <= 1.4))
            {
                starclass = "F";
            }
            else if ((temp >= 7500 && temp <= 10000) && (luminosity >= 5 && luminosity <= 25) && (mass >= 1.4 && mass <= 2.1) && (size >= 1.4 && size <= 1.8))
            {
                starclass = "A";
            }
            else if ((temp >= 10000 && temp <= 30000) && (luminosity >= 25 && luminosity <= 30000) && (mass >= 2.1 && mass <= 16) && (size >= 1.8 && size <= 6.6))
            {
                starclass = "B";
            }
            else if (temp >= 30000 && luminosity >= 30000 && mass >= 16 && size >= 6.6)
            {
                starclass = "O";
            }
            else { starclass = "Impossible values entered"; }
            //Console.WriteLine("The star class is:" + starclass);
            return starclass;
        }
    }
}
