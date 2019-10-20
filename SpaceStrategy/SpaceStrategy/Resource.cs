using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public class Resource
    {
        public string Type { get; }
        public Resource(string type)
        {
            Type = type;
        }
    }
}
