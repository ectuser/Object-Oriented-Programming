﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public class Colony
    {
        private List<Building> _buildingsList = new List<Building>();
        private Dictionary<string, HeapResource> _storage;
        private int _needFood; // this thing depends on number of buildings


        public double Money { get; private set; }
        public Planet ParentPlanet { get; }
        public string Name { get; }
        public bool ColonyWorks { get; private set; }

        public Colony(string name, Planet planet)
        {
            Name = name;
            _storage = new Dictionary<string, HeapResource>
            {
                { "wood", new HeapResource(100, new Wood())},
                { "stone", new HeapResource(100, new Stone())},
                { "food", new HeapResource(100, new Food())}
            };
            Money = 1000;
            ParentPlanet = planet;

        }
        public void CreateBuilding(Building building, Colony colony)
        {
            List<Dictionary<string, dynamic>> costList = building.ResourcesCost;
            for (int i = 0; i < costList.Count(); i++)
            {
                _storage[costList[i]["type"].Type].Amount -= costList[i]["cost"];
            }
            Money -= building.Cost;
            _buildingsList.Add(DefineBuildingType(building, colony));
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
        public Dictionary<string, HeapResource> GetStorage()
        {
            return _storage;
        }
        public void SetStorage(Dictionary<string, HeapResource> newStorage)
        {
            _storage = newStorage;
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
            // Check if colony has enough food to buildings work
            if (_needFood < _storage["food"].Amount)
            {
                //This IF is for remove previous status if there's enoigh food
                if (Form1._statusBar.Text.Any(c => "doesn't have enough food to keep working".Contains(c)))
                    Form1.ShowStatus("");

                _storage["food"].Amount -= _needFood;
                ColonyWorks = true;
            }
            else
            {
                ColonyWorks = false;
                Form1.ShowStatus("Colony " + Name + " doesn't have enough food to keep working.");
            }

        }
        public void BuyResource(Dictionary<string, dynamic> resource, int amount, double price)
        {
            Money -= price;
            _storage[resource["type"].Type].Amount += amount;
            
        }
        public void SellResource(Dictionary<string, dynamic> resource, int amount, double price)
        {
            _storage[resource["type"].Type].Amount -= amount;
            Money += price;
        }

        public bool AreThereEnoughResources(Building buildingToBuild)
        {
            // Check if it is possible to build the building
            List<Dictionary<string, dynamic>> costList = buildingToBuild.ResourcesCost;
            if (Money >= buildingToBuild.Cost)
            {
                for (int i = 0; i < costList.Count(); i++)
                {
                    // if colony has enough resources of each type to build the building
                    if (_storage[costList[i]["type"].Type].Amount < costList[i]["cost"])
                        return false;
                }
                return true;
            }
            else
                return false;
        }
    }
}
