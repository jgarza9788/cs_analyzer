using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.LearnByDoing.General
{
    public class RemoveDuplicatesProgram
    {
        public static void Main(string[] args)
        {
            // Unordered array
            // 1.) Using HashTable: https://youtu.be/H1TOX-TposY
            int[] unordered1 = { 8, 4, 4, 3, 1, 3 };
            int[] sorted1 = RemoveDuplicatesUsingHashTable(unordered1);
            PrintArray("Using HashTable", sorted1);
            // 2.) Sort then check next duplicate element.
            int[] unordered2 = { 8, 4, 4, 3, 1, 3 };
            int[] sorted2 = RemoveDuplicatesBySortingFirst(unordered2);
            PrintArray("Sort unordered array first", sorted2);

            // Ordered Array
            // 1.) By checking next element or previous element: https://youtu.be/kdAiCZQVuvI
            int[] ordered = { 1, 2, 2, 2, 3, 4, 4, 5, 5, 5, 5, 5, 6, 6, 7, 7, 7, 7, 8, 9, 10 };
            int[] sorted3 = RemoveDuplicatesByCheckingPreviousElement(ordered);
            PrintArray("Next Element", sorted3);
        }

        private static int[] RemoveDuplicatesBySortingFirst(int[] a)
        {
            Array.Sort(a);
            return RemoveDuplicatesByCheckingPreviousElement(a);
        }

        private static int[] RemoveDuplicatesByCheckingPreviousElement(int[] a)
        {
            ThrowExceptionIfArrayIsEmpty(a);

            List<int> result = new List<int>();

            // limit is "a.Length - 1" because we are checking against next element.
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] != a[i + 1])
                {
                    result.Add(a[i]);
                }
            }

            // Add the last element, which is guaranteed to be unique
            result.Add(a[a.Length - 1]);

            return result.ToArray();
        }

        private static int[] RemoveDuplicatesUsingHashTable(int[] a)
        {
            ThrowExceptionIfArrayIsEmpty(a);

            // Actually instantiating this hashset by passing unordered would have removed duplicates.
            // But we are trying to do that without using BCL (Base Class Library).
            HashSet<int> alreadySeen = new HashSet<int>();

            foreach (int item in a)
            {
                if (!alreadySeen.Contains(item))
                    alreadySeen.Add(item);
            }

            return alreadySeen.ToArray();
        }

        private static void ThrowExceptionIfArrayIsEmpty(int[] a)
        {
            if (a.Length < 0)
                throw new IndexOutOfRangeException();
        }

        private static void PrintArray(string header, int[] a)
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine(new string('=', 80));
            buffer.AppendLine(header);
            buffer.AppendLine(new string('=', 80));
            buffer.Append(string.Join(" ", a));

            Console.WriteLine(buffer);
        }
    }
}
