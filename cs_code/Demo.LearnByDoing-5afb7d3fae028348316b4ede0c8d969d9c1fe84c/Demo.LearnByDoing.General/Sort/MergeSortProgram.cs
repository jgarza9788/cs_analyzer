using System;
using System.Linq;

namespace Demo.LearnByDoing.General.Sort
{
    /// <summary>
    /// https://www.youtube.com/watch?v=EeQ8pwjQxTM and Cracking the Coding Interview Chapter 10
    /// </summary>
    class MergeSortProgram
    {
        public static void Main(string[] args)
        {
            int[] a = {108, 15, 50, 4, 8, 42, 23, 16};
            //int[] a = {1, 4, 5, 2, 8, 9};
            int[] helper = new int[a.Length];
            int low = 0;
            int high = a.Length - 1;

            MergeSort(a, helper, low, high, "start");
            a.ToList().ForEach(Console.WriteLine);
        }

        private static void MergeSort(int[] a, int[] helper, int low, int high, string hint)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                Console.WriteLine("{0}, low={1}, middle={2}, high={3}", hint, low, middle, high);

                MergeSort(a, helper, low, middle, "left");       // sort left half
                MergeSort(a, helper, middle + 1, high, "right");  // sort right half
                Merge(a, helper, low, middle, high, "end");
            }
        }

        private static void Merge(int[] a, int[] helper, int low, int middle, int high, string hint)
        {
            // copy both halves into a helper array
            for (int i = low; i <= high; i++)
            {
                helper[i] = a[i];
            }

            string[] strings = helper.Select(x => x.ToString()).ToArray();
            Console.WriteLine("\t{0}:{1}, low={2}, middle={3}, high={4}", 
                hint, string.Join(" ", strings), low, middle, high);

            int helperLeft = low;
            int helperRight = middle + 1;
            int current = low;

            // Iterate through helper array. 
            // Compare the left and right half, 
            // copying back the smaller element from the two halves into the orignal array
            while (helperLeft <= middle && helperRight <= high)
            {
                if (helper[helperLeft] <= helper[helperRight])
                {
                    a[current] = helper[helperLeft];
                    helperLeft++;
                }
                // Right element is smaller than left element so we copy the right one
                else
                {
                    a[current] = helper[helperRight];
                    helperRight++;
                }

                current++;
            }


            var strings2 = string.Join(" ", a.Select(x => x.ToString()).ToArray());
            var strings3 = string.Join(" ", helper.Select(x => x.ToString()).ToArray());
            int remaining = middle - helperLeft;

            Console.WriteLine("\tCopy from {0} to {1} i = {2} to remaining = {3}", strings2, strings3, 0, remaining);

            // copy the rest of the left side of the array into the target array
            // ToDO: I don't really understand this part, yet.
            for (int i = 0; i <= remaining; i++)
            {
                a[current + i] = helper[helperLeft + i];
            }
        }
    }
}
