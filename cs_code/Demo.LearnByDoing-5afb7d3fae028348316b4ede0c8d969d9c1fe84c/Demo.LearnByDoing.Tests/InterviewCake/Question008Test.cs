using System;
using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// Write a function to see if a binary tree ↴ is "superbalanced" (a new tree property we just made up).
	/// https://www.interviewcake.com/question/csharp/balanced-binary-tree
	/// </summary>
	public class Question008Test
	{
		[Theory]
		[MemberData(nameof(GetTrueCases))]
		void TestSuperBalancedTrees(bool expected, BinaryTreeNode root)
		{
			var actual = new SuperBalancedTreeValidator().IsSuperBalancedTree(root);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetTrueCases()
		{
			var root = new BinaryTreeNode(1);
			yield return new object[] { true, root };

			root.InsertLeft(2);
			yield return new object[] { true, root };

			root.InsertRight(3);
			yield return new object[] { true, root };

			var root2 = new BinaryTreeNode(1);
			root2.InsertLeft(2).InsertLeft(3);
			yield return new object[] { false, root2 };

			var root3 = new BinaryTreeNode(1);
			root3.InsertLeft(2).InsertLeft(3);
			root3.InsertRight(5);
			yield return new object[] { true, root3 };
		}
	}

	class SuperBalancedTreeValidator
	{
		public bool IsSuperBalancedTree(BinaryTreeNode root)
		{
			int maxLeftDepth = GetMaxDepth(root.Left, 0);
			int maxRightDepth = GetMaxDepth(root.Right, 0);

			return Math.Abs(maxLeftDepth - maxRightDepth) <= 1;
		}

		private int GetMaxDepth(BinaryTreeNode root, int depth)
		{
			if (root == null) return depth;

			int leftDepth = GetMaxDepth(root.Left, depth + 1);
			int rightDepth = GetMaxDepth(root.Right, depth + 1);

			return Math.Max(leftDepth, rightDepth);
		}
	}

	class BinaryTreeNode
	{
		public int Value { get; }
		public BinaryTreeNode Left { get; private set; }
		public BinaryTreeNode Right { get; private set; }

		public BinaryTreeNode(int value)
		{
			Value = value;
		}

		public BinaryTreeNode InsertLeft(int leftValue)
		{
			Left = new BinaryTreeNode(leftValue);
			return Left;
		}

		public BinaryTreeNode InsertRight(int rightValue)
		{
			Right = new BinaryTreeNode(rightValue);
			return Right;
		}
	}

}
