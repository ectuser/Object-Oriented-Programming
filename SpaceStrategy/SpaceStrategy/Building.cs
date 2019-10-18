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

        public Building(string type, int id)
        {
            this.Type = type;
            this.Id = id;
        }
    }
}
