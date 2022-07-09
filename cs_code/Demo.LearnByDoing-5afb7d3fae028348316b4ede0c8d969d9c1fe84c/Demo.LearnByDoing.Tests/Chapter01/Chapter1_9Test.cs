using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// String Rotation:
    /// Assume you have a method isSubstring which checks if one word is a substring of another.
    /// Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one call to isSubstring
    /// (e.g., "waterbottle" is a rotation of "erbottlewat").
    /// </summary>
    /// <remarks>
    /// Sung's algorithm (cheated because I saw the hints):
    /// Combine S2 with itself: erbottlewat -> erbottlewaterbottlewat
    /// for each character in s2 concatenated,
    ///    up to the length of s1, check if each letter in s1 matches that in s2 concatenated.
    ///    if it matches up to the length of s1, then return true, else false
    /// </remarks>
    public class Chapter1_9Test : BaseTest
    {
        private readonly Chapter1_9 _sut = new Chapter1_9();

        public Chapter1_9Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter1_9Data))]
        public void TestIfSubstringIsRotation(string s1, string s2, bool expected)
        {
            bool actual = _sut.IsRotationSubstring(s1, s2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(Chapter1_9Data))]
        public void TestIfSubstringIsRotation2(string s1, string s2, bool expected)
        {
            bool actual = _sut.IsRotationSubstring2(s1, s2);

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter1_9
    {
        public bool IsRotationSubstring2(string s1, string s2)
        {
            if (string.IsNullOrWhiteSpace(s1) || 
                string.IsNullOrWhiteSpace(s2) || 
                s1.Length != s2.Length) return false;

            var s2Concatenated = s2 + s2;
            for (int i = 0; i < s2Concatenated.Length; i++)
            {
                StringBuilder temp1 = new StringBuilder(s1.Length);
                StringBuilder temp2 = new StringBuilder(s1.Length);

                int offset = i;
                for (int j = 0; j < s1.Length; j++)
                {
                    temp1.Append(s1[j]);
                    temp2.Append(s2Concatenated[offset]);

                    if (temp1.ToString() == temp2.ToString())
                    {
                        if (temp1.Length == s1.Length) return true;

                        offset++;
                        continue;
                    }

                    break;
                }
            }

            return false;
        }

        public bool IsRotationSubstring(string s1, string s2)
        {
            if (string.IsNullOrWhiteSpace(s1) || string.IsNullOrWhiteSpace(s2)) return false;

            var s2Concatenated = s2 + s2;
            int startIndex = s2Concatenated.IndexOf(s1, StringComparison.Ordinal);
            if (startIndex < 0) return false;

            return s2Concatenated.Substring(startIndex, s1.Length) == s1;
        }
    }

    public class Chapter1_9Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "waterbottle", "erbottlewat", true },
            new object[] { "abcde", "bcdea", true },
            new object[] { "eabcd", "abcde", true },
            // different length
            new object[] { "aaabbb", "aaabb", false },
            new object[] { "xxxcyyy", "xxcyyy", false },
            // completely different: not even a rotation
            new object[] { "12345", "54322", false },
            new object[] { "a", "b", false },
            // Empty case tests
            new object[] { "", "b", false },
            new object[] { "a", "", false },
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
