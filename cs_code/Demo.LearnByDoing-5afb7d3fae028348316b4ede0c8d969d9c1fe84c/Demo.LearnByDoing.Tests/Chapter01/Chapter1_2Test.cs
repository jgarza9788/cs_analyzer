using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// 1.2 Given two strings, write a method to decide if one is a permutation of the other.
    /// </summary>
    public class Chapter1_2Test : BaseTest
    {
        private readonly Chapter1_2 _sut = new Chapter1_2();

        public Chapter1_2Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter1_2Data))]
        public void CompareIfOneTextIsAPermutationOfTheOther(string text1, string text2, bool expected)
        {
            bool actual = _sut.AreStringsPermutational(text1, text2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(Chapter1_2Data))]
        public void CompareIfOneTextIsAPermutationOfTheOtherUsingLinq(string text1, string text2, bool expected)
        {
            bool actual = _sut.AreStringsPermutationalUsingLinq(text1, text2);

            Assert.Equal(expected, actual);
        }
    }
}
