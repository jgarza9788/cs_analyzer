using System;
using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.GeeksForGeeks.DynamicProgramming.BasicProblems
{
    /// <summary>
    /// https://www.geeksforgeeks.org/longest-common-subsequence/
    /// </summary>
    public class _03_Longest_Common_Subsequence_Test
    {
        [Theory]
        [MemberData(nameof(GetSampleCases))]
        public void TestSampleCases(string text1, string text2, int expected)
        {
            var sut = new _03_Longest_Common_Subsequence();
            var actual = sut.GetLongestCommonSubsequence2(text1, text2);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetSampleCases()
        {
            yield return new object[] { "ABCDGH", " AEDFHR", 3 };
            yield return new object[] { "ABC", " AC", 2 };
            //http://lcs-demo.sourceforge.net/
            yield return new object[] { "AACDDC", " AADBAA", 3 };   // AAD
            yield return new object[] { "DCDCDD", " CCACCD", 3 };   // CCD
            yield return new object[] { "CDAABDBCDB", " CADCACBBDB", 7 };   // CDABBDB
            yield return new object[]
            {
                "LRBBMQBHCDARZOWKKYHIDDQSCDXRJMOWFRXSJYBLDBEFSARCBYNECDYGGXXPKLORELLNMPAPQFWKHOPKMCO",
                "QHNWNKUEWHSQMGBBUQCLJJIVSWMDKQTBXIXMVTRRBLJPTNSNFWZQFJMAFADRRWSOFSBCNUVQHFFBSAQXWPQCAC",
                25
            };
        }
    }

    public class _03_Longest_Common_Subsequence
    {
        public int GetLongestCommonSubsequence2(string text1, string text2)
        {
            int[,] matrix = new int[text1.Length + 1, text2.Length + 1];

            for (int i = 0; i <= text1.Length; i++)
            {
                for (int j = 0; j <= text2.Length; j++)
                {
                    if (i == 0 || j == 0) matrix[i, j] = 0;
                    else if (text1[i - 1] == text2[j - 1]) matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    else matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                }
            }

            return matrix[text1.Length, text2.Length];
        }

        // not working...
        public int GetLongestCommonSubsequence(string text1, string text2)
        {
            int nextColumnIndex = 0;
            int sequenceLength = 0;

            var row = "";
            var col = "";

            for (int r = 0; r < text1.Length; r++)
            {
                for (int c = nextColumnIndex; c < text2.Length; c++)
                {
                    var rowValue = text1[r];
                    var colValue = text2[c];

                    if (rowValue == colValue)
                    {
                        nextColumnIndex = c + 1;
                        sequenceLength++;

                        row += rowValue;
                        col += colValue;

                        break;
                    }
                }
            }

            return sequenceLength;
        }
    }
}
