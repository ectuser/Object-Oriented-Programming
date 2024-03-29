﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceStrategy
{
    public partial class Form1
    {
        // REGISTRY
        public static Random rnd = new Random();

        public static List<Resource> resourceTypes = new List<Resource>(new Resource[] { new Wood(), new Stone(), new Food() });
        public static List<Building> buildingTypes = new List<Building>(new Building[] { new Sawmill(1, new Colony("example")), new Quarry(2, new Colony("example")), new Pasture(3, new Colony("example")) });
    }

    public struct ResourceInt
    {
        public Resource Type { get; set; }
        public int Number { get; set; }

        public ResourceInt(Resource type, int number)
        {
            Type = type;
            Number = number;
        }
    }
}
