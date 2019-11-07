using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public class Colony
    {
        private List<Building> _buildingsList = new List<Building>();
        private List<ResourceInt> storage;
        private int _needFood; // this thing depends on number of buildings


        public double Money { get; private set; }
        public string Name { get; }
        public bool ColonyWorks { get; private set; }

        public Colony(string name)
        {
            Name = name;
            Money = 1000;
            storage = InitColonyStorage();
        }
        public void CreateBuilding(Building building, Colony colony)
        {
            List<ResourceInt> costList = building.ResourcesCost;
            for (int i = 0; i < costList.Count(); i++)
            {
                for (int j = 0; j < storage.Count(); j++)
                {
                    if (storage[j].Type.TypeString == costList[i].Type.TypeString)
                    {
                        storage[j] = ChangeStorage(storage[j], -costList[i].Number);
                        //ResourceInt stor = storage[j];
                        //stor.Number -= costList[i].ResCost;
                        //storage[j] = stor;
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
        public List<ResourceInt> GetStorage()
        {
            return storage;
        }
        public void SetStorage(List<ResourceInt> newStorage)
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
                return new Sawmill(id, new Colony("error"));
            }
        }
        public void UseFood()
        {
            _needFood = _buildingsList.Count();
            string str = "doesn't have enough food to keep working.";
            // Check if colony has enough food to buildings work
            if (_needFood > storage[2].Number)
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
            List<ResourceInt> costList = buildingToBuild.ResourcesCost;
            if (Money >= buildingToBuild.Cost)
            {
                for (int i = 0; i < costList.Count(); i++)
                {
                    // if colony has enough resources of each type to build the building
                    for (int j = 0; j < storage.Count(); j++)
                    {
                        if (storage[j].Number < costList[i].Number)
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

        private List<ResourceInt> InitColonyStorage()
        {
            List<ResourceInt> list = new List<ResourceInt>();
            ResourceInt wood = new ResourceInt(new Wood(), 100);
            ResourceInt stone = new ResourceInt(new Stone(), 100);
            ResourceInt food = new ResourceInt(new Food(), 100);
            list.Add(wood);
            list.Add(stone);
            list.Add(food);
            return list;
        }

        private ResourceInt ChangeStorage(ResourceInt el, int changeAmount)
        {
            ResourceInt tempStorage = el;
            tempStorage.Number += changeAmount;
            return tempStorage;
        }
    }
}
