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
        //Dictionary<string, int> storage;
        public int Money { get; }
        private List<HeapResource> storage;

        // Constructor
        public Colony(string name)
        {
            Name = name;
            HeapResource[] tempList = { new HeapResource(100, new Wood("wood")), new HeapResource(100, new Stone("stone")), new HeapResource(100, new Food("food")) };
            storage = new List<HeapResource>(tempList);
        }
        public void CreateBuilding(string type)
        {
            Building newBuilding = new Building(buildingsList.Count());
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
        public List<HeapResource> GetStorage()
        {
            return storage;
        }
    }
}
