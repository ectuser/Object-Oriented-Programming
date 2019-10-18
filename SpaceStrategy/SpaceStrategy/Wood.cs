using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Wood : Resource
    {
        public string Type { get; }
         public Wood(string type)
        {
            Type = type;
        }
    }
}
