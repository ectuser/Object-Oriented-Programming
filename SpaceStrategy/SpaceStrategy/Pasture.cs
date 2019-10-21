using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Pasture : Building
    {
        public Pasture(int id) : base(id)
        {
            Cost = 100;
            Type = "pasture";
        }
    }
}
