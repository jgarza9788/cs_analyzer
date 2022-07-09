using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.MissionInterview
{
	public class DoublyLinkedListTest : BaseTest
	{
		public DoublyLinkedListTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestEdgeCases()
		{
			var sut = new DoublySungLinkedList<int>();

			// When nothing's added, there shoun't be *ANY* result.
			Assert.False(sut.Traverse().Any());
		}

		[Fact]
		public void TestInsertAndTraversal()
		{
			// Arrange
			var sut = new DoublySungLinkedList<int>();
			sut.Append(1);
			sut.Append(2);
			sut.Append(3);

			// Act
			var actual = sut.Traverse().Select(node => node.Value);

			// Assert
			int[] expected = { 1, 2, 3 };
			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void TestTraversalCallback()
		{
			var sut = new DoublySungLinkedList<int>();
			sut.Append(1);
			sut.Append(2);
			sut.Append(3);

			int[] expected = { 1, 2, 3 };
			Assert.True(expected.SequenceEqual(sut.Traverse((curr, last) => false).Select(n => n.Value)));
			Assert.Empty(sut.Traverse((curr, last) => true));
		}

		[Fact]
		public void TestInsertAt()
		{
			// Arrange
			var sut = new DoublySungLinkedList<int>();
			sut.Append(1);
			var node = sut.Append(2);
			sut.Append(3);

			// Act: Insert at 2
			sut.InsertAt(node, 10);

			// Assert
			int[] expected = { 1, 2, 10, 3 };
			var actual = sut.Traverse().Select(n => n.Value);
			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void TestRemoving()
		{
			// Arrange
			var sut = new DoublySungLinkedList<int>();
			sut.Append(1);
			var node = sut.Append(2);
			sut.Append(3);

			// Act: Remove 2.
			sut.Remove(node);

			// Assert
			int[] expected = { 1, 3 };
			var actual = sut.Traverse().Select(n => n.Value);
			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void TestPreviousNode()
		{
			var sut = new DoublySungLinkedList<int>();
			sut.Append(1);
			var node = sut.Append(2);
			var node2 = sut.Append(3);

			// Test append
			Assert.True(node.Previous.Value == 1);

			// Test remove
			sut.Remove(node);
			Assert.True(node2.Previous.Value == 1);

			// Test insertAt
			var newNode = sut.InsertAt(node2, 5);
			Assert.True(newNode.Previous.Value == 3);
		}

		/// <summary>
		/// Testing edge cases.
		/// </summary>
		[Fact]
		public void TestRemovingFirstAndLast()
		{
			var sut = new DoublySungLinkedList<int>();
			var a = sut.Append(1);
			var b = sut.Append(2);
			var c = sut.Append(3);

			sut.Remove(a);
			Assert.True(new[] { 2, 3 }.SequenceEqual(sut.Traverse().Select(node => node.Value)));

			sut.Remove(c);
			Assert.True(new[] { 2 }.SequenceEqual(sut.Traverse().Select(node => node.Value)));
		}

	}

	public class DoublySungNode<T>
	{
		public T Value { get; set; }
		public DoublySungNode<T> Next { get; set; }
		public DoublySungNode<T> Previous { get; set; }

		public DoublySungNode(T value)
		{
			Value = value;
			Next = null;
			Previous = null;
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			return Value.Equals(((DoublySungNode<T>)obj).Value);
		}

		protected bool Equals(DoublySungNode<T> other)
		{
			return EqualityComparer<T>.Default.Equals(Value, other.Value) && Equals(Next, other.Next) && Equals(Previous, other.Previous);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = EqualityComparer<T>.Default.GetHashCode(Value);
				hashCode = (hashCode * 397) ^ (Next != null ? Next.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Previous != null ? Previous.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}
