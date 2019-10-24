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
        public int Money { get; private set; }
        private Dictionary<string, HeapResource> storage;
        public Planet ParentPlanet { get; }
        private int needFood;
        public Colony(string name, Planet planet)
        {
            Name = name;
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
                return new Sawmill(buildingsList.Count(), new Colony("error", new Planet("error")));
        }
        public void UseFood()
        {
            needFood = buildingsList.Count();
            storage["food"].Amount -= needFood;
        }
        public void BuyResource(Dictionary<string, dynamic> resource, int amount, int price)
        {
            Money -= price;
            storage[resource["type"].Type].Amount += amount;
        }
        public void SellResource(Dictionary<string, dynamic> resource, int amount, int price)
        {
            storage[resource["type"].Type].Amount -= amount;
            Money += price;
        }
    }
}
