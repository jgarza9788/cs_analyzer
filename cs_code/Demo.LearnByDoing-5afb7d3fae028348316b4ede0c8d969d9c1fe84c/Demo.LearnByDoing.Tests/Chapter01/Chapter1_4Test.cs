using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// Palindrome Permutation:
    /// Given a string, write a function to check if it is a permutation of a palindrome.
    /// A palindrome is a word or phrase that is the same forwards and backwards. 
    /// A permutation is a rearrangement of letters.
    /// The palindrome does not need to be limited to just dictionary words.
    /// 
    /// EXAMPLE
    /// Input:  Tact Coa
    /// Output  True (permutations: "taco cat", "atco cta", etc.)
    /// </summary>
    public class Chapter1_4Test : BaseTest
    {
        private readonly Chapter1_4 _sut = new Chapter1_4();

        public Chapter1_4Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("Tact Coa", false)]
        [InlineData("taco cat", true)]
        [InlineData("atco cta", true)]
        [InlineData("race car", true)]
        [InlineData("civic", true)]
        [InlineData("aabbcc bbaa", true)]
        [InlineData("aa", true)]
        [InlineData("a", true)]
        [InlineData("ab", false)]
        [InlineData("abc", false)]
        [InlineData("abcd", false)]
        public void IsPalindrome(string text, bool expected)
        {
            bool actual = _sut.IsPalindrome(text);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(Chapter1_4Data))]
        public void CheckIfTextCanBeAPalindrome(string text, bool expected)
        {
            bool actual = _sut.HasPalindrome(text);

            Assert.Equal(expected, actual);
        }

        //[Theory]
        //public void TestForPalindromenessOfText(string text, bool expected)
        //{
        //    bool actual = _sut.
        //}
    }
}
