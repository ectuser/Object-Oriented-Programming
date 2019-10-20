using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Building : PlanetObject
    {
        public string Type { get; }
        public int Id { get; }
        public int Cost { get; set; }
        public int efficiency; // conventional units of resource / second

        public Building(string type, int id)
        {
            Type = type;
            Id = id;
        }
    }
}
