using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.GeeksForGeeks.DynamicProgramming.BasicProblems
{
    public class LongestCommonSubsequenceTest
    {
        public static IEnumerable<object[]> GetTestCases()
        {
            yield return new object[] { new[] { 'b' }, "aba", "dbcc" };
            yield return new object[] { new char[] { }, "aaa", "bbb" };

            yield return new object[] { new[] { 'a', 'b', 'c', 'f' }, "acbcf", "abcdaf" };
            yield return new object[] { new[] { 'a', 'a' }, "aaa", "aab" };
            yield return new object[] { new char[] { }, "", "" };
            yield return new object[] { new char[] { }, "", null };
            yield return new object[] { new char[] { }, null, "" };
            yield return new object[] { new char[] { }, null, null };
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void TestHappyPaths(char[] expected, string text1, string text2)
        {
            var actual = GetLongestCommonSubsequence(text1, text2);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<char> GetLongestCommonSubsequence(string text1, string text2)
        {
            // Guard against edge cases
            if (new[] { text1, text2 }.Any(string.IsNullOrWhiteSpace)) return new char[] { };

            // Generate the matrix
            var matrix = BuildMatrix(text1, text2);

            // Build the path from matrix
            var path = BuildPath(matrix, text1, text2);

            return path;
        }

        private IEnumerable<char> BuildPath(int[,] m, string t1, string t2)
        {
            // characters to return
            var stack = new Stack<char>();

            for (int r = m.GetLength(0) - 1; r >= 1;)
            {
                for (int c = m.GetLength(1) - 1; c >= 1;)
                {
                    // if the value is the max of left or top cell, the we skip
                    // else we add it to the stack to return
                    var topValue = m[r - 1, c];
                    var leftValue = m[r, c - 1];
                    var curr = m[r, c];

                    if (curr == topValue)
                        r--;
                    else if (curr == leftValue)
                        c--;
                    else
                    {
                        stack.Push(t1[r - 1]);
                        r--;
                        c--;
                    }

                    if (r < 1) break;
                }
            }

            return stack.ToArray();
        }

        private int[,] BuildMatrix(string text1, string text2)
        {
            var matrix = new int[text1.Length + 1, text2.Length + 1];

            for (int r = 1; r <= text1.Length; r++)
            {
                for (int c = 1; c <= text2.Length; c++)
                {
                    var rowCharacter = text1[r - 1];
                    var colCharacter = text2[c - 1];

                    // Get the max between top or left cell value
                    var cellValue = Math.Max(matrix[r - 1, c], matrix[r, c - 1]);
                    // Set the current cell value to that of top left cell value + 1
                    if (rowCharacter == colCharacter)
                        cellValue = matrix[r - 1, c - 1] + 1;

                    matrix[r, c] = cellValue;
                }
            }

            return matrix;
        }
    }
}
