using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public abstract class PlanetObject
    {
        protected PlanetCoordinates objectCoordinates;

        public PlanetObject()
        {
            Random rnd = new Random();
            objectCoordinates = new PlanetCoordinates(rnd.Next(0, 100), rnd.Next(0, 100));
        }
    }
}
