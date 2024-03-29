﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Pasture : Building
    {
        public Pasture(int id, Colony colony) : base(id, colony)
        {
            Cost = 100;
            Type = "pasture";
            ResourceExtractionType = new Food();
            ResourcesCost = ResourcesNeedToBuild(woodCost: 10, stoneCost: 10, foodCost: 10);
        }
    }
}
