using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public class Planet
    {
        public int Radius { get; }
        public string Name { get; }
        public readonly SpaceCoordinates coordinates; // check for a future
        private List<Colony> colonyList = new List<Colony>();
        private readonly List<HeapResource> heapsOfResources;

        public Planet(string name)
        {
            Name = name;
            Random rnd = new Random();
            Radius = rnd.Next(0, 5);
            coordinates = new SpaceCoordinates(rnd.Next(0, 100), rnd.Next(0, 100));
            heapsOfResources = new List<HeapResource>(SetResources());
        }

        public void CreateColony(string name, Planet planet)
        {
            if (colonyList.All(x => x.Name != name))
            {
                Colony tempColony = new Colony(name, planet);
                colonyList.Add(tempColony);
            }
        }
        public void RemoveColony(string name)
        {
            int index = colonyList.FindIndex(i => i.Name == name);
            colonyList.RemoveAt(index);
        }
        public List<Colony> GetColonies()
        {
            return colonyList;
        }
        private List<HeapResource> SetResources()
        {
            List<HeapResource> heaps = new List<HeapResource>();
            Random rnd = new Random();
            int heapsAmount = rnd.Next(1, 10);
            for (int i = 0; i < heapsAmount; i++)
            {
                int amount = rnd.Next(100, 1000);
                int typeInt = rnd.Next(0, 3);
                HeapResource heap = new HeapResource(amount, Form1.resourceTypes[typeInt]);
                heaps.Add(heap);
            }
            return heaps;
        }
        public List<HeapResource> GetResources()
        {
            return heapsOfResources;
        }
    }
}
