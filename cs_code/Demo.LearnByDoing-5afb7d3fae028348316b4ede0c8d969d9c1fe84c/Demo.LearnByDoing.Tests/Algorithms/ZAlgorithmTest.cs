using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.Algorithms
{
    /// <summary>
    /// Z-Algorithm by Tusha Roy
    /// https://www.youtube.com/watch?v=CpZh4eF8QBw&list=RDCpZh4eF8QBw&start_radio=1
    /// 
    /// I understand the concept but haven't come up with the implementation myself, yet.
    /// </summary>
    public class ZAlgorithmTest
    {
        [Theory]
        [MemberData(nameof(GetSamples))]
        public void TestSamples(int[] expected, string input)
        {
            var actual = BuildZArray(input);
            Assert.True(expected.SequenceEqual(actual));
        }

        private int[] BuildZArray(string input)
        {
            var z = new int[input.Length];
            var left = 0;
            var right = 0;

            for (int k = 1; k < input.Length; k++)
            {
                if (k > right)
                {
                    left = k;
                    right = k;
                    while (right < input.Length && input[right] == input[right - left])
                    {
                        right++;
                    }

                    z[k] = right - left;
                    right--;
                }
                else
                {
                    // we are operating inside box
                    var k1 = k - left;
                    // if value does not stretch till right bound then just copy it
                    if (z[k1] < right - k + 1)
                    {
                        z[k] = z[k1];
                    }
                    else
                    {
                        left = k;
                        while (right < input.Length && input[right] == input[right - left])
                        {
                            right++;
                        }

                        z[k] = right - left;
                        right--;
                    }
                }
            }

            return z;
        }

        /// <summary>
        /// Samples from the video.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetSamples()
        {
            yield return new object[] { new[] { 0, 0, 1, 0, 3, 0, 2, 0 }, "abaxabab" };
            yield return new object[] { new[] { 0, 1, 0, 0, 2, 1, 0, 3, 1, 0 }, "aabxaayaab" };
            yield return new object[] { new[] { 0, 0, 0, 0, 0, 3, 0, 0, 2, 0, 0, 3, 0, 0 }, "abc$xabcabzabc" };
            yield return new object[] { new[] { 0, 1, 0, 0, 4, 1, 0, 0, 0, 8, 1, 0, 0, 5, 1, 0, 0, 1, 0 }, "aabxaabxcaabxaabxay" };
        }
    }
}
