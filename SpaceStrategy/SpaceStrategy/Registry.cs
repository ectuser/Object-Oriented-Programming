using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public class Registry
    {
        public static Random rnd = new Random();

        public List<Resource> resourceTypes = new List<Resource>(new Resource[] { new Wood(), new Stone(), new Food() });
        public List<Building> buildingTypes = new List<Building>(new Building[] { new Sawmill(1, new Colony("example", new Planet("example"))), new Quarry(2, new Colony("example", new Planet("example"))), new Pasture(3, new Colony("example", new Planet("example"))) });

    }
}
