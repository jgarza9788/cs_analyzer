using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
    /// <summary>
    /// https://www.youtube.com/watch?v=TzeBrDU-JaY
    /// </summary>
    public class MergeSortTest
    {
        [Theory]
        [MemberData(nameof(GetInput))]
        public void TestMergeSort(int[] expected, int[] input)
        {
            int[] actual = MergeSortInput(input);
            Assert.True(expected.SequenceEqual(actual));
        }

        private int[] MergeSortInput(int[] a)
        {
            if (a.Length == 1) return new[]{a[0]};

            // divide the array into left & right halfs
            int mid = a.Length / 2;
            var left = a.Take(mid).ToArray();
            var right = a.Skip(mid).ToArray();

            // Sort left & right halfs
            left = MergeSortInput(left);
            right = MergeSortInput(right);

            // merge left & right halfs and return it
            return MergeArrays(left, right);
        }

        private int[] MergeArrays(int[] left, int[] right)
        {
            var result = new List<int>();
            var leftIndex = 0;
            var rightIndex = 0;

            // Merge to the shorted array
            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                var leftValue = left[leftIndex];
                var rightValue = right[rightIndex];
                if (leftValue < rightValue)
                {
                    result.Add(leftValue);
                    leftIndex++;
                }
                else
                {
                    result.Add(rightValue);
                    rightIndex++;
                };
            }

            // Merge left over from left half
            while (leftIndex < left.Length)
            {
                result.Add(left[leftIndex++]);
            }

            // Merge left over from right half
            while (rightIndex < right.Length)
            {
                result.Add(right[rightIndex++]);
            }


            return result.ToArray();
        }

        public static IEnumerable<object[]> GetInput()
        {
            yield return new object[] { new[] { 1, 2, 3, 4, 5 }, new[] { 2, 4, 3, 5, 1 } };
            yield return new object[] { new[] { 99, 99, 101, 1002 }, new[] { 1002, 99, 101, 99 } };
        }
    }
}
