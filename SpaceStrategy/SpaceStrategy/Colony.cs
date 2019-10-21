using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public class Colony
    {
        public string Name { get; }
        private List<Building> buildingsList = new List<Building>();
        //Dictionary<string, int> storage;
        public int Money { get; private set; }
        private List<HeapResource> storage;
        public Planet ParentPlanet { get; }
        // Constructor
        public Colony(string name, Planet planet)
        {
            Name = name;
            HeapResource[] tempList = { new HeapResource(100, new Wood("wood")), new HeapResource(100, new Stone("stone")), new HeapResource(100, new Food("food")) };
            storage = new List<HeapResource>(tempList);
            Money = 1000;
            ParentPlanet = planet;
        }
        public void CreateBuilding(Building building, Colony colony)
        {
            Money -= building.Cost;
            buildingsList.Add(DefineBuildingType(building, colony));
        }
        public void RemoveBuilding(int id)
        {
            int index = buildingsList.FindIndex(i => i.Id == id);
            buildingsList.RemoveAt(index);
        }
        public List<Building> GetBuildings()
        {
            return buildingsList;
        }
        public List<HeapResource> GetStorage()
        {
            return storage;
        }
        private Building DefineBuildingType(Building building, Colony colony)
        {
            // last else need fix
            if (building.Type == "swamill")
                return new Sawmill(buildingsList.Count(), colony);
            else if (building.Type == "quarry")
                return new Quarry(buildingsList.Count(), colony);
            else if (building.Type == "pasture")
                return new Pasture(buildingsList.Count(), colony);
            else
                return new Sawmill(buildingsList.Count(), colony);
        }
    }
}
