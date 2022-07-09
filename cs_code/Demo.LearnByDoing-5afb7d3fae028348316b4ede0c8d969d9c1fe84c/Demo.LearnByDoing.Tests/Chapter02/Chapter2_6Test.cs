using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Palindrome:
    /// Implement a function to check if a linked list is a palindrome
    /// </summary>
    public class Chapter2_6Test : Chapter2TestBase
    {
        private readonly Chapter2_6 _sut = new Chapter2_6();

        public Chapter2_6Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter2_6Data))]
        public void TestIfNodeIsPalindromic(Node<int> node, bool expected)
        {
            bool actual = _sut.IsNodePalindrome(node);

            Assert.Equal(expected, actual);
        }
    }
}
