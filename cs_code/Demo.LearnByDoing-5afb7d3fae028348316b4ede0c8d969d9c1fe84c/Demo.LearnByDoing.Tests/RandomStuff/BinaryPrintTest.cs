using System;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
	/// <summary>
	/// https://medium.freecodecamp.org/learn-recursion-in-10-minutes-e3262ac08a1
	/// </summary>
	public class BinaryPrintTest : BaseTest
	{
		public BinaryPrintTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void JustPrint()
		{
			var digit = 2;
			//var a = new int[digit];
			int[] a = Enumerable.Repeat(-9999, digit).ToArray();
			PrintBinaryCombinations(a, digit, step);
		}

		private static int step = 0;

		private void PrintBinaryCombinations(int[] a, int i, int step)
		{
			step++;
			_output.WriteLine("Step " + step);
			PrintArray(a);
			if (i == 0)
			{
				_output.WriteLine($"{step}# => {string.Join("", a.Select(n => n))} ");
				return;
			}

			a[i - 1] = 0;
			PrintBinaryCombinations(a, i - 1, step);
			a[i - 1] = 1;
			PrintBinaryCombinations(a, i - 1, step);
		}

		private void PrintArray(int[] a)
		{
			_output.WriteLine("===" + string.Join(", ", a.Select(n => n.ToString())));
			//foreach (var n in a)
			//{
			//	_output.WriteLine("==" + n);
			//}
		}
	}
}
