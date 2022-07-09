using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	public class FloodFillTest : BaseTest
	{
		public FloodFillTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestExample()
		{
			var expected = new int[,]
			{
				{1,4,3},
				{1,4,4},
				{2,3,4}}
			;

			var actual = new int[,]
			{
				{1,2,3},
				{1,2,2},
				{2,3,2}
			};
			Assert.Equal(expected, Kata.FloodFill(actual, 0, 1, 4));

			expected = new int[,]
			{
				{2,1,3},
				{1,4,1},
				{2,3,2}}
			;

			actual = new int[,]
			{
				{2,1,3},
				{1,2,1},
				{2,3,2}
			};

			Assert.Equal(expected, Kata.FloodFill(actual, 1, 1, 4));
		}
	}

	public partial class Kata
	{
		public static int[,] FloodFill(int[,] a, int x, int y, int newValue)
		{
			var startValue = a[x, y];
			var startNode = new Node(x, y);

			var queue = new Queue<Node>();
			queue.Enqueue(startNode);

			//var visited = GetInitialVisited(a);
			var visited = new Dictionary<Node, bool>();

			while (queue.Count > 0)
			{
				var node = queue.Dequeue();
				if (a[node.X, node.Y] == startValue && !visited.ContainsKey(node))
				{
					visited.Add(node, true);
				}

				var neighbors = GetNeighbors(a, node, startValue, visited).ToList();
				neighbors.ForEach(n =>
				{
					if (visited.ContainsKey(n))
					{
						if (!visited[n])
							queue.Enqueue(n);
					}
					else
					{
						visited.Add(n, true);
						queue.Enqueue(n);
					}
				});
			}

			foreach (var pair in visited)
			{
				if (pair.Value)
					a[pair.Key.X, pair.Key.Y] = newValue;
			}

			return a;
		}

		private static IEnumerable<Node> GetNeighbors(int[,] a, Node node, int startValue, Dictionary<Node, bool> visited)
		{
			Node top = GetNodeAt(a, node.X, node.Y - 1);
			Node right = GetNodeAt(a, node.X + 1, node.Y);
			Node bottom = GetNodeAt(a, node.X, node.Y + 1);
			Node left = GetNodeAt(a, node.X - 1, node.Y);

			//Func<Node, bool> isValid = n => n != _invalidNode && a[n.AttackX, n.AttackY] == startValue && visited.ContainsKey(n) && !visited[n];
			Func<Node, bool> isValid = n =>
			{
				if (n == _invalidNode) return false;
				if (a[n.X, n.Y] == startValue) return true;
				if (visited.ContainsKey(n))
					if (!visited[n]) return true;

				return false;
			};

			if (isValid(top)) yield return top;
			if (isValid(right)) yield return right;
			if (isValid(bottom)) yield return bottom;
			if (isValid(left)) yield return left;
		}

		private static readonly Node _invalidNode = new Node(-1, -1);

		private static Node GetNodeAt(int[,] a, int x, int y)
		{
			if (x < 0 || x >= a.GetLength(0)) return _invalidNode;
			if (y < 0 || y >= a.GetLength(1)) return _invalidNode;

			return new Node(x, y);
		}
	}

	public struct Node
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Node(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static bool operator ==(Node n1, Node n2)
		{
			return n1.X == n2.X && n1.Y == n2.Y;
		}

		public static bool operator !=(Node n1, Node n2)
		{
			return !(n1 == n2);
		}

		public override bool Equals(object obj)
		{
			Node node = (Node) obj;
			return X == node.X && Y == node.Y;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("AttackX:{0} AttackY:{1}", X, Y);
		}
	}
}
