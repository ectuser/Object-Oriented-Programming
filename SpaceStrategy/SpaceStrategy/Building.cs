﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Building : PlanetObject
    {
        public string type { get; }
        public int id { get; }

        public Building(string type, int id)
        {
            this.type = type;
            this.id = id;
        }
    }
}
