using System;
using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/unflatten-a-list-easy/train/csharp
	/// </summary>
	public class UnflattenAListEasyTest : BaseTest
	{
		public UnflattenAListEasyTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void BasicTests()
		{
			var input = new int[] { 3, 5, 2, 1 };
			var expected = new object[] { new int[] { 3, 5, 2 }, 1 };
			Assert.Equal(expected, Kata.Unflatten(input));

			input = new int[] { 1, 4, 5, 2, 1, 2, 4, 5, 2, 6, 2, 3, 3 };
			expected = new object[] { 1, new int[] { 4, 5, 2, 1 }, 2, new int[] { 4, 5, 2, 6 }, 2, new int[] { 3, 3 } };
			Assert.Equal(expected, Kata.Unflatten(input));
		}
	}

	public partial class Kata
	{
		public static object[] Unflatten(int[] a)
		{
			var result = new List<object>();

			for (int i = 0; i < a.Length; i++)
			{
				var value = a[i];
				if (value < 3)
				{
					result.Add(value);
				}
				else if (value >= 3)
				{
					int len = a.Length - i < value ? a.Length - i : value;
					var subArray = new int[len];
					Array.Copy(a, i, subArray, 0, len);

					result.Add(subArray);

					i += len - 1;
				}
			}

			return result.ToArray();
		}
	}
}
