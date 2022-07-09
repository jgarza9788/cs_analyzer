using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Solution
{

	public class Kata
	{
		public static BigInteger[] Mixbonacci(string[] patterns, int n)
		{
			// Build sequence map
			var patternList = patterns.ToList();
			var sequenceMap = patternList
				.Distinct()
				.Select(pattern => new { Pattern = pattern, Strategy = Kata.GetNacciStrategy(pattern) })
				.ToDictionary(obj => obj.Pattern, obj => obj.Strategy.GetSequence(n).ToList());

			//var patternCountMap = Enumerable.Repeat(0, patterns.Length).ToArray();
			Dictionary<string, int> patternCountMap = new Dictionary<string, int>();
			foreach (string pattern in patterns)
			{
				if (!patternCountMap.ContainsKey(pattern))
					patternCountMap.Add(pattern, 0);
			}

			var actual = new List<BigInteger>(n);
			for (int i = 0; i < n; i++)
			{
				int patternIndex = i % patterns.Length;
				string pattern = patterns[patternIndex];
				int mapIndex = patternCountMap[pattern]++;

				actual.Add(sequenceMap[pattern][mapIndex]);
			}

			return actual.ToArray();
		}

		public static IGetSequence GetNacciStrategy(string pattern)
		{
			switch (pattern)
			{
				case "fib": return new Fibonacci();
				case "pad": return new Padovan();
				case "jac": return new Jacobsthal();
				case "pel": return new Pell();
				case "tri": return new Tribonacci();
				case "tet": return new Tetranacci();
				default: throw new Exception();
			}
		}
	}

	public class Tetranacci : IGetSequence
	{
		public IEnumerable<BigInteger> GetSequence(int n)
		{
			if (n <= 3)
			{
				if (n == 0) yield return 0;
				if (n == 1) yield return 0;
				if (n == 2) yield return 0;
				if (n == 3) yield return 1;

				yield break;
			}

			BigInteger prev0 = 0;
			BigInteger prev1 = 0;
			BigInteger prev2 = 0;
			BigInteger prev3 = 1;

			yield return prev0;
			yield return prev1;
			yield return prev2;

			for (int i = 3; i <= n; i++)
			{
				var current = prev0 + prev1 + prev2 + prev3;

				prev3 = prev2;
				prev2 = prev1;
				prev1 = prev0;
				prev0 = current;

				yield return current;
			}

		}
	}

	public class Tribonacci : IGetSequence
	{
		public IEnumerable<BigInteger> GetSequence(int n)
		{
			if (n <= 2)
			{
				if (n == 0) yield return 0;
				if (n == 1) yield return 0;
				if (n == 2) yield return 1;

				yield break;
			}

			BigInteger prev0 = 0;
			BigInteger prev1 = 0;
			BigInteger prev2 = 1;

			yield return prev0;
			yield return prev1;

			for (int i = 2; i <= n; i++)
			{
				var current = prev0 + prev1 + prev2;

				prev2 = prev1;
				prev1 = prev0;
				prev0 = current;

				yield return current;
			}

		}
	}

	public class Pell : IGetSequence
	{
		public IEnumerable<BigInteger> GetSequence(int n)
		{
			if (n <= 1)
			{
				yield return n;
				yield break;
			}

			BigInteger prev1 = 0;
			BigInteger prev2 = 1;

			yield return prev1;
			yield return prev2;

			for (int i = 2; i <= n; i++)
			{
				var current = (2 * prev2) + prev1;
				yield return current;

				prev1 = prev2;
				prev2 = current;
			}

		}
	}

	public class Jacobsthal : IGetSequence
	{
		public IEnumerable<BigInteger> GetSequence(int n)
		{
			if (n <= 1)
			{
				yield return n;
				yield break;
			}

			BigInteger prev1 = 0;
			BigInteger prev2 = 1;

			yield return prev1;
			yield return prev2;

			for (int i = 2; i <= n; i++)
			{
				var current = prev2 + (2 * prev1);
				yield return current;

				prev1 = prev2;
				prev2 = current;
			}
		}
	}

	public class Padovan : IGetSequence
	{
		public IEnumerable<BigInteger> GetSequence(int n)
		{
			if (n <= 2)
			{
				if (n == 0) yield return 1;
				if (n == 1) yield return 0;
				if (n == 2) yield return 0;

				yield break;
			}

			BigInteger prev0 = 1;
			BigInteger prev1 = 0;
			BigInteger prev2 = 0;
			BigInteger current = prev0 + prev1;

			yield return prev0;
			yield return prev1;
			yield return prev2;

			for (int i = 3; i <= n; i++)
			{
				current = prev0 + prev1;
				yield return current;

				prev0 = prev1;
				prev1 = prev2;
				prev2 = current;
			}
		}
	}

	public class Fibonacci : IGetSequence
	{
		public IEnumerable<BigInteger> GetSequence(int n)
		{
			if (n <= 1)
			{
				yield return n;
				yield break;
			}

			BigInteger prev1 = 0;
			BigInteger prev2 = 1;

			yield return prev1;
			yield return prev2;

			for (int i = 2; i <= n; i++)
			{
				var current = prev1 + prev2;
				yield return current;

				prev1 = prev2;
				prev2 = current;
			}
		}
	}

	public interface IGetSequence
	{
		IEnumerable<BigInteger> GetSequence(int n);
	}
}
