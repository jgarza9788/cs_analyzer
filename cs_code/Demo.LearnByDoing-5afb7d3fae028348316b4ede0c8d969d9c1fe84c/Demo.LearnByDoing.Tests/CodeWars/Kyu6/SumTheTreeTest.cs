using System.Collections.Generic;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/sum-the-tree/train/csharp
	/// </summary>
	[TestFixture]
	public class SumTheTreeTest
	{
		private static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				yield return new TestCaseData(new SumTheTreeNode(10, new SumTheTreeNode(1), new SumTheTreeNode(2))).Returns(13).SetDescription("Simple Test");
				yield return new TestCaseData(new SumTheTreeNode(11, new SumTheTreeNode(0), new SumTheTreeNode(0, null, new SumTheTreeNode(1)))).Returns(12).SetDescription("Handles unbalanced trees");
			}
		}

		[Test, TestCaseSource(nameof(TestCases))]
		public int Test(SumTheTreeNode root) =>
			Kata.SumTree(root);
	}

	public partial class Kata
	{
		public static int SumTree(SumTheTreeNode root)
		{
			if (root == null) return 0;

			int sum = root.Value;
			sum += SumTree(root.Left);
			sum += SumTree(root.Right);

			return sum;
		}
	}

	public class SumTheTreeNode
	{
		public int Value;
		public SumTheTreeNode Left;
		public SumTheTreeNode Right;

		public SumTheTreeNode(int value, SumTheTreeNode left = null, SumTheTreeNode right = null)
		{
			Value = value;
			Left = left;
			Right = right;
		}
	}
}
