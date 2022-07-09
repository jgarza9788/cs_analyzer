using System;
using System.Linq;
using System.Security.Cryptography;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/shuffle
	/// 
	/// 
	/// 
	/// Write a method for doing an in-place ↴ shuffle of an array.
	/// 
	/// The shuffle must be "uniform," meaning each item in the original array must have the same probability of ending up in each spot in the final array.
	/// 
	/// Assume that you have a method GetRandom(floor, ceiling) for getting a random integer that is &gt;= floor and &lt;= ceiling.
	/// </summary>
	public class Question035Test : BaseTest
	{
		public Question035Test(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestRandomNumber()
		{
			int[] input = {1, 2, 3, 4, 5};
			for (int i = 0; i < 10; i++)
			{
				int[] shuffled = ShuffleInPlace(input);
				_output.WriteLine(string.Join(",", shuffled.Select(n => n.ToString())));
			}
		}

		private int[] ShuffleInPlace(int[] input)
		{
			int currentIndex = input.Length;
			
			while (--currentIndex > 0)
			{
				int randomIndex = GetRandom(floor: 0, ceiling: currentIndex);
				var temp = input[currentIndex];
				input[currentIndex] = input[randomIndex];
				input[randomIndex] = temp;
			}

			return input;
		}

		private readonly RNGCryptoServiceProvider _rngCsp = new RNGCryptoServiceProvider();

		private int GetRandom(int floor, int ceiling)
		{
			//return new Random().Next(floor, ceiling);

			// https://stackoverflow.com/a/16461419/4035
			byte[] data = new byte[8];
			_rngCsp.GetBytes(data);
			var value = BitConverter.ToUInt32(data, 0);
			var result = (int) ((value % ceiling) + floor);
			return result;
		}
	}
}
