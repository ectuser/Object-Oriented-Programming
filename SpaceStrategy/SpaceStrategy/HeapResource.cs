using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public class HeapResource : PlanetObject
    {
        public int Amount { get; }
        public string Type { get; }

        public HeapResource(int amount, Resource resource)
        {

            Amount = amount;
            Type = resource.Type;
        }
    }
}
