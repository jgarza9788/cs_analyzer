using System;
using System.Linq;

namespace Demo.LearnByDoing.General.Sort
{
    /// <summary>
    /// Binary search using code from Cracking the Coding Interview Chapter 10
    /// </summary>
    public class BinarySearchProgram
    {
        public static void Main(string[] args)
        {
            int[] a = Enumerable.Range(0, 100).ToArray();
            int[] searchValues = { 3, 5, 22, 55, 99, 100 };

            foreach (int searchValue in searchValues)
            {
                int searchIndex = BinarySearch(a, searchValue);
                Console.WriteLine("value({0}) => index({1})", searchValue, searchIndex);
            }

            foreach (int searchValue in searchValues)
            {
                int searchIndex = BinarySearchRecursive(a, searchValue, 0, a.Length - 1);
                Console.WriteLine("Recursion: value({0}) => index({1})", searchValue, searchIndex);
            }
        }

        private static int BinarySearchRecursive(int[] a, int x, int low, int high)
        {
            if (low > high) return -1;  // could not find.

            int mid = (low + high) / 2;
            if (a[mid] < x) return BinarySearchRecursive(a, x, mid + 1, high);
            if (a[mid] > x) return BinarySearchRecursive(a, x, low, mid - 1);

            return mid;
        }

        private static int BinarySearch(int[] a, int x)
        {
            int low = 0;
            int high = a.Length - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;

                if (a[mid] < x)
                    low = mid + 1;
                else if (a[mid] > x)
                    high = mid - 1;
                else
                    return mid;
            }

            return -1;
        }
    }
}
