using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public struct ColonyStorage
    {
        public Resource Type { get; set; }
        public int Amount { get; set; }

        public ColonyStorage(Resource type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }

    public class Colony
    {
        private List<Building> _buildingsList = new List<Building>();
        private List<ColonyStorage> storage;
        private int _needFood; // this thing depends on number of buildings


        public double Money { get; private set; }
        public Planet ParentPlanet { get; }
        public string Name { get; }
        public bool ColonyWorks { get; private set; }

        public Colony(string name, Planet planet)
        {
            Name = name;
            Money = 1000;
            ParentPlanet = planet;
            storage = InitColonyStorage();
        }
        public void CreateBuilding(Building building, Colony colony)
        {
            List<ResourceNeed> costList = building.ResourcesCost;
            for (int i = 0; i < costList.Count(); i++)
            {
                for (int j = 0; j < storage.Count(); j++)
                {
                    if (storage[j].Type.TypeString == costList[i].ResType.TypeString)
                    {
                        ColonyStorage stor = storage[j];
                        stor.Amount -= costList[i].ResCost;
                        storage[j] = stor;
                    }
                }
            }
            Money -= building.Cost;
            Building selectedBuilding = DefineBuildingType(building, colony);
            _buildingsList.Add(selectedBuilding);
        }
        public void RemoveBuilding(int id)
        {
            int index = _buildingsList.FindIndex(i => i.Id == id);
            _buildingsList.RemoveAt(index);
        }
        public List<Building> GetBuildings()
        {
            return _buildingsList;
        }
        public List<ColonyStorage> GetStorage()
        {
            return storage;
        }
        public void SetStorage(List<ColonyStorage> newStorage)
        {
            storage = newStorage;
        }
        private Building DefineBuildingType(Building building, Colony colony)
        {
            
            int id = _buildingsList.Count();
            for (int i = 0; i < _buildingsList.Count(); i++)
            {
                if (_buildingsList[i].Id == id)
                {
                    id++;
                }
            }
            if (building.Type == "sawmill")
                return new Sawmill(id, colony);
            else if (building.Type == "quarry")
                return new Quarry(id, colony);
            else if (building.Type == "pasture")
                return new Pasture(id, colony);
            else
            {
                Console.WriteLine("CAN'T DEFINE BUILDING BY TYPE!");
                return new Sawmill(id, new Colony("error", new Planet("error")));
            }
        }
        public void UseFood()
        {
            _needFood = _buildingsList.Count();
            string str = "doesn't have enough food to keep working.";
            // Check if colony has enough food to buildings work
            if (_needFood > storage[2].Amount)
            {
                //This IF is for remove previous status if there's enoigh food
                ColonyWorks = false;
                Form1.ShowStatus("Colony " + Name + " doesn't have enough food to keep working.");


            }
            else
            {
                storage[2] = ChangeStorage(storage[2], -_needFood);
                if (Form1._statusBar.Text.Contains(str))
                {
                    Form1.ShowStatus("");
                }
                //ColonyStorage stor = storage[2];
                //stor.Amount -= _needFood;
                //storage[2] = stor;
                ColonyWorks = true;
            }

        }
        public void BuyResource(MarketStorageElement resource, int amount, double price)
        {
            Money -= price;
            for (int i = 0; i < storage.Count(); i++)
            {
                if (resource.ResType.TypeString == storage[i].Type.TypeString)
                {
                    storage[i] = ChangeStorage(storage[i], amount);
                }
            }
            
        }
        public void SellResource(MarketStorageElement resource, int amount, double price)
        {
            for (int i = 0; i < storage.Count(); i++)
            {
                if (resource.ResType.TypeString == storage[i].Type.TypeString)
                {
                    storage[i] = ChangeStorage(storage[i], -amount);
                }
            }
            //_storage[resource.ResType.TypeString].Amount -= amount;
            Money += price;
        }

        public bool AreThereEnoughResources(Building buildingToBuild)
        {
            // Check if it is possible to build the building
            List<ResourceNeed> costList = buildingToBuild.ResourcesCost;
            if (Money >= buildingToBuild.Cost)
            {
                for (int i = 0; i < costList.Count(); i++)
                {
                    // if colony has enough resources of each type to build the building
                    for (int j = 0; j < storage.Count(); j++)
                    {
                        if (storage[j].Amount < costList[i].ResCost)
                        {
                            return false;
                        }
                    }
                    //if (_storage[costList[i].ResType.TypeString].Amount < costList[i].ResCost)
                    //    return false;
                }
                return true;
            }
            else
                return false;
        }

        private List<ColonyStorage> InitColonyStorage()
        {
            List<ColonyStorage> list = new List<ColonyStorage>();
            ColonyStorage wood = new ColonyStorage(new Wood(), 100);
            ColonyStorage stone = new ColonyStorage(new Stone(), 100);
            ColonyStorage food = new ColonyStorage(new Food(), 100);
            list.Add(wood);
            list.Add(stone);
            list.Add(food);
            return list;
        }

        private ColonyStorage ChangeStorage(ColonyStorage el, int changeAmount)
        {
            ColonyStorage tempStorage = el;
            tempStorage.Amount += changeAmount;
            return tempStorage;
        }
    }
}
