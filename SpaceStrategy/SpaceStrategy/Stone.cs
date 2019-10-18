using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Stone : Resource
    {
        public string Type { get; }
        public Stone(string type)
        {
            Type = type;
        }
    }
}
