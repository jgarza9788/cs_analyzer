using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
    /// <summary>
    /// https://www.youtube.com/watch?v=COk73cpQbFQ
    /// </summary>
    public class QuickSortTest
    {
        [Theory]
        [MemberData(nameof(GetInput))]
        public void TestQuickSort(int[] expected, int[] input)
        {
            QuickSortInput(input, 0, input.Length - 1);
            Assert.True(expected.SequenceEqual(input));
        }

        /// <summary>
        /// void because it uses In-place sorting
        /// </summary>
        private void QuickSortInput(int[] a, int start, int end)
        {
            // return condition
            if (start < end)
            {
                // Parition the array
                var partitionIndex = Partition(a, start, end);

                // Sort left half
                QuickSortInput(a, start, partitionIndex - 1);
                // Sort right half
                QuickSortInput(a, partitionIndex + 1, end);
            }
        }

        private int Partition(int[] a, int start, int end)
        {
            var result = start;
            var pivot = a[end];
            for (int i = start; i < end; i++)
            {
                if (a[i] <= pivot)
                {
                    Swap(a, i, result);
                    result++;
                }
            }

            Swap(a, result, end);

            return result;
        }

        private void Swap(int[] a, int i1, int i2)
        {
            var temp = a[i1];
            a[i1] = a[i2];
            a[i2] = temp;
        }

        public static IEnumerable<object[]> GetInput()
        {
            yield return new object[] { new[] { 1, 2, 3, 4, 5 }, new[] { 2, 4, 3, 5, 1 } };
            yield return new object[] { new[] { 99, 99, 101, 1002 }, new[] { 1002, 99, 101, 99 } };
        }
    }
}
