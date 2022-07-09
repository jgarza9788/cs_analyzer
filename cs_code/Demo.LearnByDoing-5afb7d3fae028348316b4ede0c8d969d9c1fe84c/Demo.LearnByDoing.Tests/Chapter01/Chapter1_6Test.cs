using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// String Comparison:
    /// Implement a method to perform basic string compression using the counts of repeated characters.
    /// For example, the string aabcccccaaa would become a2b1c5a3.
    /// If "compressed" string would not become smaller than the original string, your method should return the original string.
    /// You can assume the string has only uppercase and lowercase letters (1-z).
    /// </summary>
    public class Chapter1_6Test : BaseTest
    {
        private readonly Chapter1_6 _sut = new Chapter1_6();

        public Chapter1_6Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter1_6Data))]
        public void TestCompression(string text, string expected)
        {
            string actual = _sut.CompressText(text);

            Assert.Equal(expected, actual);
        }
    }
}
