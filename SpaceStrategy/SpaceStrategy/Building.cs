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
        public int efficiency { get; } // conventional units of resource / second
        public Colony ParentColony { get; }

        public Building(int id, Colony colony)
        {
            efficiency = 2;
            Id = id;
            ParentColony = colony;
            ParentPlanet = colony.ParentPlanet;
        }

        public void ExtractResources()
        {
            for (int i = 0; i < ParentPlanet.GetResources().Count(); i++)
            {
                Console.WriteLine(ParentPlanet.GetResources()[i].Type + " " + ResourceExtractionType);
                if (ParentPlanet.GetResources()[i].Type == ResourceExtractionType && ParentPlanet.GetResources()[i].Amount > 0)
                {
                    ParentPlanet.GetResources()[i].Amount -= efficiency;
                    Dictionary<string, HeapResource> storage = ParentColony.GetStorage();
                    storage[ResourceExtractionType].Amount += efficiency;
                    ParentColony.SetStorage(storage);
                }
            }
        }
    }
}
