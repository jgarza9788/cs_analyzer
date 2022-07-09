using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter04
{
    /// <summary>
    /// MINIMAL TREE:
    /// Given a sorted (increasing order) array with unique integer elements,
    /// write an alogrithm to create a binary search tree with minimal height.
    /// </summary>
    public class Chapter4_2Test : BaseTest
    {
        private readonly Chapter4_2 _sut = new Chapter4_2();

        public Chapter4_2Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter4_2
    {
    }

    public class Chapter4Base2Data : Chapter4BaseTestData
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            
        };
    }

    public class TreeNode<T>
    {
        public string Name { get; set; }
        public TreeNode<T>[] Children { get; set; }
    }

    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }
    }
}
