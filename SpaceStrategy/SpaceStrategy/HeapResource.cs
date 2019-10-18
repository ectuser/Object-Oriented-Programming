using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class HeapResource : PlanetObject
    {
        public int Amount { get; }
        public string Type { get; }

        public HeapResource(int amount, string type)
        {
            Amount = amount;
            Type = type;
        }
    }
}
