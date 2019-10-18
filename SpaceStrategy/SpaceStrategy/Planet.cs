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

        public Planet(string name)
        {
            this.Name = name;
            Random rnd = new Random();
            Radius = rnd.Next(0, 5);
            coordinates = new SpaceCoordinates(rnd.Next(0, 100), rnd.Next(0, 100));
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

        //public static explicit operator Planet(List<object> v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
