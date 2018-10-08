using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_AI
{
    class Destination
    {
        private int id, x, y;
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int ID { get => id; set => id = value; }

        public Destination(int ID, int x, int y)
        {
            this.ID = ID;
            this.x = x;
            this.y = y;
        }
        public double distanceFrom(Destination currentPos)
        {
            return Math.Sqrt(Math.Pow(X - currentPos.X, 2) + Math.Pow(Y - currentPos.Y, 2));
        }

    }
}
