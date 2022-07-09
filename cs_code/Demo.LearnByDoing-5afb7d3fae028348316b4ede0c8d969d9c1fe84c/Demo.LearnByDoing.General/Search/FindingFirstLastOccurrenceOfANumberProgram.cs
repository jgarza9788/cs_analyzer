using System;
using System.Diagnostics;

namespace Demo.LearnByDoing.General.Search
{
	/// <summary>
	/// Binary search - finding first or last occurrence of a number
	/// https://youtu.be/OE7wUUpJw6I?list=PL2_aWCzGMAwLPEZrZIcNEq9ukGWPfLT4A
	/// </summary>
	public class FindingFirstLastOccurrenceOfANumberProgram
	{
		public static void Main(string[] args)
		{
			int[] numbers = {2, 4, 10, 10, 10, 18, 20};
			const int searchNumber = 10;
			int first = GetFirstOccurrence(numbers, searchNumber);
			Debug.Assert(first == 2);
			Console.WriteLine("First occurrence index = {0}", first);

			int last = GetLastOccurrence(numbers, searchNumber);
			Debug.Assert(last == 4);
			Console.WriteLine("Last occurrence index = {0}", last);
		}

		private static int GetFirstOccurrence(int[] numbers, int searchNumber)
		{
			int low = 0;
			int high = numbers.Length - 1;
			int result = int.MinValue;

			while (low <= high)
			{
				int mid = (low + high) / 2;
				if (searchNumber == numbers[mid])
				{
					result = mid;
					high = mid - 1;
				}
				else if (searchNumber < numbers[mid])
				{
					high = mid - 1;
				}
				else
				{
					low = mid + 1;
				}
			}

			return result;
		}

		private static int GetLastOccurrence(int[] numbers, int searchNumber)
		{
			int low = 0;
			int high = numbers.Length - 1;
			int result = int.MinValue;

			while (low <= high)
			{
				int mid = (low + high) / 2;
				if (searchNumber == numbers[mid])
				{
					result = mid;
					low = mid + 1;
				}
				else if (searchNumber < numbers[mid])
				{
					high = mid - 1;
				}
				else
				{
					low = mid + 1;
				}
			}

			return result;

		}
	}
}
