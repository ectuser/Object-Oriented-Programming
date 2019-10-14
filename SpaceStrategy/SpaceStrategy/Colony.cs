using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Colony : PlanetObject
    {
        public string name { get; }
        private int money;

        // Constructor
        public Colony(string name)
        {
            this.name = name;
        }
    }
}
