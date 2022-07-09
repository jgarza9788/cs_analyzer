using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Zocdoc
{
    /// <summary>
    /// https://www.glassdoor.com/Interview/Write-a-program-to-detect-if-a-String-is-a-palidrome-QTN_1035818.htm
    /// </summary>
    public class PalindromeCheckTest
    {
        [Theory]
        [MemberData(nameof(GetSampleInput))]
        public static void TestPalindromes(bool expected, string input)
        {
            var actual = IsPalindrome(input);
            Assert.Equal(expected, actual);
        }

        private static bool IsPalindrome(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            int start = 0;
            int end = input.Length - 1;

            // From both ends (start, end), check if the char is the same while start < end
            while (start < end)
            {
                if (char.ToUpper(input[start]) != char.ToUpper(input[end])) return false;
                start++;
                end--;
            }

            // All characters so far are the same.
            return true;
        }

        public static IEnumerable<object[]> GetSampleInput()
        {
            // edge case
            yield return new object[] { false, null };
            yield return new object[] { false, "" };

            // good
            // odd
            yield return new object[] { true, "a" };
            yield return new object[] { true, "aba" };
            yield return new object[] { true, "abcba" };
            yield return new object[] { true, "racar" };
            yield return new object[] { true, "1racar1" };
            yield return new object[] { true, "Sore was I ere I saw Eros" };
            yield return new object[] { true, "Toohottohoot" };

            // even
            yield return new object[] { true, "aa" };
            yield return new object[] { true, "abba" };
            yield return new object[] { true, "abxxba" };
            yield return new object[] { true, "abx22xba" };
            yield return new object[] { true, "Noel sees Leon" };

            // bad
            // odd
            yield return new object[] { false, "abc" };
            yield return new object[] { false, "abxxa" };
            yield return new object[] { false, "abc11ba" };
            yield return new object[] { false, "ra33cer" };
            yield return new object[] { false, "1ra22cer1" };
            yield return new object[] { false, "Soreaa was I ere I saw Eros" };
            yield return new object[] { false, "Tooc hot to choot" };

            // even                     
            yield return new object[] { false, "a1" };
            yield return new object[] { false, "ab23ba" };
            yield return new object[] { false, "abxx3ba" };
            yield return new object[] { false, "abx221xba" };
            yield return new object[] { false, "Noel 1sees2 Leon" };
        }
    }
}
