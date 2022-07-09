using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.MissionInterview
{
	public class LinkedListTest : BaseTest
	{
		public LinkedListTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestEdgeCases()
		{
			var sut = new SungLinkedList<int>();

			// When nothing's added, there shoun't be *ANY* result.
			Assert.False(sut.Traverse().Any());

			//// When something not in the list is removed, then there shouldn't be anything returned.
			//Assert.Null(sut.Remove(null));

			//// When something not in the list is removed, then there shouldn't be anything returned.
			//Assert.Null(sut.Remove(new SungNode<int>(1)));
		}

		[Fact]
		public void TestInsertAndTraversal()
		{
			// Arrange
			var sut = new SungLinkedList<int>();
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
			var sut = new SungLinkedList<int>();
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
			var sut = new SungLinkedList<int>();
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
			var sut = new SungLinkedList<int>();
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

		/// <summary>
		/// Testing edge cases.
		/// </summary>
		[Fact]
		public void TestRemovingFirstAndLast()
		{
			var sut = new SungLinkedList<int>();
			var a = sut.Append(1);
			var b = sut.Append(2);
			var c = sut.Append(3);

			sut.Remove(a);
			Assert.True(new[] { 2, 3 }.SequenceEqual(sut.Traverse().Select(node => node.Value)));

			sut.Remove(c);
			Assert.True(new[] { 2 }.SequenceEqual(sut.Traverse().Select(node => node.Value)));
		}
	}

	public class SungNode<T>
	{
		public T Value { get; set; }
		public SungNode<T> Next { get; set; }

		public SungNode(T value)
		{
			Value = value;
			Next = null;
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			return Value.Equals(((SungNode<T>)obj).Value);
		}

		protected bool Equals(SungNode<T> other)
		{
			return EqualityComparer<T>.Default.Equals(Value, other.Value) && Equals(Next, other.Next);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (EqualityComparer<T>.Default.GetHashCode(Value) * 397) ^ (Next != null ? Next.GetHashCode() : 0);
			}
		}
	}
}
