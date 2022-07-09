using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.MissionInterview._01_DataStructures
{
	public class SungTreeTest : BaseTest
	{
		public SungTreeTest(ITestOutputHelper output) : base(output)
		{
		}

		public static SungBinaryTreeNode<int> GetSampleTree()
		{
			return new SungBinaryTreeNode<int>(1000)
			{
				Left = new SungBinaryTreeNode<int>(500)
				{
					Left = new SungBinaryTreeNode<int>(400)
					{
						Left = new SungBinaryTreeNode<int>(220),
						Right = new SungBinaryTreeNode<int>(260)
					},
					Right = new SungBinaryTreeNode<int>(450)
					{
						Left = new SungBinaryTreeNode<int>(250),
						Right = new SungBinaryTreeNode<int>(280)
					}
				},
				Right = new SungBinaryTreeNode<int>(500)
				{
					Left = new SungBinaryTreeNode<int>(380)
					{
						Left = new SungBinaryTreeNode<int>(210),
						Right = new SungBinaryTreeNode<int>(220)
					},
					Right = new SungBinaryTreeNode<int>(350)
					{
						Left = new SungBinaryTreeNode<int>(230),
						Right = new SungBinaryTreeNode<int>(240)
					}
				}
			};
		}

		public static IEnumerable<object[]> GetPreData()
		{
			yield return new object[] {new List<int>{1000, 500, 400, 220, 260, 450, 250, 280, 500, 380, 210, 220, 350, 230, 240}, GetSampleTree()};
		}

		public static IEnumerable<object[]> GetInData()
		{
			yield return new object[] {new List<int>{220, 400, 260, 500, 250, 450, 280, 1000, 210, 380, 220, 500, 230, 350, 240}, GetSampleTree()};
		}

		public static IEnumerable<object[]> GetPostData()
		{
			yield return new object[] {new List<int>{220, 260, 400, 250, 280, 450, 500, 210, 220, 380, 230, 240, 350, 500, 1000}, GetSampleTree()};
		}

		[Theory]
		[MemberData(nameof(GetPreData))]
		public void TestPreTraversal(List<int> expected, SungBinaryTreeNode<int> root)
		{
			var sut = new SungBinaryTreeTraverser();
			var actual = sut.TraversePre(root);

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[MemberData(nameof(GetInData))]
		public void TestInTraversal(List<int> expected, SungBinaryTreeNode<int> root)
		{
			var sut = new SungBinaryTreeTraverser();
			var actual = sut.TraverseIn(root).ToList();

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[MemberData(nameof(GetPostData))]
		public void TestPostTraversal(List<int> expected, SungBinaryTreeNode<int> root)
		{
			var sut = new SungBinaryTreeTraverser();
			var actual = sut.TraversePost(root).ToList();

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[MemberData(nameof(GetBinaryTreeNodeData))]
		public void TestBuildingTree(SungBinaryTreeNode<int> expected, int[] input)
		{
			var actual = new SungBinaryTreeBuilder().Build(input);

			var traverser = new SungBinaryTreeTraverser();
			var expectedList = traverser.TraversePost(expected);
			var actualList = traverser.TraversePost(actual);

			Assert.True(expectedList.SequenceEqual(actualList));
		}

		public static SungBinaryTreeNode<int> GetSampleBinaryTreeNode()
		{
			return new SungBinaryTreeNode<int>(500)
			{
				Left = new SungBinaryTreeNode<int>(300)
				{
					Left = new SungBinaryTreeNode<int>(200),
					Right = new SungBinaryTreeNode<int>(400)
				},
				Right = new SungBinaryTreeNode<int>(700)
				{
					Left = new SungBinaryTreeNode<int>(600),
					Right = new SungBinaryTreeNode<int>(800)
				}
			};
		}

		public static IEnumerable<object[]> GetBinaryTreeNodeData()
		{
			yield return new object[] {GetSampleBinaryTreeNode(), new[] { 200, 300, 400, 500, 600, 700, 800 } };
		}
	}

	public class SungBinaryTreeBuilder
	{
		public SungBinaryTreeNode<int> Build(int[] input)
		{
			return Build(input, 0, input.Length - 1);
		}

		private SungBinaryTreeNode<int> Build(int[] a, int min, int max)
		{
			if (min > max) return null;

			var mid = (min + max) / 2;
			var node = new SungBinaryTreeNode<int>(a[mid]);
			node.Left = Build(a, min, mid - 1);
			node.Right = Build(a, mid + 1, max);

			return node;
		}
	}

	public class SungBinaryTreeTraverser
	{
		public IEnumerable<T> TraversePre<T>(SungBinaryTreeNode<T> root)
		{
			if (root == null) yield break;

			yield return root.Value;
			foreach (var value in TraversePre(root.Left)) yield return value;
			foreach (var value in TraversePre(root.Right)) yield return value;
		}

		public IEnumerable<int> TraverseIn(SungBinaryTreeNode<int> root)
		{
			if (root == null) yield break;

			foreach (var value in TraverseIn(root.Left)) yield return value;
			yield return root.Value;
			foreach (var value in TraverseIn(root.Right)) yield return value;
		}

		public IEnumerable<int> TraversePost(SungBinaryTreeNode<int> root)
		{
			if (root == null) yield break;

			foreach (var value in TraversePost(root.Left)) yield return value;
			foreach (var value in TraversePost(root.Right)) yield return value;
			yield return root.Value;
		}
	}

	public class SungBinaryTreeNode<T>
	{
		public T Value { get; set; }
		public SungBinaryTreeNode<T> Left { get; set; }
		public SungBinaryTreeNode<T> Right { get; set; }

		public SungBinaryTreeNode(T value)
		{
			Value = value;
		}

		public SungBinaryTreeNode<T> AddLeft(T value)
		{
			Left = new SungBinaryTreeNode<T>(value);
			return this;
		}

		public SungBinaryTreeNode<T> AddRight(T value)
		{
			Right = new SungBinaryTreeNode<T>(value);
			return this;
		}
	}
}
