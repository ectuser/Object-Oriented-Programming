using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    class Planet
    {
        private int radius;
        public string name { get; }
        private readonly SpaceCoordinates coordinates; // check for a future
        public List<Colony> ColonyList = new List<Colony>();

        public Planet(string name)
        {
            this.name = name;
            Random rnd = new Random();
            radius = rnd.Next(0, 5);
            coordinates = new SpaceCoordinates(rnd.Next(0, 100), rnd.Next(0, 100));
        }

        public void CreateColony(string name)
        {
            if (ColonyList.All(x => x.name != name))
            {
                Colony tempColony = new Colony(name);
                ColonyList.Add(tempColony);
            }
        }
        public void RemoveColony(string name)
        {
            int index = ColonyList.FindIndex(i => i.name == name);
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
