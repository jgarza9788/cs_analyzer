using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Sum Lists:
    /// You have two numers represented by a linked list,
    /// where each node contains a single digit.
    /// The digits are stored in reverse order, such that the 1's digit is at the head of the list.
    /// Write a function that adds the two numbers and returns the sum as a linked list.
    /// 
    /// EXAMPLE
    /// Input:  (7 -> 1 -> 6) + (5 -> 9 -> 2). That is 617 + 295
    /// Output: 2 -> 1 -> 9. That is, 912
    /// 
    /// FOLLOW UP
    /// Suppose the digits are stored in forward order. Repeat the above problem.
    /// EXAMPLE
    /// Input:  (6 -> 1 -> 7) + (2 -> 9 -> 5). That is, 617 + 295.
    /// Output: 9 -> 1 -> 2. That is 912.
    /// </summary>
    public class Chapter2_5Test : Chapter2TestBase
    {
        private readonly Chapter2_5 _sut = new Chapter2_5();

        public Chapter2_5Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter2_5Data_Reverse))]
        public void TestReverseAdditionOfNodes(Node<int> left, Node<int> right, Node<int> expected)
        {
            Node<int> actual = _sut.AddNodesReverse(left, right);

            Assert.True(AreNodesEqual(expected, actual));
        }

        [Theory]
        [ClassData(typeof(Chapter2_5Data_Padding))]
        public void TestPadZeroToIncreaseNodeLength(int length, Node<int> node, Node<int> expected)
        {
            Node<int> actual = _sut.PadZeroNodes(length, node);

            Assert.True(AreNodesEqual(expected, actual));
        }

        [Theory]
        [ClassData(typeof(Chapter2_5Data_Length))]
        public void TestNodeLengths(Node<int> node, int expected)
        {
            int actual = _sut.GetNodeLength(node);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(Chapter2_5Data_Forward))]
        public void TestForwardAdditionOfNodes(Node<int> left, Node<int> right, Node<int> expected)
        {
            Node<int> actual = _sut.AddNodesForwards(left, right);

            _output.WriteLine("expected: {0}\nactual: {1}", expected, actual);
            Assert.True(AreNodesEqual(expected, actual));
        }
    }
}
