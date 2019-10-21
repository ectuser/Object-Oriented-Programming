using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Quarry : Building
    {
        public Quarry(int id) : base(id)
        {
            Cost = 100;
            Type = "quarry";
        }
    }
}
