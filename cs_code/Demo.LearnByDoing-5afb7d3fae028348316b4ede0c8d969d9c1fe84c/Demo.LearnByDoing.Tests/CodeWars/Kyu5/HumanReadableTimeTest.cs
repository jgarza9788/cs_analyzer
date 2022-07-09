using System;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/52685f7382004e774f0001f7/train/csharp
	/// </summary>
	public class HumanReadableTimeTest : BaseTest
	{
		public HumanReadableTimeTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(0, "00:00:00")]
		[InlineData(5, "00:00:05")]
		[InlineData(60, "00:01:00")]
		[InlineData(86399, "23:59:59")]
		[InlineData(86400, "24:00:00")]
		[InlineData(359998, "99:59:58")]
		[InlineData(359999, "99:59:59")]
		public void HumanReadableTest(int input, string expected)
		{
			string actual = TimeFormat.GetReadableTime(input);
			Assert.Equal(expected, actual);
		}
	}

	public static class TimeFormat
	{
		public static string GetReadableTime(int seconds)
		{
			const int hourDividor = 3600;
			const int minuteDividor = 60;

			int hours = seconds / hourDividor;
			int hoursInSeconds = (int) (Math.Floor((double) seconds / hourDividor) * hourDividor);
			seconds -= hoursInSeconds;

			int minutes = seconds / minuteDividor;
			int minutesInSeconds = (int) (Math.Floor((double) seconds / minuteDividor) * minuteDividor);
			seconds -= minutesInSeconds;

			//return $"{hours:00}:{minutes:00}:{seconds:00}";
			return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
		}
	}
}
