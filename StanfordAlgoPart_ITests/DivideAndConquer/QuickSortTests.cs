using Microsoft.VisualStudio.TestTools.UnitTesting;
using StanfordAlgoPart_I.DivideAndConquer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanfordAlgoPart_I.DivideAndConquer.Tests
{
    [TestClass()]
    public class QuickSortTests
    {
        [TestMethod()]
        public void PartitionTest()
        {
            var array = new int[] { 3, 8, 2, 5, 1, 4, 7, 6 };
            var expectedOutputPos = 2;
            AssertQuickSortPartition(array, expectedOutputPos);
        }

        [TestMethod()]
        public void PartitionTest_1()
        {
            var array = new int[] { 7, 8, 2, 5, 1, 4, 3, 6 };
            var expectedOutputPos = 6;
            AssertQuickSortPartition(array, expectedOutputPos);
        }

        [TestMethod()]
        public void PartitionTest_2()
        {
            var array = new int[] { 1, 8, 2, 5, 7, 4, 3, 6 };
            var expectedOutputPos = 0;
            AssertQuickSortPartition(array, expectedOutputPos);
        }

        private static void AssertQuickSortPartition(int[] array, int expectedOutputPos)
        {
            QuickSort quickSort = new QuickSort();
            int pos = quickSort.Partition(array, 0, array.Length - 1);
            Assert.AreEqual(expectedOutputPos, pos);
        }
    }
}