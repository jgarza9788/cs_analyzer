using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	public class Question015Test
	{
		private readonly Question015 _sut = new Question015();

		[Theory]
		[MemberData(nameof(GetSampleData))]
		public void TestSampleData(int n, int expected)
		{
			int actual = _sut.GetNthFib(n);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[MemberData(nameof(GetSampleData))]
		public void TestSampleDataUsingBitnetsFormula(int n, int expected)
		{
			int actual = _sut.GetNthFibUsingBinetsFormula(n);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetSampleData()
		{
			yield return new object[]{0, 0};
			yield return new object[]{1, 1};
			yield return new object[]{2, 1};
			yield return new object[]{3, 2};
			yield return new object[]{4, 3};
			yield return new object[]{5, 5};
			yield return new object[]{6, 8};
			yield return new object[]{7, 13};
			yield return new object[]{8, 21};
			yield return new object[]{9, 34};
		}
	}

	internal class Question015
	{
		/// <summary>
		/// https://artofproblemsolving.com/wiki/index.php?title=Binet%27s_Formula
		/// </summary>
		public int GetNthFibUsingBinetsFormula(int n)
		{
			double sqrt5 = Math.Sqrt(5);

			return (int)((1 / sqrt5) *
			             (
				             Math.Pow((1 + sqrt5) / 2, n)
				             -
				             Math.Pow((1 - sqrt5) / 2, n)
			             ));
		}

		public int GetNthFib(int n)
		{
			if (n < 2) return n;

			int prev1 = 0;
			int prev2 = 1;
			int current = prev1 + prev2;

			for (int i = 2; i < n; i++)
			{
				prev1 = prev2;
				prev2 = current;
				current = prev1 + prev2;
			}

			return current;
		}
	}
}
