using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.DataStructure.Tree
{
	public class BinaryTreeTraversalsTest
	{
		static BinaryTreeNode GetSampleBinaryTreeNode()
		{
			return new BinaryTreeNode(4)
			{
				Left = new BinaryTreeNode(2)
				{
					Left = new BinaryTreeNode(1),
					Right = new BinaryTreeNode(3)
				},
				Right = new BinaryTreeNode(6)
				{
					Left = new BinaryTreeNode(5),
					Right = new BinaryTreeNode(7)
				}
			};
		}

		[Theory]
		[MemberData(nameof(GetDepthFirstPreOrderData))]
		public void TestRecursiveDepthFirstPreOrderSearch(IEnumerable<int> expected, BinaryTreeNode root)
		{
			var sut = new BinaryTreeNodeTraverser();
			var actual = sut.TraverseDfsPreOrderRecursively(root);

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[MemberData(nameof(GetDepthFirstPreOrderData))]
		public void TestIterativeDepthFirstSearch(IEnumerable<int> expected, BinaryTreeNode root)
		{
			var sut = new BinaryTreeNodeTraverser();
			var actual = sut.TraverseDfsPreOrderIteratively(root);

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[MemberData(nameof(GetDepthFirstInOrderData))]
		public void TestRecursiveDepthFirstInOrderSearch(IEnumerable<int> expected, BinaryTreeNode root)
		{
			var sut = new BinaryTreeNodeTraverser();
			var actual = sut.TraverseDfsInOrderRecursively(root);

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[MemberData(nameof(GetDepthFirstPostOrderData))]
		public void TestRecursiveDepthFirstPostOrderSearch(IEnumerable<int> expected, BinaryTreeNode root)
		{
			var sut = new BinaryTreeNodeTraverser();
			var actual = sut.TraverseDfsPostOrderRecursively(root);

			Assert.True(expected.SequenceEqual(actual));
		}

		[Theory]
		[MemberData(nameof(GetDepthFirstPostOrderData))]
		public void TestIterativeDepthFirstPostOrderSearch(IEnumerable<int> expected, BinaryTreeNode root)
		{
			var sut = new BinaryTreeNodeTraverser();
			var actual = sut.TraverseDfsPostOrderIterativelyUsingDoubleStack(root);

			Assert.True(expected.SequenceEqual(actual));
		}

		public static IEnumerable<object[]> GetDepthFirstPreOrderData()
		{
			yield return new object[] { new[] { 4, 2, 1, 3, 6, 5, 7 }, GetSampleBinaryTreeNode() };
		}

		public static IEnumerable<object[]> GetDepthFirstInOrderData()
		{
			yield return new object[] { new[] { 1, 2, 3, 4, 5, 6, 7 }, GetSampleBinaryTreeNode() };
		}

		public static IEnumerable<object[]> GetDepthFirstPostOrderData()
		{
			yield return new object[] { new[] { 1, 3, 2, 5, 7, 6, 4 }, GetSampleBinaryTreeNode() };
		}
	}

	public class BinaryTreeNodeTraverser
	{
		/// <summary>
		/// Iterative Depth First Pre-order traversal
		/// </summary>
		/// <remarks>
		/// 1. Push root to stack.
		/// 2. Loop while the stack is not empty.
		///		2.1. Pop a node
		///		2.2. Retun the popped node's value.
		///		2.2. Push the right node to the stack
		///		2.3. Push the left node to the stack
		/// 
		/// Note: You are pushing the RIGHT node into the stack first!
		/// </remarks>
		public IEnumerable<int> TraverseDfsPreOrderIteratively(BinaryTreeNode root)
		{
			if (root == null) yield break;

			var stack = new Stack<BinaryTreeNode>();
			stack.Push(root);

			while (stack.Count > 0)
			{
				var node = stack.Pop();
				yield return node.Value;

				if (node.Right != null) stack.Push(node.Right);
				if (node.Left != null) stack.Push(node.Left);
			}
		}

		/// <summary>
		/// Iterative Post-order DFS
		/// </summary>
		/// <remarks><see cref="http://www.geeksforgeeks.org/iterative-postorder-traversal/"/>
		/// http://www.geeksforgeeks.org/iterative-postorder-traversal/
		/// Algorithm.
		/// 1. Push root to first stack.
		/// 2. Loop while first stack is not empty
		///		 2.1 Pop a node from first stack and push it to second stack
		///		 2.2 Push left and right children of the popped node to first stack
		/// 3. Print contents of second stack
		/// </remarks>
		public IEnumerable<int> TraverseDfsPostOrderIterativelyUsingDoubleStack(BinaryTreeNode root)
		{
			if (root == null) return new List<int>(0);

			var inStack = new Stack<BinaryTreeNode>();
			var outStack = new Stack<BinaryTreeNode>();

			inStack.Push(root);

			while (inStack.Count > 0)
			{
				var node = inStack.Pop();
				outStack.Push(node);
				if (node.Left != null) inStack.Push(node.Left);
				if (node.Right != null) inStack.Push(node.Right);
			}

			return outStack.Select(node => node.Value);
		}

		public IEnumerable<int> TraverseDfsPreOrderRecursively(BinaryTreeNode root)
		{
			if (root == null) yield break;

			yield return root.Value;
			foreach (var n in TraverseDfsPreOrderRecursively(root.Left).ToList()) yield return n;
			foreach (var n in TraverseDfsPreOrderRecursively(root.Right).ToList()) yield return n;
		}

		public IEnumerable<int> TraverseDfsInOrderRecursively(BinaryTreeNode root)
		{
			if (root == null) yield break;

			foreach (var n in TraverseDfsInOrderRecursively(root.Left).ToList()) yield return n;
			yield return root.Value;
			foreach (var n in TraverseDfsInOrderRecursively(root.Right).ToList()) yield return n;
		}

		public IEnumerable<int> TraverseDfsPostOrderRecursively(BinaryTreeNode root)
		{
			if (root == null) yield break;

			foreach (var n in TraverseDfsPostOrderRecursively(root.Left).ToList()) yield return n;
			foreach (var n in TraverseDfsPostOrderRecursively(root.Right).ToList()) yield return n;
			yield return root.Value;
		}
	}

	public class BinaryTreeNode
	{
		public int Value { get; }
		public BinaryTreeNode Left { get; set; }
		public BinaryTreeNode Right { get; set; }

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
