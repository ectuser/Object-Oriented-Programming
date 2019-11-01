using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public struct SpaceCoordinates
    {
        public int X { get; }
        public int Y { get; }


        public SpaceCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
