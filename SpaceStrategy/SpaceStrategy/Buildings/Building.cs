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
        public Colony ParentColony { get; }

        public Building(int id, Colony colony)
        {
            Efficiency = 2;
            Id = id;
            ParentColony = colony;
            ParentPlanet = colony.ParentPlanet;
        }

        public void ExtractResources()
        {
            // Colony have enough food to work
            if (ParentColony.ColonyWorks)
            {
                for (int i = 0; i < ParentPlanet.GetResources().Count(); i++)
                {
                    // if type of the building matches type of the resource building should extract resource
                    if (ParentPlanet.GetResources()[i].Type.TypeString == ResourceExtractionType.TypeString && ParentPlanet.GetResources()[i].Amount > 0)
                    {
                        ParentPlanet.GetResources()[i].Amount -= Efficiency;
                        Dictionary<string, HeapResource> storage = ParentColony.GetStorage();
                        storage[ResourceExtractionType.TypeString].Amount += Efficiency;
                        ParentColony.SetStorage(storage);
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
