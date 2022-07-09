using System;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Intersection:
    /// Given two (singly) linked lists, determine if the two lists intersect.
    /// Return the intersecting node. Note that the intersection is defined based on reference, not value.
    /// That is, if the kth node of the first linked list is the exact same node (by reference)
    /// as the jth node of the second linked list, then they are intersecting
    /// </summary>
    public class Chapter2_7Test : Chapter2TestBase
    {
        private readonly Chapter2_7 _sut = new Chapter2_7();

        public Chapter2_7Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [ClassData(typeof(Chapter2_7Data))]
        public void TestNodeIntersection(Tuple<Node<int>, Node<int>> nodes, bool expected)
        {
            bool actual = _sut.AreNodesIntersecting(nodes.Item1, nodes.Item2);

            Assert.Equal(expected, actual);
        }
    }
}
