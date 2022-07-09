using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Delete Middle Node:
    /// Implement an algorithm to delete a node in the middle
    /// (i.e., any node but the first and last node, not necessarily the exact middle)
    /// of a singly linked list, given only access to that node
    /// 
    /// EXAMPLE
    /// Input:  the node c from the linked list 
    ///         a -> b -> c -> d -> e -> f
    /// Result: nothing is returned, but the new linked list looks like 
    ///         a -> b -> d -> e -> f 
    /// </summary>
    public class Chapter2_3Test : Chapter2TestBase
    {
        private readonly Chapter2_3 _sut = new Chapter2_3();

        public Chapter2_3Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter2DataLength))]
        public void TestGettingSinglyLinkedListLength(Node<string> input, int expected)
        {
            int actual = _sut.GetNodeCount(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(Chapter2DataMiddle))]
        public void TestGettingMiddleNodesOnly(Node<string> input, Node<string> expected)
        {
            Node<string> actual = _sut.GetMiddleNodes(input);

            Assert.True(AreNodesEqual(expected, actual));
        }

        [Theory]
        [ClassData(typeof(Chapter2DataRemoveMiddle))]
        public void TestRemovingMiddleNode(string middleValue, Node<string> input, Node<string> expected)
        {
            Node<string> actual = _sut.RemoveMiddelValue(middleValue, input);

            Assert.True(AreNodesEqual(expected, actual));
        }
    }
}
