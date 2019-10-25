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
            // need fix
            for (int i = 0; i < ParentPlanet.GetResources().Count(); i++)
            {
                Console.WriteLine(ParentPlanet.Name + " " + ParentColony.Name);
                if (ParentPlanet.GetResources()[i].Type == "wood" && Type == "sawmill" && ParentPlanet.GetResources()[i].Amount > 0)
                {
                    ParentPlanet.GetResources()[i].Amount -= efficiency;
                    Dictionary<string, HeapResource> storage = ParentColony.GetStorage();
                    storage["wood"].Amount += efficiency;
                    ParentColony.SetStorage(storage);
                }
                else if (ParentPlanet.GetResources()[i].Type == "stone" && Type == "quarry" && ParentPlanet.GetResources()[i].Amount > 0)
                {
                    ParentPlanet.GetResources()[i].Amount -= efficiency;
                    Dictionary<string, HeapResource> storage = ParentColony.GetStorage();
                    storage["stone"].Amount += efficiency;
                    ParentColony.SetStorage(storage);
                }
                else if (ParentPlanet.GetResources()[i].Type == "food" && Type == "pasture" && ParentPlanet.GetResources()[i].Amount > 0)
                {
                    ParentPlanet.GetResources()[i].Amount -= efficiency;
                    Dictionary<string, HeapResource> storage = ParentColony.GetStorage();
                    storage["food"].Amount += efficiency;
                    ParentColony.SetStorage(storage);
                }
            }
        }
    }
}
