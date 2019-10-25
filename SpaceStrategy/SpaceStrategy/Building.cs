using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public class Building : PlanetObject
    {
        public string Type { get; protected set; }
        public string ResourceExtractionType { get; protected set; }
        public int Id { get; }
        public int Cost { get; set; }
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
            for (int i = 0; i < ParentPlanet.GetResources().Count(); i++)
            {
                // if type of the building matches type of the resource building should extract resource
                if (ParentPlanet.GetResources()[i].Type == ResourceExtractionType && ParentPlanet.GetResources()[i].Amount > 0)
                {
                    ParentPlanet.GetResources()[i].Amount -= Efficiency;
                    Dictionary<string, HeapResource> storage = ParentColony.GetStorage();
                    storage[ResourceExtractionType].Amount += Efficiency;
                    ParentColony.SetStorage(storage);
                }
            }
        }
    }
}
