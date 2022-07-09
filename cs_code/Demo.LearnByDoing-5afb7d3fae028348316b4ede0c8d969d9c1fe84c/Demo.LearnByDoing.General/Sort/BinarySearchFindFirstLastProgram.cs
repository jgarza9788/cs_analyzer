using System;

namespace Demo.LearnByDoing.General.Sort
{
    /// <summary>
    /// Count occurrences of a number in a sorted array with duplicates using Binary Search
    /// https://youtu.be/pLT_9jwaPLs?list=PL2_aWCzGMAwLPEZrZIcNEq9ukGWPfLT4A
    /// </summary>
    public class BinarySearchFindFirstLastProgram
    {
        public static void Main(string[] args)
        {
            int searchValue = int.Parse(Console.ReadLine());

            int[] a = {1, 1, 3, 3, 5, 5, 5, 5, 5, 9, 9, 11};
            Tuple<int, int> occurrences = GetFirstLastOccurrences(a, searchValue);

            Console.WriteLine("From {0} to {1}", occurrences.Item1, occurrences.Item2);
        }

        private static Tuple<int, int> GetFirstLastOccurrences(int[] a, int searchValue)
        {
            int firstOccurrence = BinarySearch(a, searchValue, searchFirst: true);
            int lastOccurrence = BinarySearch(a, searchValue, searchFirst: false);

            return Tuple.Create(firstOccurrence, lastOccurrence);
        }

        private static int BinarySearch(int[] a, int searchValue, bool searchFirst = true)
        {
            int low = 0;
            int high = a.Length - 1;
            int mid = (low + high) / 2;

            int result = -1;
            while (low <= high)
            {
                mid = (low + high) / 2;

                if (a[mid] == searchValue)
                {
                    result = mid;
                    if (searchFirst)
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
                else if (a[mid] < searchValue)
                {
                    low = mid + 1;
                }
                else if (a[mid] > searchValue)
                {
                    high = mid - 1;
                }
            }

            return result;
        }
    }
}
