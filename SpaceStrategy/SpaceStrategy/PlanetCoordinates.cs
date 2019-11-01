using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public struct PlanetCoordinates
    {
        public int X { get; }
        public int Y { get; }

        public PlanetCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

}
