using System;
using System.Diagnostics;

namespace Demo.LearnByDoing.General.Tree
{
	/// <summary>
	/// Find Lowest Common Ancestor of Binary Tree
	/// https://youtu.be/13m9ZCB8gjw
	/// </summary>
	public class LowestCommonAncestorProgram
	{
		public static void Main(string[] args)
		{
			TreeNode<int> root = BuildTree();
			var lca1 = GetLowestCommonAncestor(root, new TreeNode<int>(2), new TreeNode<int>(5));
			Debug.Assert(lca1.Value == 6);
			Console.WriteLine("lca1 between 2 & 5: {0}", lca1.Value);

			var lca2 = GetLowestCommonAncestor(root, new TreeNode<int>(9), new TreeNode<int>(5));
			Debug.Assert(lca2.Value == 11);
			Console.WriteLine("lca2 between 9 & 5: {0}", lca2.Value);

			var lca3 = GetLowestCommonAncestor(root, new TreeNode<int>(8), new TreeNode<int>(11));
			Debug.Assert(lca3.Value == 3);
			Console.WriteLine("lca3 between 8 & 11: {0}", lca3.Value);

			var lca4 = GetLowestCommonAncestor(root, new TreeNode<int>(8), new TreeNode<int>(7));
			Debug.Assert(lca4.Value == 8);
			Console.WriteLine("lca3 between 8 & 7: {0}", lca4.Value);
		}

		private static TreeNode<int> GetLowestCommonAncestor(TreeNode<int> root, TreeNode<int> n1, TreeNode<int> n2)
		{
			if (root == null) return null;
			if (root == n1 || root == n2) return root;

			var left = GetLowestCommonAncestor(root.Left, n1, n2);
			var right = GetLowestCommonAncestor(root.Right, n1, n2);

			if (left != null && right != null) return root;
			if (left == null && right == null) return null;

			return left != null ? left : right;
		}

		/// <summary>
		/// http://asciiflow.com/
		///          3
		///          |
		///          |
		///    6+----------+8
		///     |          |
		///     |          |
		///2<------+11     +----+13
		///        |            |
		///        |            |
		///    9<----->5  7<-----
		///
		/// </summary>
		/// <returns></returns>
		private static TreeNode<int> BuildTree()
		{
			TreeNode<int> root = new TreeNode<int>(3)
			{
				Left = new TreeNode<int>(6)
				{
					Left = new TreeNode<int>(2),
					Right = new TreeNode<int>(11)
					{
						Left = new TreeNode<int>(9),
						Right = new TreeNode<int>(5)
					}
				},
				Right = new TreeNode<int>(8)
				{
					Right = new TreeNode<int>(13)
					{
						Left = new TreeNode<int>(7)
					}
				}
			};

			return root;
		}
	}
}
