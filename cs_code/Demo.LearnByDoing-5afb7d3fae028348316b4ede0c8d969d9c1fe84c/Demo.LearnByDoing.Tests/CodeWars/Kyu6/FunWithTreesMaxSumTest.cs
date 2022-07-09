using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Tests.CodeWars.Kyu6.Tree;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/fun-with-trees-max-sum/train/csharp
	/// </summary>
	public class FunWithTreesMaxSumTest
	{
		[Fact]
		public void MaxSumInNullTree()
		{
			TreeNode root = null;
			Assert.Equal(0, Tree.Solution.MaxSum(root));
		}

		/**
		 *      5
		 *    /   \
		 *  -22    11
		 *  / \    / \
		 * 9  50  9   2
		 */
		[Fact]
		public void MaxSumInPerfectTree()
		{
			TreeNode left = TreeNode.Leaf(-22).WithLeaves(9, 50);
			TreeNode right = TreeNode.Leaf(11).WithLeaves(9, 2);
			TreeNode root = TreeNode.Join(5, left, right);
			var maxSum = Tree.Solution.MaxSum(root);
			Assert.Equal(33, maxSum);
		}
	}

	namespace Tree
	{
		public class Solution
		{
			public static int MaxSum(TreeNode node)
			{
				return GetMax(node).Sum();
			}

			public static IEnumerable<int> GetMax(TreeNode node)
			{
				if (node == null) yield break;

				yield return node.value;

				var left = GetMax(node.left).Sum();
				var right = GetMax(node.right).Sum();

				yield return Math.Max(left, right);
			}
		}

		public class TreeNode
		{
			public TreeNode left;
			public TreeNode right;
			public int value;

			public TreeNode(int value)
			{
				this.value = value;
			}

			public static TreeNode Leaf(int value)
			{
				var newNode = new TreeNode(value);
				return newNode;
			}

			public TreeNode WithLeaves(int leftValue, int rightValue)
			{
				left = new TreeNode(leftValue);
				right = new TreeNode(rightValue);
				return this;
			}

			public static TreeNode Join(int rootValue, TreeNode leftNode, TreeNode rightNode)
			{
				return new TreeNode(rootValue)
				{
					left = leftNode,
					right = rightNode
				};
			}
		}
	}
}
