using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// 1.1 Implement an algorithm to determine if a string has all unique characters.
    /// What if you cannot use additional data structures?
    /// </summary>
    public class Chapter1_1Test : BaseTest
    {
        private readonly Chapter1_1 _sut = new Chapter1_1();

        public Chapter1_1Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("abc", true)]
        [InlineData("abcc", false)]
        [InlineData("xyz", true)]
        [InlineData("hello world", false)]
        [InlineData("the quick brown fox jumped over the lazy dog", false)]
        public void TextHasUniqueCharacters(string text, bool expected)
        {
            bool actual = _sut.HasUniqueCharacters(text);

            Assert.Equal(expected, actual);
        }
    }
}
