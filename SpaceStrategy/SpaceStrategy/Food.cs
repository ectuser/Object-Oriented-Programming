using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Food : Resource
    {
        public string Type { get; }

        public Food(string type)
        {
            Type = type;
        }
    }
}
