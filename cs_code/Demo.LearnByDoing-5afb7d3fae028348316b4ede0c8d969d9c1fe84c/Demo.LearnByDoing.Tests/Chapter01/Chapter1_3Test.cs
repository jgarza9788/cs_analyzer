using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// URLify: Wirte a method to replace all spaces in a string with '%20'. 
    /// You may assume that the string has sufficient space at the end to hold the additional characters, 
    /// and that you are given the "true" length of the string. 
    /// (Note: If implementing in Java, please use a chracter array so that you can perform this operation in place.)
    /// 
    /// EXAMPLE
    /// Input       "Mr John Smith    ", 13
    /// Output      "Mr%20John%20Smith"
    /// </summary>
    public class Chapter1_3Test : BaseTest
    {
        private readonly Chapter1_3 _sut = new Chapter1_3();

        public Chapter1_3Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter1_3Data))]
        public void TestUrlifyingText(string text, int trueLength, string expected)
        {
            string actual = _sut.UrlifyString(text, trueLength);

            Assert.Equal(expected, actual);
        }
    }
}
