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
    public class MergeSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            AssertSort(new int[] { 4, 3 }, new int[] { 3, 4 });
        }

        [TestMethod()]
        public void SortTest_1()
        {
            AssertSort(new int[] { 3 }, new int[] { 3 });
        }

        [TestMethod()]
        public void SortTest_2()
        {
            AssertSort(new int[] { 3, 1, 2 }, new int[] { 1, 2, 3 });
        }

        private void AssertSort(int[] inputArray, int[] expectedOutput)
        {
            MergeSort mergeSort = new MergeSort();
            var sortedArray = mergeSort.Sort(inputArray);
            Assert.IsTrue(sortedArray.SequenceEqual(expectedOutput));
        }

        [TestMethod()]
        public void MergeTest()
        {
            int[] firstHalf = { 1, 2, 3, 4 };
            int[] secondHalf = { 1, 2, 3, 4 };
            AssetMerge(firstHalf, secondHalf, new int[] { 1, 1, 2, 2, 3, 3, 4, 4 });
        }

        [TestMethod()]
        public void MergeTest_2()
        {
            int[] firstHalf = { 1, 2};
            int[] secondHalf = { 1, 2, 3, 4 };
            AssetMerge(firstHalf, secondHalf, new int[] { 1, 1, 2, 2, 3, 4 });
        }

        [TestMethod()]
        public void MergeTest_3()
        {
            int[] firstHalf = { 5 };
            int[] secondHalf = { 1, 2, 3, 4 };
            AssetMerge(firstHalf, secondHalf, new int[] { 1, 2, 3, 4, 5 });
        }

        private void AssetMerge(int[] firstHalf, int[] secondHalf, int[] expectedMergeArray)
        {
            MergeSort mergeSort = new MergeSort();
            var outputArray = mergeSort.Merge(firstHalf, secondHalf);
            Assert.IsTrue(outputArray.SequenceEqual(expectedMergeArray));
        }
    }
}