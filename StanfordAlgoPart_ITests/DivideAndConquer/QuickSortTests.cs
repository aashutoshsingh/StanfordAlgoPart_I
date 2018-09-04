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
        public void QuickSortTest()
        {
            AssertQuickSort(new int[] { 4, 3 }, new int[] { 3, 4 });
        }

        [TestMethod()]
        public void QuickSortTest_1()
        {
            AssertQuickSort(new int[] { 3 }, new int[] { 3 });
        }

        [TestMethod()]
        public void QuickSortTest_2()
        {
            AssertQuickSort(new int[] { 3, 1, 2 }, new int[] { 1, 2, 3 });
        }

        [TestMethod()]
        public void QuickSortTest_3()
        {
            AssertQuickSort(new int[] { 3, 8, 2, 5, 1, 4, 7, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        }

        private void AssertQuickSort(int[] inputArray, int[] expectedOutput)
        {
            QuickSort quickSort = new QuickSort();
            quickSort.Sort(inputArray, 0, inputArray.Length-1);
            Assert.IsTrue(inputArray.SequenceEqual(expectedOutput));
        }

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