using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/product-of-other-numbers
	/// Product of Other Numbers
	/// </summary>
	public class Question002Test
	{
		[Theory]
		[InlineData(new []{84, 12, 28, 21}, new []{1, 7, 3, 4})]
		[InlineData(new []{0, 0, 0, 0}, new []{0, 0, 0, 0})]
		public void TestSampleCases(int[] expected, int[] a)
		{
			var sut = new ICProductOfOtherNumbers();
			var actual = sut.GetProductOfOtherNumbers(a);

			Assert.True(expected.SequenceEqual(actual));
		}

		[Fact]
		public void ThrowErrorIfLessThanTwoElementIsPassed()
		{
			var sut = new ICProductOfOtherNumbers();
			int[] invalidArray = {};
			Assert.Throws<ArgumentException>(() => sut.GetProductOfOtherNumbers(null));
			Assert.Throws<ArgumentException>(() => sut.GetProductOfOtherNumbers(invalidArray));
		}
	}

	public class ICProductOfOtherNumbers
	{
		public IEnumerable<int> GetProductOfOtherNumbers(int[] a)
		{
			if (a == null || a.Length < 2)
				throw new ArgumentException("An array need to have at least 2 elements in it!");

			// Initialize Result
			const int invalidStateValue = -1;
			var result = Enumerable.Repeat(invalidStateValue, a.Length).ToArray();

			var prodForward = 1;
			for (int i = 0; i < a.Length - 1; i++)
			{
				var current = a[i];
				prodForward *= current;
				result[i + 1] = result[i + 1] == invalidStateValue ? prodForward : result[i + 1] * prodForward;
			}

			var prodBackward = 1;
			for (int j = a.Length - 1; j > 0; j--)
			{
				var current = a[j];
				prodBackward *= current;
				result[j - 1] = result[j - 1] == invalidStateValue ? prodBackward : result[j - 1] * prodBackward;
			}

			return result;
		}
	}
}
