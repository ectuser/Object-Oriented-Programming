using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Planet
    {
        public int Radius { get; }
        public string Name { get; }
        public readonly SpaceCoordinates coordinates; // check for a future
        private List<Colony> ColonyList = new List<Colony>();
        private readonly List<HeapResource> heapResources;

        public Planet(string name)
        {
            Name = name;
            Random rnd = new Random();
            Radius = rnd.Next(0, 5);
            coordinates = new SpaceCoordinates(rnd.Next(0, 100), rnd.Next(0, 100));
            heapResources = new List<HeapResource>(SetResources());
            ShowResources();
        }

        public void CreateColony(string name)
        {
            if (ColonyList.All(x => x.Name != name))
            {
                Colony tempColony = new Colony(name);
                ColonyList.Add(tempColony);
            }
        }
        public void RemoveColony(string name)
        {
            int index = ColonyList.FindIndex(i => i.Name == name);
            ColonyList.RemoveAt(index);
        }
        public List<Colony> GetColonies()
        {
            return ColonyList;
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
                //Console.WriteLine(Form1.resourceTypes[typeInt].Type);
                HeapResource heap = new HeapResource(amount, Form1.resourceTypes[typeInt]);
                heaps.Add(heap);
            }
            return heaps;
        }
        private void ShowResources()
        {
            for (int i = 0; i < heapResources.Count(); i++)
            {
                Console.WriteLine(heapResources[i].Amount);
                Console.WriteLine(heapResources[i].Type);
            }
        }
    }
}
