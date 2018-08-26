using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanfordAlgoPart_I
{
    public class CountingInversion
    {
        public Tuple<int[], int> SortAndCount(int[] array)
        {
            if (array.Length <= 1)
                return new Tuple<int[], int>(array, 0);

            var size = array.Length;

            var firstHalf = SortAndCount(array.Take(size / 2).ToArray());
            var secondHalf = SortAndCount(array.Skip(size / 2).ToArray());
            var split = MergeAndCountSplitInversion(firstHalf.Item1, secondHalf.Item1);

            return new Tuple<int[], int>(split.Item1, firstHalf.Item2 + secondHalf.Item2 + split.Item2); 
        }

        public Tuple<int[],int> MergeAndCountSplitInversion(int[] firstHalfArray, int[] secondHalfArray)
        {
            if (firstHalfArray == null && secondHalfArray == null)
                return new Tuple<int[], int>(null, 0);
            if (firstHalfArray == null)
                return new Tuple<int[], int>(secondHalfArray, 0);
            if (secondHalfArray == null)
                return new Tuple<int[], int>(firstHalfArray, 0);

            int[] outputArray = new int[firstHalfArray.Length + secondHalfArray.Length];
            if (outputArray.Length == 0)
                return new Tuple<int[], int>(null, 0);

            int firstHalfPointer = 0;
            int secondHalfPointer = 0;
            int splitCount = 0;

            for (int i = 0; i < outputArray.Length; i++)
            {
                if (firstHalfPointer == firstHalfArray.Length)
                {
                    outputArray[i] = secondHalfArray[secondHalfPointer];
                    secondHalfPointer++;
                    continue;
                }

                if (secondHalfPointer == secondHalfArray.Length)
                {
                    outputArray[i] = firstHalfArray[firstHalfPointer];
                    firstHalfPointer++;
                    continue;
                }

                if (firstHalfArray[firstHalfPointer] <= secondHalfArray[secondHalfPointer])
                {
                    outputArray[i] = firstHalfArray[firstHalfPointer];
                    firstHalfPointer++;
                }
                else
                {
                    outputArray[i] = secondHalfArray[secondHalfPointer];
                    splitCount += firstHalfArray.Length - firstHalfPointer;
                    secondHalfPointer++;
                }
            }
            return new Tuple<int[],int> (outputArray, splitCount);
        }
    }
}
