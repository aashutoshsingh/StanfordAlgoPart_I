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
    public class CountingInversionTests
    {
        [TestMethod()]
        public void SortAndCountTest()
        {
            AssertSortAndCount(new int[] { 1, 3, 5, 2, 4, 6 }, new int[] { 1, 2, 3, 4, 5, 6 }, 3);
        }

        [TestMethod()]
        public void SortAndCountTest_1()
        {
            AssertSortAndCount(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 }, 0);
        }

        [TestMethod()]
        public void SortAndCountTest_2()
        {
            AssertSortAndCount(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5, 6 }, 15);
        }

        private void AssertSortAndCount(int[] inputArray, int[] expectedOutput, int expectedInversionCount)
        {
            var ci = new CountingInversion();
            var sortedArrayAndCount = ci.SortAndCount(inputArray);
            Assert.IsTrue(sortedArrayAndCount.Item1.SequenceEqual(expectedOutput));
            Assert.AreEqual(expectedInversionCount, sortedArrayAndCount.Item2);
        }
    }
}