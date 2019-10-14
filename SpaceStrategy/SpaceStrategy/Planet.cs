using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Planet
    {
        private int radius;
        private string name;
        private SpaceCoordinates coordinates;
        public List<Colony> ColonyList = new List<Colony>();

        public Planet(string name)
        {
            this.name = name;
        }

        public void CreateColony(string name)
        {
            Colony tempColony = new Colony(name);
            ColonyList.Add(tempColony);
        }
        public void RemoveColony(string name)
        {
            int index = ColonyList.FindIndex(i => i.name == name);
            ColonyList.RemoveAt(index);
        }
        public string GetName()
        {
            return name;
        }
        public List<Colony> GetColonies()
        {
            return ColonyList;
        }
    }
}
