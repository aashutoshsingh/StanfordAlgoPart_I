using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanfordAlgoPart_I.DivideAndConquer
{
    public class RandomizeSelection
    {
        public int GetNthSmallestElement(int[] array, int index)
        {
            if (index < 1 || index > array.Length)
                throw new ArgumentOutOfRangeException("Index cannot be less than 0 or more than or equal to size of array");

            if (array.Length == 1)
                return array[0];

            QuickSort quickSort = new QuickSort();
            int pos = quickSort.Partition(array, 0, array.Length-1);
            pos++;//make it 1 based from zero based

            if (pos == index)
                return array[pos-1];//while returning we should return element based on 0 based indexing
            else if (pos > index)
                return GetNthSmallestElement(array.Take(pos).ToArray(), index);
            else if (pos < index)
                return GetNthSmallestElement(array.Skip(pos).ToArray(), index - pos);

            return -1;
        }
    }
}
