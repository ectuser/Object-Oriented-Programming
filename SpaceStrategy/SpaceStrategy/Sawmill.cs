using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Sawmill : Building
    {
        public Sawmill(int id) : base(id)
        {
            Cost = 100;
            Type = "sawmill";
        }
        public void ExtractResource()
        {

        }
    }
}
