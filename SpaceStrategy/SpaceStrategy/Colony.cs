using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Colony : PlanetObject
    {
        public string name { get; }
        private List<Building> buildingsList = new List<Building>();
        private int money;

        // Constructor
        public Colony(string name)
        {
            this.name = name;
        }
        public void createBuilding(string type)
        {
            if (buildingsList.All(x => x.id != buildingsList.Count()))
            {
                Building newBuilding = new Building(type, buildingsList.Count());
                buildingsList.Add(newBuilding);
            }
        }
        public List<Building> GetBuildings()
        {
            return buildingsList;
        }
    }
}
