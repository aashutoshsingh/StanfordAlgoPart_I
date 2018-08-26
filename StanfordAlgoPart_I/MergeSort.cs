using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanfordAlgoPart_I
{
    public class MergeSort
    {

        public int[] Sort(int[] array)
        {
            if (array.Length <= 1)
                return array;

            var size = array.Length;

            var firstHalf = Sort(array.Take(size / 2).ToArray());
            var secondHalf = Sort(array.Skip(size / 2).ToArray());
            return Merge(firstHalf, secondHalf);
        }

        public int [] Merge(int [] firstHalf, int [] secondHalf)
        {
            if (firstHalf == null && secondHalf == null)
                return null;
            if (firstHalf == null)
                return secondHalf;
            if (secondHalf == null)
                return firstHalf;

            int[] outputArray = new int[firstHalf.Length + secondHalf.Length];
            if (outputArray.Length == 0)
                return outputArray;

            int firstHalfPointer = 0;
            int secondHalfPointer = 0;

            for (int i = 0; i < outputArray.Length; i++)
            {
                if (firstHalfPointer == firstHalf.Length)
                {
                    outputArray[i] = secondHalf[secondHalfPointer];
                    secondHalfPointer++;
                    continue;
                }

                if (secondHalfPointer == secondHalf.Length)
                {
                    outputArray[i] = firstHalf[firstHalfPointer];
                    firstHalfPointer++;
                    continue;
                }

                if (firstHalf[firstHalfPointer] <= secondHalf[secondHalfPointer])
                {
                    outputArray[i] = firstHalf[firstHalfPointer];
                    firstHalfPointer++;
                }
                else
                {
                    outputArray[i] = secondHalf[secondHalfPointer];
                    secondHalfPointer++;
                }
            }
            return outputArray;
        }
    }
}
