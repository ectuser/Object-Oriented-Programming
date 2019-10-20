using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Colony : PlanetObject
    {
        public string Name { get; }
        private List<Building> buildingsList = new List<Building>();
        Dictionary<string, int> storage;
        public int Money { get; }

        // Constructor
        public Colony(string name)
        {
            Name = name;
            storage = new Dictionary<string, int>
            {
                { "wood", 100 },
                { "stone", 100 },
                { "food", 100 }
            };
        }
        public void CreateBuilding(string type)
        {
            Building newBuilding = new Building(type, buildingsList.Count());
            buildingsList.Add(newBuilding);
            ShowBuildings();
        }
        public void RemoveBuilding(int id)
        {
            int index = buildingsList.FindIndex(i => i.Id == id);
            buildingsList.RemoveAt(index);
        }
        private void ShowBuildings()
        {
            for (int i = 0; i < buildingsList.Count(); i++)
            {
                Console.WriteLine(buildingsList[i].Id);
            }
        }
        public List<Building> GetBuildings()
        {
            return buildingsList;
        }
    }
}
