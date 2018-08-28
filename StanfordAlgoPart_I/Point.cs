using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanfordAlgoPart_I
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = obj as Point;
            if (X == other.X && Y == other.Y)
                return true;
            else
                return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (X + Y).GetHashCode();
        }
    }
}
