using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu8
{
	/// <summary>
	/// https://www.codewars.com/kata/beginner-series-number-2-clock/train/csharp
	/// </summary>
	public class BeginnerSeriesClockTest
	{
		[Fact]
		public void Test()
		{
			Assert.Equal(61000, Clock.Past(0, 1, 1));
		}
	}

	public static class Clock
	{
		public static int Past(int h, int m, int s)
		{
			return s * 1000 + (1000 * 60 * m) + (1000 * 60 * 60 * h);
		}
	}
}
