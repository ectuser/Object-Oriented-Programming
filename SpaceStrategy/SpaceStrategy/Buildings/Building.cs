using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public struct ResourceNeed
    {
        public Resource ResType { get; }
        public int ResCost { get; }

        public ResourceNeed(Resource res, int cost)
        {
            ResType = res;
            ResCost = cost;
        }
    }

    public class Building : PlanetObject
    {
        public string Type { get; protected set; }
        public Resource ResourceExtractionType { get; protected set; }
        public int Id { get; }
        public int Cost { get; set; }
        public List<ResourceNeed> ResourcesCost { get; protected set; }
        public int Efficiency { get; } // conventional units of resource / second

        public Building(int id, Colony colony)
        {
            Efficiency = 2;
            Id = id;
        }

        public void ExtractResources(Colony parentColony, Planet parentPlanet)
        {
            // Colony have enough food to work
            if (parentColony.ColonyWorks)
            {
                for (int i = 0; i < parentPlanet.GetResources().Count(); i++)
                {
                    // if type of the building matches type of the resource building should extract resource
                    if (parentPlanet.GetResources()[i].Type.TypeString == ResourceExtractionType.TypeString && parentPlanet.GetResources()[i].Amount > 0)
                    {
                        parentPlanet.GetResources()[i].Amount -= Efficiency;
                        List<ColonyStorage> storage = parentColony.GetStorage();
                        for (int j = 0; j < storage.Count(); j++)
                        {
                            if (storage[j].Type.TypeString == ResourceExtractionType.TypeString)
                            {
                                ColonyStorage temp = storage[j];
                                temp.Amount += Efficiency;
                                storage[j] = temp;
                            }
                        }
                        //storage[ResourceExtractionType.TypeString].Amount += Efficiency;
                        parentColony.SetStorage(storage);
                    }
                }
            }
        }

        // This function defines how many resources of each type are needed to create the building
        protected List<ResourceNeed> ResourcesNeedToBuild(int woodCost, int stoneCost, int foodCost)
        {
            List<ResourceNeed> list = new List<ResourceNeed>
            {
                new ResourceNeed(new Wood(), woodCost),
                new ResourceNeed(new Stone(), stoneCost),
                new ResourceNeed(new Food(), foodCost)
            };
            return list;
        }
    }
}
