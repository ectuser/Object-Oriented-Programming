using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public abstract class PlanetObject
    {
        protected PlanetCoordinates _objectCoordinates;
        public Planet ParentPlanet;

        public PlanetObject()
        {
            _objectCoordinates = new PlanetCoordinates(Registry.rnd.Next(0, 100), Registry.rnd.Next(0, 100));
        }
    }
}
