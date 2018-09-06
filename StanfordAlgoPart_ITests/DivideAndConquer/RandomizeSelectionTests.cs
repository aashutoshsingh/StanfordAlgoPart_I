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
    public class RandomizeSelectionTests
    {
        [TestMethod()]
        public void GetNthSmallestElementTest()
        {
            int[] arr = { 2, 4, 32, 5, 32, 8, 65 };
            int nthSmallest = 3;
            int expectedElement = 5;            
            AssertRandomizeSelection(arr, nthSmallest, expectedElement);
        }

        [TestMethod()]
        public void GetNthSmallestElementTest_1()
        {
            int[] arr = { 2, 4, 32, 5, 32, 8, 65 };
            int nthSmallest = 6;
            int expectedElement = 32;
            AssertRandomizeSelection(arr, nthSmallest, expectedElement);
        }

        [TestMethod()]
        public void GetNthSmallestElementTest_2()
        {
            int[] arr = { 2, 4, 32, 5, 32, 8, 65 };
            int nthSmallest = 5;
            int expectedElement = 32;
            AssertRandomizeSelection(arr, nthSmallest, expectedElement);
        }

        [TestMethod()]
        public void GetNthSmallestElementTest_3()
        {
            int[] arr = { 2, 4, 32, 5, 32, 8, 65 };
            int nthSmallest = 8;
            int expectedElement = 32;
            AssertRandomizeSelection(arr, nthSmallest, expectedElement);
        }        

        private void AssertRandomizeSelection(int [] arr, int nthSmallest, int expectedElement)
        {
            var randomizeSelection = new RandomizeSelection();
            var outputElement = randomizeSelection.GetNthSmallestElement(arr, nthSmallest);
            Assert.AreEqual(expectedElement, outputElement);
        }
    }
}