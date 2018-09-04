using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanfordAlgoPart_I.DivideAndConquer
{
    public class QuickSort
    {

        public void Sort(int[] array, int startIndex, int endIndex)
        {
            if(endIndex - startIndex < 1)
                return;

            int pivotElementPos = ChoosePivot(startIndex, endIndex);
            SwapArrayElement(array, pivotElementPos, startIndex);

            int pos = Partition(array, startIndex, endIndex);

            Sort(array, startIndex, pos-1);
            Sort(array, Math.Min(pos + 1, array.Length-1), array.Length-1);
        }


        public int ChoosePivot(int startIndex, int endIndex)
        {
            //implement random selection
            return startIndex;
        }

        /// <summary>
        /// this function will place the start index element of array at 
        /// correct position of array i.e. all the elements to left should be smaller and all the elements
        /// to the right should be greater than it
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int Partition(int [] array, int startIndex, int endIndex)
        {
            if (endIndex == startIndex)
                return startIndex;

            int partitionIndex = startIndex+1;

            for (int unseenStartIndex = startIndex+1; unseenStartIndex <= endIndex; unseenStartIndex++)
            {
                if(array[unseenStartIndex] < array[startIndex])
                {
                    SwapArrayElement(array, partitionIndex, unseenStartIndex);
                    partitionIndex++;
                }
            }

            SwapArrayElement(array, startIndex, partitionIndex-1);
            return partitionIndex - 1;
        }

        private static void SwapArrayElement(int[] array, int i, int j)
        {
            int temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}
