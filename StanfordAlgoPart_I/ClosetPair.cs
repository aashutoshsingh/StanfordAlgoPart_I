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
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

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

    public class ClosetPair
    {
        public (Point, Point) Start(Point[] points)
        {
            //points.Sort((p, q) => p.X.CompareTo(q.X));
            var xPoints = points.OrderBy(p => p.X).ToArray();
            var yPoints = points.OrderBy(p => p.Y).ToArray();
            return GetClosetPair(xPoints, yPoints);
        }

        public (Point,Point) GetClosetPair(Point[] pointsSortedByX, Point[] pointsSortedByY)
        {
            if (pointsSortedByX.Length < 4)
                return GetClosetPairByBruteForce(pointsSortedByX);
            //var firstHalfClosetPair = GetClosetPair()
            return (null,null);            
        }

        public (Point, Point) GetClosetPairByBruteForce(Point[] points)
        {
            //this function should be called if no of points are 3 or less
            if (points.Length <= 1)
                throw new Exception("Invalid number of points, points should be more than 2 to find closet pair");

            if (points.Length == 2)
                return (points[0], points[1]);

            var d1 = GetDistance(points[0], points[1]);
            var d2 = GetDistance(points[1], points[2]);
            var d3 = GetDistance(points[2], points[0]);

            if (d1 < d2)
            {
                if (d1 < d3)
                    return (points[0], points[1]);
                else
                    return (points[2], points[0]);
            }
            else
            {
                if(d2 < d3)
                    return (points[1], points[2]);
                else
                    return (points[2], points[0]);

            }
        }

        public double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2.0)  + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
