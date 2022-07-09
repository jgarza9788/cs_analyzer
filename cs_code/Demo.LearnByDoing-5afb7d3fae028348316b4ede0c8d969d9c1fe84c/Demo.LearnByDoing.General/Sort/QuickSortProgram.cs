using System;
using System.Linq;

namespace Demo.LearnByDoing.General.Sort
{
    /// <summary>
    /// Using Algorithm on MyCodeSchool Youtube channel
    /// https://youtu.be/COk73cpQbFQ
    /// </summary>
    public class QuickSortProgram
    {
        public static void Main(string[] args)
        {
            int[] a = {7, 2, 1, 6, 8, 5, 3, 4};
            QuickSort(a, 0, a.Length - 1);

            a.ToList().ForEach(Console.WriteLine);
        }

        private static void QuickSort(int[] a, int start, int end)
        {
            if (start >= end) return;

            int pIndex = Partition(a, start, end);
            QuickSort(a, start, pIndex - 1);
            QuickSort(a, pIndex + 1, end);
        }

        private static int Partition(int[] a, int start, int end)
        {
            int pivot = a[end];
            // Iterates over array
            int pIndex = start;

            for (int i = start; i < end; i++)
            {
                if (a[i] <= pivot)
                {
                    Swap(a, i, pIndex);
                    pIndex++;
                }
            }

            Swap(a, pIndex, end);
            return pIndex;
        }

        private static void Swap(int[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
