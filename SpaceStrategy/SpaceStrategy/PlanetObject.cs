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
            _objectCoordinates = new PlanetCoordinates(Form1.rnd.Next(0, 100), Form1.rnd.Next(0, 100));
        }
    }
}
