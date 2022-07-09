using System;

namespace Demo.LearnByDoing.General.Sort
{
    /// <summary>
    /// How many times is a sorted array rotated?
    /// https://youtu.be/4qjprDkJrjY?list=PL2_aWCzGMAwLPEZrZIcNEq9ukGWPfLT4A
    /// </summary>
    public class SortedArrayRotationCountProgram
    {
        public static void Main(string[] args)
        {
            int[] a = {11, 12, 15, 18, 2, 5, 6, 8}; // rotated 4 times
            int rotationCount = GetRotationCount(a);
            Console.WriteLine("Rotated {0} times", rotationCount);
        }

        private static int GetRotationCount(int[] a)
        {
            int low = 0;
            int high = a.Length - 1;

            while (low <= high)
            {
                if (a[low] <= a[high]) return low;

                int mid = (low + high) / 2;
                int next = (mid + 1) % a.Length;
                int prev = (mid + a.Length - 1) % a.Length;

                if (a[mid] <= a[next] && a[mid] <= a[prev]) return mid;
                else if (a[mid] <= a[high]) high = mid - 1;
                else if (a[mid] >= a[low]) low = mid + 1;
            }

            return -1;
        }
    }
}
