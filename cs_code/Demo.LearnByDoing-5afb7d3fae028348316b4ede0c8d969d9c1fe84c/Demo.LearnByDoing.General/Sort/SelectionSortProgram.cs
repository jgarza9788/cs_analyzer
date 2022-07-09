using System;
using System.Linq;

namespace Demo.LearnByDoing.General.Sort
{
    /// <summary>
    /// Using algorithm in https://www.youtube.com/watch?v=f8hXR_Hvybo
    /// </summary>
    public class SelectionSortProgram
    {
        public static void Main(string[] args)
        {
            int[] unsorted = { 23, 42, 4, 16, 8, 15 };

            int[] sorted = SelectionSort(unsorted);
            PrintSorted(sorted);
        }

        private static int[] SelectionSort(int[] unsorted)
        {
            for (int i = 0; i < unsorted.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < unsorted.Length; j++)
                {
                    if (unsorted[minIndex] > unsorted[j])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                    Swap(unsorted, minIndex, i);
            }

            return unsorted;
        }

        private static void Swap(int[] unsorted, int i, int j)
        {
            var temp = unsorted[i];
            unsorted[i] = unsorted[j];
            unsorted[j] = temp;
        }

        private static void PrintSorted(int[] sorted)
        {
            sorted.ToList().ForEach(Console.WriteLine);
        }
    }
}
