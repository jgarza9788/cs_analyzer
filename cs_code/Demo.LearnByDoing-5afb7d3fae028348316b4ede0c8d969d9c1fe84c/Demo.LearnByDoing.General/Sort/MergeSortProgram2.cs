using System;
using System.Linq;

namespace Demo.LearnByDoing.General.Sort
{
    /// <summary>
    /// Second attempt to understand Merge Sort from Youtube video
    /// https://youtu.be/TzeBrDU-JaY
    /// 
    /// <seealso cref="https://www.khanacademy.org/computing/computer-science/algorithms/merge-sort/a/overview-of-merge-sort"/>
    /// </summary>
    public class MergeSortProgram2
    {
        public static void Main(string[] args)
        {
            int[] a = {2, 4, 1, 6, 8, 5, 3, 7};

            MergeSort(a);
            a.ToList().ForEach(Console.WriteLine);
        }

        private static void MergeSort(int[] a)
        {
            int n = a.Length;
            if (n < 2) return;

            int mid = n / 2;
            var left = new int[mid];
            var right = new int[n - mid];

            for (int i = 0; i < mid; i++)
            {
                left[i] = a[i];
            }

            for (int i = mid; i < n; i++)
            {
                right[i - mid] = a[i];
            }

            MergeSort(left);
            MergeSort(right);

            Merge(left, right, a);
        }

        private static void Merge(int[] left, int[] right, int[] a)
        {
            int nL = left.Length;
            int nR = right.Length;
            int i = 0, j = 0, k = 0;

            while (i < nL && j < nR)
            {
                if (left[i] <= right[j])
                {
                    a[k] = left[i];
                    i++;
                }
                else
                {
                    a[k] = right[j];
                    j++;
                }

                k++;
            }

            // If left has left over, then copy them over
            while (i < nL)
            {
                a[k] = left[i];
                i++;
                k++;
            }

            // If right has left over, then copy them over
            while (j < nR)
            {
                a[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
