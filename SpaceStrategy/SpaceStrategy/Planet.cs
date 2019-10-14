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
        private int ID;
        private SpaceCoordinates coordinates;
        private List<Colony> ColonyList = new List<Colony>();

        public Planet(string name, int ID)
        {
            this.name = name;
            this.ID = ID;
        }

        private void CreateColony(string name)
        {
            Colony tempColony = new Colony(name);
            ColonyList.Add(tempColony);
        }
        public string GetName()
        {
            return name;
        }
        public int GetID()
        {
            return ID;
        }
    }
}
