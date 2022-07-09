using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeSignal.Challenges
{
	/// <summary>
	/// https://codefights.com/challenge/5Afg8xaWHX9cQ2Q6f
	/// </summary>
	public class PrefixSumsTest
	{
		[Theory]
		[InlineData(new[]{1,3,6}, new []{1,2,3})]
		public void TestSimpleCases(int[] expected, int[] a)
		{
			var actual = prefixSums(a);
			Assert.True(expected.SequenceEqual(actual));
		}

		int[] prefixSums(int[] a)
		{
			var prevSum = 0;
			var result = new List<int>(a.Length);
			for (int i = 0; i < a.Length; i++)
			{
				var sum = i + prevSum;
				result.Add(sum);
				prevSum = sum;
			}

			return result.ToArray();
		}
	}
}
