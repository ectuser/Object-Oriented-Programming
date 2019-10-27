using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Quarry : Building
    {
        public Quarry(int id, Colony colony) : base(id, colony)
        {
            Cost = 100;
            Type = "quarry";
            ResourceExtractionType = "stone";
            ResourcesCost = ResourcesNeedToBuild(woodCost: 10, stoneCost: 10, foodCost: 10);
        }
    }
}
