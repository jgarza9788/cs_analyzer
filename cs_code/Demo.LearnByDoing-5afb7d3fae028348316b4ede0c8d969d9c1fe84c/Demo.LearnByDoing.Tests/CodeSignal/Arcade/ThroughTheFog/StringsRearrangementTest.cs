using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeSignal.Arcade.ThroughTheFog
{
    /// <summary>
    /// https://codefights.com/arcade/intro/level-7/PTWhv2oWqd6p4AHB9
    /// </summary>
    public class StringsRearrangementTest : BaseTest
    {
        public StringsRearrangementTest(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [MemberData(nameof(GetSampleCases))]
        public void TestSamples(bool expected, string[] a)
        {
            var actual = stringsRearrangement(a);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetSampleCases()
        {
            yield return new object[] { false, new[] { "q", "q" } };
            yield return new object[] { true, new[] { "abc", "bef", "bcc", "bec", "bbc", "bdc" } };
            yield return new object[] { false, new[] { "aba", "bbb", "bab" } };
            yield return new object[] { true, new[] { "ab", "bb", "aa" } };
            yield return new object[] { true, new[] { "zzzzab", "zzzzbb", "zzzzaa" } };
            yield return new object[] { false, new[] { "ab", "ad", "ef", "eg" } };
            yield return new object[] { true, new[] { "abc", "abx", "axx", "abx", "abc" } };
            yield return new object[] { true, new[] { "f", "g", "a", "h" } };
        }

        bool stringsRearrangement(string[] a)
        {
            var perms = GetPermutations(a).ToList();
            if (perms.Any(perm =>
            {
                for (int i = 0; i < perm.Length - 1; i++)
                {
                    if (!IsDifferentByOne(perm[i], perm[i + 1])) return false;
                }

                return true;
            })) return true;

            return false;
        }

        bool IsDifferentByOne(string s1, string s2)
        {
            if (s1 == s2) return false;

            bool wasDifferent = false;
            for (int i = 0; i < s1.Length; i++)
            {
                var c1 = s1[i];
                var c2 = s2[i];
                if (c1 == c2) continue;

                if (wasDifferent) return false;
                wasDifferent = true;
            }
            return true;
        }

        private static IEnumerable<string[]> GetPermutations(string[] words)
        {
            return GetPermutations(words, new List<string>());
        }

        private static IEnumerable<string[]> GetPermutations(IEnumerable<string> words, IEnumerable<string> prefix)
        {
            if (words.Count() == 0)
            {
                yield return prefix.ToArray();
            }

            var wordList = words.ToList();
            for (int i = 0; i < wordList.Count; i++)
            {
                var remainder = wordList.Take(i).Concat(wordList.Skip(i + 1));
                var nextPrefix = prefix.Concat(new[] { wordList[i] });

                foreach (var permutation in GetPermutations(remainder, nextPrefix).ToList())
                    yield return permutation;
            }
        }
    }
}
