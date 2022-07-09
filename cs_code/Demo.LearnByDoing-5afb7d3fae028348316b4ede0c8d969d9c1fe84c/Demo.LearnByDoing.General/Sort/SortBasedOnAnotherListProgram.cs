using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General.Sort
{
	public class SortBasedOnAnotherListProgram
	{
		public static void Main(string[] args)
		{
			int[] a = {1, 2, 3, 4};
			string[] words = {"string1", "string2", "string3", "string4"};

			// sort "words" when "a" is reversed.
			var reversedWords = SortAtRandom(a, words).ToList();
			reversedWords.ForEach(text => Console.Write($"{text} "));
		}

		private static IEnumerable<string> SortAtRandom(int[] a, string[] words)
		{
			var zipped = a.Zip(words, (key, word) => Tuple.Create(key, word)).ToList();
			//zipped.Sort((x, y) => -1 * x.Item1.CompareTo(y.Item1));
			//zipped.Sort((x, y) => Guid.NewGuid().CompareTo(Guid.NewGuid()));
			Random random = new Random();
			zipped.Sort((x, y) => random.Next().CompareTo(random.Next()));
			foreach (Tuple<int, string> tuple in zipped)
			{
				Console.Write($"{tuple.Item1} ");
			}
			Console.WriteLine();
			return zipped.Select(z => z.Item2);
		}
	}
}
