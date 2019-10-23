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
        private Dictionary<string, HeapResource> storage;
        public Planet ParentPlanet { get; }
        private int needFood;
        // Constructor
        public Colony(string name, Planet planet)
        {
            Name = name;
            //HeapResource[] tempList = { new HeapResource(100, new Wood("wood")), new HeapResource(100, new Stone("stone")), new HeapResource(100, new Food("food")) };
            storage = new Dictionary<string, HeapResource>
            {
                { "wood", new HeapResource(100, new Wood())},
                { "stone", new HeapResource(100, new Stone())},
                { "food", new HeapResource(100, new Food())}
            };
            Console.WriteLine(storage["wood"].Type);
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
        public Dictionary<string, HeapResource> GetStorage()
        {
            return storage;
        }
        public void SetStorage(Dictionary<string, HeapResource> newStorage)
        {
            storage = newStorage;
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
        public void UseFood()
        {
            needFood = buildingsList.Count();
            storage["food"].Amount -= needFood;
        }
        public void BuyResource(KeyValuePair<Resource, int> pair, int amount, int price)
        {
            Money -= price;
            storage[pair.Key.Type].Amount += amount;
        }
    }
}
