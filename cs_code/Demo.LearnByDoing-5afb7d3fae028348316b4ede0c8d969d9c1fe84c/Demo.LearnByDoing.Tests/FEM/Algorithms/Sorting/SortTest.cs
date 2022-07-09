using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.FEM.Algorithms.Sorting
{
    public class SortTest
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { new[] { 1, 2, 3, 4, 5 }, new[] { 5, 2, 3, 4, 1 } };
            yield return new object[] { new[] { 11, 22, 33, 44, 55 }, new[] { 55, 44, 33, 22, 11 } };
            yield return new object[] { new[] { 1, 2, 3, 8, 9, 24, 33 }, new[] { 8, 33, 9, 1, 24, 3, 2 } };
            yield return new object[] { new[] { 1, 2, 3, 8, 9, 24, 33, 99 }, new[] { 8, 33, 9, 1, 99, 24, 3, 2 } };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void TestQuickSort(int[] expected, int[] a)
        {
            QuickSort(a, 0, a.Length - 1);
            Assert.True(expected.SequenceEqual(a));
        }

        private void QuickSort(int[] a, int start, int end)
        {
            if (start < end)
            {
                int partitionIndex = Partition(a, start, end);
                QuickSort(a, start, partitionIndex - 1);
                QuickSort(a, partitionIndex + 1, end);
            }
        }

        private int Partition(int[] a, int start, int end)
        {
            int pivot = a[end];
            int partitionIndex = start;

            for (int i = start; i < end; i++)
            {
                if (a[i] <= pivot)
                {
                    Swap(a, i, partitionIndex);
                    partitionIndex++;
                }
            }

            Swap(a, partitionIndex, end);

            return partitionIndex;
        }

        /// <remarks>
        /// Algorithm:
        /// 
        ///     MergeSort(a)
        ///         If a.length -lte 1 return a[0]
        ///     
        ///         leftSegment = a[0...mid]
        ///         rightSegment = a[mid...end]
        /// 
        ///         left = MergeSort(leftSegment)
        ///         right = MergeSort(rightSegement)
        /// 
        ///         return Merge(left, right)
        /// 
        ///     
        ///     Merge(left, right)
        ///         result = [], leftIndex = 0, rightIndex = 0
        /// 
        ///         while (result.length -lt leftIndex + rightIndex
        ///             if (leftIndex == left.Length) copy right to result
        ///             elseif (rightIndex == right.Length) copy left to result
        ///             elseif (left[leftIndex] -lte right[rightIndex] then copy left[leftIndex] to result and increment leftIndex
        ///             else copy right[rightIndex] to result and increment rightIndex
        /// 
        /// </remarks>>
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void TestMergeSort(int[] expected, int[] a)
        {
            var actual = MergeSort(a).ToList();
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<int> MergeSort(int[] a)
        {
            if (a.Length <= 1)
            {
                yield return a[0];
                yield break;
            }

            var mid = a.Length / 2;
            var leftSegment = a.Take(mid).ToArray();
            var rightSegment = a.Skip(mid).ToArray();

            var left = MergeSort(leftSegment).ToList();
            var right = MergeSort(rightSegment).ToList();

            foreach (var _ in Merge(left, right).ToList()) yield return _;
        }

        private IEnumerable<int> Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();
            int leftIndex = 0;
            int rightIndex = 0;

            while (result.Count < left.Count + right.Count)
            {
                if (leftIndex == left.Count) result.AddRange(right.Skip(rightIndex));
                else if (rightIndex == right.Count) result.AddRange(left.Skip(leftIndex));
                else if (left[leftIndex] <= right[rightIndex]) result.Add(left[leftIndex++]);
                else result.Add(right[rightIndex++]);
            }

            return result;
        }

        /// <remarks>
        /// Algorithm: 
        ///     while end is not reached,
        ///         while current element is smaller than the previous, move it to the left.
        /// </remarks>
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void TestInsertionSort(int[] expected, int[] input)
        {
            var actual = InsertionSort(input);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<int> InsertionSort(int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                int curr = input[i];
                for (int j = 0; j < i; j++)
                {
                    int prev = input[j];
                    if (curr < prev)
                    {
                        Swap(input, i, j);
                    }
                }
            }

            return input;
        }

        /// <remarks>
        /// Algorithm: 
        ///     while index is less than the input array length - 1,
        ///         find the smallest element.
        ///         if the smallest element index is larger than the current index, then swap
        /// 
        ///     return the input array.
        /// </remarks>
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void TestSelectionSort(int[] expected, int[] input)
        {
            var actual = SelectionSort(input);
            Assert.True(expected.SequenceEqual(actual));
        }

        private int[] SelectionSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int min = input[i];
                int minIndex = i;

                for (int j = i + 1; j < input.Length; j++)
                {
                    int curr = input[j];
                    if (curr < min)
                    {
                        min = curr;
                        minIndex = j;
                    }
                }

                Swap(input, i, minIndex);
            }

            return input;
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void TestBubbleSort(int[] expected, int[] input)
        {
            var actual = BubbleSort(input);
            Assert.True(expected.SequenceEqual(actual));
        }

        /// <summary>
        /// Sort using BubbleSort
        /// </summary>
        /// <remarks>
        /// Algorithm:
        ///     for i = 1 to n - 1
        ///         for j = 0 to n - 2
        ///             if next > prev then swap next & prev
        /// </remarks>
        private IEnumerable<int> BubbleSort(int[] input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j <= input.Length - 1; j++)
                {
                    if (input[i] > input[j])
                        Swap(input, i, j);
                }
            }

            return input;
        }
        void Swap(int[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
