using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Demo.LearnByDoing.General
{
	/// <summary>
	/// https://www.mindmeister.com/871561963
	/// 
	/// Write a method that, given an integer, will return it as an   array. E.g., given 1234, return [1, 2, 3, 4].
	/// </summary>
	public class ConvertIntegerToArrayProgram
	{
		public static void Main(string[] args)
		{
			int value = 1234567890;
			const int trialCount = 10000000;

			Stopwatch watch = new Stopwatch();
			watch.Start();

			for (int i = 0; i < trialCount; i++)
			{
				GetArray1(value);
			}
			watch.Stop();
			Console.WriteLine("Implementation using Stack: {0}", watch.Elapsed);

			watch.Reset();
			watch.Start();
			for (int i = 0; i < trialCount; i++)
			{
				GetArray2(value).ToList();
			}
			watch.Stop();
			Console.WriteLine("Implementation using int.parse: {0}", watch.Elapsed);

			watch.Reset();
			watch.Start();
			for (int i = 0; i < trialCount; i++)
			{
				GetArray3(value).ToList();
			}
			watch.Stop();
			Console.WriteLine("Implementation using ordinal number: {0}", watch.Elapsed);
		}

		private static int[] GetArray1(int value)
		{
			int currentValue = value;
			Stack<int> digits = new Stack<int>();
			while (currentValue > 0)
			{
				int digit = currentValue % 10;
				digits.Push(digit);
				currentValue /= 10;
			}

			return digits.ToArray();
		}

		private static IEnumerable<int> GetArray2(int value)
		{
			if (value < 0) value *= -1; // or Math.Abs

			string text = value.ToString();
			for (int i = 0; i < text.Length; i++)
			{
				yield return int.Parse(text[i].ToString());
			}
		}

		private static IEnumerable<int> GetArray3(int value)
		{
			if (value < 0) value *= -1;	// or Math.Abs

			string text = value.ToString();
			for (int i = 0; i < text.Length; i++)
			{
				yield return text[i] - '0';
			}
		}
	}
}
