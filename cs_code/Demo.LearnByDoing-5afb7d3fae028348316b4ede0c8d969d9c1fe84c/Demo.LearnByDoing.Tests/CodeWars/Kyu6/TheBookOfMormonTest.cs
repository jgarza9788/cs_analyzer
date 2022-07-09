using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/the-book-of-mormon/train/csharp
	/// </summary>
	public class TheBookOfMormonTest
	{
		[Theory]
		[InlineData(0, 10, 3, 9)]
		[InlineData(1, 40, 2, 120)]
		[InlineData(2, 40, 2, 121)]
		[InlineData(12, 20000, 2, 7000000000)]
		public void BasicTests(long expected, long startingNumber, long reach, long target)
		{
			Assert.Equal(expected, Kata.Mormons(startingNumber, reach, target));
		}
	}

	public partial class Kata
	{
		public static long Mormons(long startingNumber, long reach, long target)
		{
			var depth = 0;
			return GetDepth(startingNumber, reach, target, depth);
		}

		private static long GetDepth(long startingNumber, long reach, long target, int depth)
		{
			if (startingNumber >= target) return depth;

			return GetDepth(startingNumber + (startingNumber * reach), reach, target, depth + 1);
		}
	}
}
