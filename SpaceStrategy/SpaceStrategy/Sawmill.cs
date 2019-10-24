using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Sawmill : Building
    {
        public Sawmill(int id, Colony colony) : base(id, colony)
        {
            Cost = 100;
            Type = "sawmill";
        }
    }
}
