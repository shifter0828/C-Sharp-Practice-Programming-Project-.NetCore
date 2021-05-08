using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovaMT46365zNETCore
{
    class Planet : Star
    {
        string supportLife;

        public string ParentStar { get; set; }

        public string SupportLife
        {
            get { return this.supportLife; }
            set { this.supportLife = value; }
        }

        public Planet() { }

        public Planet(string name)
        {
            this.name = name;
        }

        public Planet(string name, string type, string supportLife) : base(name, type)
        {
            this.supportLife = supportLife;
        }
    }
}
