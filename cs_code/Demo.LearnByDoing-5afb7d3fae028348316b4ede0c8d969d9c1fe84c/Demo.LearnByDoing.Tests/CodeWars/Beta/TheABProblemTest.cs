using System.Text;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Beta
{
	/// <summary>
	/// https://www.codewars.com/kata/the-a-b-problem/train/csharp
	/// </summary>
	public class TheABProblemTest : BaseTest
	{
		public TheABProblemTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void BasicTests()
		{
			Assert.Equal(1621, Kata.problem(5858, 1234));
			Assert.Equal(1561, Kata.problem(3567, 2));
			Assert.Equal(2, Kata.problem(450, 449));
		}
	}

	public class Kata
	{
		public static int problem(int A, int B)
		{
			long diff = A - B;
			var sumText = diff.ToString();
			var buffer = new StringBuilder(sumText);
			if (diff >= int.MaxValue)
				buffer[0] = (char)(sumText[0] == '1' ? '2' : '1');
			else
				buffer[buffer.Length - 1] = (char)(sumText[0] == '2' ? '1' : '2');

			return int.Parse(buffer.ToString());
		}
	}
}
