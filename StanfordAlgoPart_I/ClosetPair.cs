using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanfordAlgoPart_I
{
    public class ClosetPair
    {
        public (Point p1, Point p2, double minDist) Start(Point[] points)
        {
            //points.Sort((p, q) => p.X.CompareTo(q.X));
            var xPoints = points.OrderBy(p => p.X).ToArray();
            var yPoints = points.OrderBy(p => p.Y).ToArray();
            return GetClosetPair(xPoints, yPoints);
        }

        public (Point p1, Point p2, double minDist) GetClosetPair(Point[] pointsSortedByX, Point[] pointsSortedByY)
        {
            if (pointsSortedByX.Length < 4)
                return GetClosetPairByBruteForce(pointsSortedByX);

            var firstHalfX = pointsSortedByX.Take(pointsSortedByX.Length / 2).ToArray();
            var secondHalfX = pointsSortedByX.Skip(pointsSortedByX.Length / 2).ToArray();
            var firstHalfY = new List<Point>();
            var secondHalfY = new List<Point>();

            foreach (var y in pointsSortedByY)
            {
                if (firstHalfX.Contains(y))
                    firstHalfY.Add(y);
                else
                    secondHalfY.Add(y);
            }

            var firstHalfClosetPair = GetClosetPair(firstHalfX, firstHalfY.ToArray());
            var secondHalfClosetPair = GetClosetPair(secondHalfX, secondHalfY.ToArray());
            var delta = Math.Min(firstHalfClosetPair.minDist, secondHalfClosetPair.minDist);

            var splitClosetPair = GetClosetPairInSplit(pointsSortedByX, pointsSortedByY, delta);
            

            //return smallest of three closet pair
            if(firstHalfClosetPair.minDist < secondHalfClosetPair.minDist)
            {
                if (firstHalfClosetPair.minDist < splitClosetPair.minDist)
                    return firstHalfClosetPair;
                else
                    return splitClosetPair;
            }
            else
            {
                if (secondHalfClosetPair.minDist < splitClosetPair.minDist)
                    return secondHalfClosetPair;
                else
                    return splitClosetPair;
            }            
        }

        public (Point p1, Point p2, double minDist) GetClosetPairInSplit(Point[] xPoints, Point[] yPoints, double delta)
        {
            var xMedian = xPoints[(xPoints.Length / 2) - 1];

            List<Point> lstCandidatePointsSortedByY = new List<Point>();
            foreach (var point in yPoints)
            {
                if (xMedian.X - delta <= point.X && point.X <= xMedian.X + delta)
                    lstCandidatePointsSortedByY.Add(point);
            }

            double shortestDist = delta;
            (Point, Point, double) closetPair = (null, null, double.MaxValue);
            for (int i = 0; i < lstCandidatePointsSortedByY.Count -1; i++)
            {
                for (int j = i+1; j < i + 7 && i+j < lstCandidatePointsSortedByY.Count; j++)
                {
                    var dist = GetDistance(lstCandidatePointsSortedByY[i], lstCandidatePointsSortedByY[j]);
                    if (dist < shortestDist)
                    {
                        shortestDist = dist;
                        closetPair = (lstCandidatePointsSortedByY[i], lstCandidatePointsSortedByY[j], shortestDist);
                    }
                }
            }

            return closetPair;
        }

        public (Point p1, Point p2, double minDist) GetClosetPairByBruteForce(Point[] points)
        {
            //this function should be called if no of points are 3 or less
            if (points.Length <= 1)
                throw new Exception("Invalid number of points, points should be more than 2 to find closet pair");

            if (points.Length == 2)
                return (points[0], points[1], GetDistance(points[0], points[1]));

            var d1 = GetDistance(points[0], points[1]);
            var d2 = GetDistance(points[1], points[2]);
            var d3 = GetDistance(points[2], points[0]);

            if (d1 < d2)
            {
                if (d1 < d3)
                    return (points[0], points[1], d1);
                else
                    return (points[2], points[0], d3);
            }
            else
            {
                if(d2 < d3)
                    return (points[1], points[2], d2);
                else
                    return (points[2], points[0], d3);

            }
        }

        public double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2.0)  + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
