using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeSignal.Arcade.SmoothSailing
{
    /// <summary>
    /// https://codefights.com/arcade/intro/level-3/3o6QFqgYSontKsyk4/description
    /// </summary>
    public class ReverseParenthesesTest : BaseTest
    {
        public ReverseParenthesesTest(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [MemberData(nameof(GetSampleCases))]
        public void TestSampleCases(string input, string expected)
        {
            var actual = reverseParentheses(input);
            Assert.Equal(expected, actual);
        }

        string reverseParentheses(string s)
        {
            if (s.IndexOf("(") < 0 || s.IndexOf(")") < 0)
                return s;
            return ReverseRecursively(s);
        }

        string ReverseRecursively(string s, int depth = 0)
        {
            if (s.Length == 0) return "";
            if (s == "(" || s == ")") return "";
            if (s.IndexOf("(") < 0 || s.IndexOf(")") < 0) return GetReversedString(s);

            var acc = "";
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c == '(')
                {
                    var endIndex = GetEndIndex(s, i);
                    var length = endIndex - i - 1;

                    acc += ReverseRecursively(s.Substring(i + 1, length), depth + 1);
                    i += length + 1;
                }
                else
                {
                    acc += c;
                }
            }

            return depth == 0 ? acc : GetReversedString(acc);
        }

        string GetReversedString(string value)
        {
            return string.Concat(value.Reverse());
        }

        int GetEndIndex(string s, int startIndex = 0)
        {
            var count = 0;
            for (var i = startIndex; i < s.Length; i++)
            {
                if (s[i] == '(') count++;
                if (s[i] == ')')
                {
                    count--;
                    if (count == 0) return i;
                }
            }
            throw new Exception("Could not find end index");
        }

        public static IEnumerable<object[]> GetSampleCases()
        {
            yield return new object[] { "a(bcdefghijkl(mno)p)q", "apmnolkjihgfedcbq" };
            yield return new object[] { "a(bc)de", "acbde" };
            yield return new object[] { "co(de(fight)s)", "cosfighted" };
            yield return new object[] { "Where are the parentheses?", "Where are the parentheses?" };
            yield return new object[] { "Code(Cha(lle)nge)", "CodeegnlleahC" };
            yield return new object[] { "abc(cba)ab(bac)c", "abcabcabcabc" };
            yield return new object[] { "The ((quick (brown) (fox) jumps over the lazy) dog)", "The god quick nworb xof jumps over the lazy" };
        }
    }
}
