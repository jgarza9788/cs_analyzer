using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/largest-stack
	/// 
	/// You want to be able to access the largest element in a stack. 
	/// 
	/// Use the built-in Stack class to implement a new class MaxStack with a method GetMax() 
	/// that returns the largest element in the stack. GetMax() should not remove the item.
	/// 
	/// Your stacks will contain only integers. 
	/// </summary>
	public class Question020Test
	{
		public static IEnumerable<object[]> GetAllPushCases()
		{
			yield return new object[] {new [] {1, 3, 2, 10, 99, -1, 7, 8, 35}, 99};
			yield return new object[] {new [] {9, 8, 7, 6, 5}, 9};
			yield return new object[] {new [] {1, 2, 3, 4, 5}, 5};
			yield return new object[] {new [] {1, 2, 3, 2, 1}, 3};
		}

		[Theory]
		[MemberData(nameof(GetAllPushCases))]
		public void TestAllPushes(int[] input, int expected)
		{
			var sut = new MaxStack();
			foreach (int value in input)
			{
				sut.Push(value);
			}

			int actual = sut.GetMax();
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestPushPop()
		{
			var sut = new MaxStack();
			sut.Push(1);
			sut.Push(2);
			sut.Push(3);
			Assert.Equal(3, sut.GetMax());
			sut.Pop();
			Assert.Equal(2, sut.GetMax());
			sut.Push(99);
			sut.Push(33);
			Assert.Equal(99, sut.GetMax());
			sut.Pop();
			Assert.Equal(99, sut.GetMax());
			sut.Pop();
			Assert.Equal(2, sut.GetMax());
		}
	}

	public class MaxStack
	{
		private readonly Stack<int> _valueStack = new Stack<int>();
		private readonly Stack<int> _maxStack = new Stack<int>();

		public int Push(int value)
		{
			_valueStack.Push(value);
			if (_maxStack.Count == 0 || value >= _maxStack.Peek())
				_maxStack.Push(value);
			return value;
		}

		public int Pop()
		{
			int value = _valueStack.Pop();
			if (value == _maxStack.Peek())
				_maxStack.Pop();
			return value;
		}

		//public int Pop()
		//{
		//	_maxStack.Pop();
		//	return _valueStack.Pop();
		//}

		//public int Push(int value)
		//{
		//	if (_maxStack.Count == 0) _maxStack.Push(value);
		//	else _maxStack.Push(value > _maxStack.Peek() ? value : _maxStack.Peek());

		//	_valueStack.Push(value);
		//	return value;
		//}

		public int GetMax()
		{
			return _maxStack.Peek();
		}
	}
}
