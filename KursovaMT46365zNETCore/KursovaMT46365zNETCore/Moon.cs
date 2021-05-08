using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovaMT46365zNETCore
{
    class Moon : Planet
    {
        public string ParentPlanet { get; set; }

        public Moon() { }

        public Moon(string name) : base(name)
        {

        }
    }
}
