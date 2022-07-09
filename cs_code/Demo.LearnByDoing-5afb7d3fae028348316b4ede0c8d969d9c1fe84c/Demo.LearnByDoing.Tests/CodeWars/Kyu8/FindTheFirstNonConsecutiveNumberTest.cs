using System;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu8
{
	/// <summary>
	/// https://www.codewars.com/kata/find-the-first-non-consecutive-number/train/csharp
	/// </summary>
	public class FindTheFirstNonConsecutiveNumberTest : BaseTest
	{
		public FindTheFirstNonConsecutiveNumberTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(6, new[] { 1, 2, 3, 4, 6, 7, 8 })]
		[InlineData(null, new[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		[InlineData(7, new[] { 2, 3, 4, 7, 8 })]
		[InlineData(null, new[] { 2, 3, 4, 5 })]
		public void SampleTest(object expected, int[] input)
		{
			Assert.Equal(expected, Kata.FirstNonConsecutive(input));
		}
	}

	public partial class Kata
	{
		public static object FirstNonConsecutive(int[] arr)
		{
			for (int i = 0; i < arr.Length - 1; i++)
			{
				int curr = arr[i];
				int next = arr[i + 1];
				if (Math.Abs(curr - next) > 1) return next;
			}

			return null;

			//int? nonConsecutive = null;
			//arr.Aggregate(arr[0], (acc, next) =>
			//{
			//	if (next - acc > 1)
			//	{
			//		acc = next;
			//		nonConsecutive = next;
			//	}
			//	else
			//	{
			//		acc = next;
			//	}

			//	return acc;
			//});

			//return nonConsecutive > 1 ? (object)nonConsecutive : null;
		}
	}
}
