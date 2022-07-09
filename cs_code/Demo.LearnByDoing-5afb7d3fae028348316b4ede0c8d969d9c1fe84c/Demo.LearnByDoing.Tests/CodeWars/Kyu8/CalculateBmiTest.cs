using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu8
{
	/// <summary>
	/// https://www.codewars.com/kata/calculate-bmi/train/csharp
	/// </summary>
	public class CalculateBmiTest
	{
		[Theory]
		[InlineData(-1, "Underweight")]
		[InlineData(17, "Underweight")]
		[InlineData(18.5, "Underweight")]
		[InlineData(18.6, "Normal")]
		[InlineData(20, "Normal")]
		[InlineData(25, "Normal")]
		[InlineData(25.0001, "Overweight")]
		[InlineData(30, "Overweight")]
		[InlineData(30.01, "Obese")]
		[InlineData(99999999, "Obese")]
		public void SampleTest(double bmi, string expected)
		{
			Assert.Equal(expected, Kata.Bmi(bmi));
		}
	}

	public partial class Kata
	{
		public static string Bmi(double bmi)
		{
			if (bmi <= 18.5) return "Underweight";
			if (bmi <= 25) return "Normal";
			if (bmi <= 30) return "Overweight";
			return "Obese";
		}

		public static string Bmi(double weight, double height)
		{
			var bmi = weight / (height * height);
			return Bmi(bmi);
		}
	}
}
