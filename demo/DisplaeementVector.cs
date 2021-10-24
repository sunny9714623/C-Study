using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared
{
    public struct DisplaeementVector
    {
        public int X;
        public int Y;
        public DisplaeementVector(int initialX,int initialY)
        {
            X = initialX;
            Y = initialY;
        }
        public static DisplaeementVector operator +(
            DisplaeementVector vector1,
            DisplaeementVector vector2
            )
        {
            return new DisplaeementVector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }
    }
}
