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
        public readonly SpaceCoordinates coordinates;

        private List<Colony> _colonyList = new List<Colony>();
        private readonly List<HeapResource> _heapsOfResources; // These things are heaps physically located on the planet like an object

        public Planet(string name)
        {
            Name = name;
            Random rnd = new Random();
            Radius = rnd.Next(0, 5);
            coordinates = new SpaceCoordinates(rnd.Next(0, 100), rnd.Next(0, 100));
            _heapsOfResources = new List<HeapResource>(SetResources());
        }

        public void CreateColony(string name, Planet planet)
        {
            if (_colonyList.All(x => x.Name != name))
            {
                Colony tempColony = new Colony(name, planet);
                _colonyList.Add(tempColony);
            }
            else
            {
                Form1.ShowStatus("Colony with this name already exists");
            }
        }
        public void RemoveColony(string name)
        {
            int index = _colonyList.FindIndex(i => i.Name == name);
            _colonyList.RemoveAt(index);
        }
        public List<Colony> GetColonies()
        {
            return _colonyList;
        }
        private List<HeapResource> SetResources()
        {
            // Random number of rundom resource type with random amount of it
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
            return _heapsOfResources;
        }
    }
}
