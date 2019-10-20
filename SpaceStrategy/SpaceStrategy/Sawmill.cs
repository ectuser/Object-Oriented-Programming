using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Sawmill : Building
    {
        public Sawmill(string type, int id) : base(type, id)
        {
            Cost = 100;
        }
    }
}
