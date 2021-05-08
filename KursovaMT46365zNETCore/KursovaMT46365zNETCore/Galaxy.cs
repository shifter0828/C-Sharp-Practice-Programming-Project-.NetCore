using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovaMT46365zNETCore
{
    class Galaxy
    {
        protected string name;
        protected string type;
        float age;
        char ageChar;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public float Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public char AgeChar
        {
            get { return this.ageChar; }
            set { this.ageChar = value; }
        }

        public Galaxy() { }

        public Galaxy(string name)
        {
            this.name = name;
        }

        public Galaxy(string name, string type)
        {
            this.name = name;
            this.type = type;
        }
        public Galaxy(string name, string type, float age, char ageChar)
        {
            this.name = name;
            this.type = type;
            this.age = age;
            this.ageChar = ageChar;
        }

    }
}
