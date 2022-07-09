using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Remove Dups:
    /// Write code to remove duplicates from an unsorted linked list.
    /// FOLLOW UP
    /// How would you solve this problem if a temporary buffer is not allowed?
    /// </summary>
    public class Chapter2_1Test : Chapter2TestBase
    {
        private readonly Chapter2_1 _sut = new Chapter2_1();

        public Chapter2_1Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter2_1Data))]
        public void TestRemovingDuplicatesFromUnsortedLinkedList(LinkedList<int> input, LinkedList<int> expected)
        {
            LinkedList<int> actual = _sut.RemoveDuplicates(input);

            Assert.True(expected.SequenceEqual(actual));
        }

        [Theory]
        [ClassData(typeof(Chapter2_1Data))]
        public void TestRemovingDuplicatesFromUnsortedLinkedListWithoutUsingTemporaryBuffer(
            LinkedList<int> input, LinkedList<int> expected)
        {
            LinkedList<int> actual = _sut.RemoveDuplicatesWithoutTemporaryBuffer(input);

            Assert.True(expected.SequenceEqual(actual));
        }
    }
}
