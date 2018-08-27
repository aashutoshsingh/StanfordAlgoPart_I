using Microsoft.VisualStudio.TestTools.UnitTesting;
using StanfordAlgoPart_I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanfordAlgoPart_I.Tests
{
    [TestClass()]
    public class ClosetPairTests
    {
        [TestMethod()]
        public void GetDistanceTest()
        {
            ClosetPair closetPair = new ClosetPair();
            var dist = closetPair.GetDistance(new Point(0, 0), new Point(3, 4));
            Assert.AreEqual(5, dist);
        }

        [TestMethod()]
        public void GetClosetPairByBruteForceTest()
        {
            ClosetPair closetPair = new ClosetPair();
            var pair = closetPair.GetClosetPairByBruteForce(new Point[] { new Point(0, 0), new Point(0, 4), new Point(3, 0) });
            var smallestDist = closetPair.GetDistance(pair.Item1, pair.Item2);
            Assert.AreEqual(3, smallestDist);
        }

        [TestMethod()]
        public void GetClosetPairByBruteForceTest_1()
        {
            ClosetPair closetPair = new ClosetPair();
            var pair = closetPair.GetClosetPairByBruteForce(new Point[] { new Point(0, 0), new Point(1, 1), new Point(0, 3) });
            var smallestDist = closetPair.GetDistance(pair.Item1, pair.Item2);
            Assert.AreEqual(Math.Sqrt(2), smallestDist);
        }
    }
}