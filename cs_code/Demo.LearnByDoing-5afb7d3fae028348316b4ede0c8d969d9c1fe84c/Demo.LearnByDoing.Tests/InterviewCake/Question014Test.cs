using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	public class Question014Test
	{
		private Question014 _sut;

		public Question014Test()
		{
			_sut = new Question014();
		}

		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCases(bool expected, int n, int[] a)
		{
			bool actual = _sut.HasCombination(a, n);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetSampleCases()
		{
			var a1 = new[] { 1, 2, -5, 10, 3, 4 };
			yield return new object[] { true, 13, a1 };
			yield return new object[] { true, 5, a1 };
			yield return new object[] { true, -2, a1 };
			yield return new object[] { true, 7, a1 };
			yield return new object[] { false, 8, a1 };
			yield return new object[] { true, 6, a1 };
			yield return new object[] { false, 9, a1 };
			yield return new object[] { true, -1, a1 };

			var a2 = new[] {1, 2, 2, 3, 3, 4, 4};
			yield return new object[] {true, 4, a2};
			yield return new object[] {true, 8, a2};
			yield return new object[] {true, 6, a2};
		}
	}

	public class Question014
	{
		/// <summary>
		/// Implementation using HashSet (from IC answer)
		/// </summary>
		public bool HasCombination(int[] a, int n)
		{
			var isSeen = new HashSet<int>();
			foreach (var currentValue in a)
			{
				var compliment = n - currentValue;
				if (isSeen.Contains(compliment)) return true;
				isSeen.Add(currentValue);
			}

			return false;
		}

		public bool HasCombinationGood(int[] a, int n)
		{
			var map = a.GroupBy(x => x).ToDictionary(o => o.Key, o => o.Count());

			foreach (var currentValue in a)
			{
				var compliment = n - currentValue;
				if (map.ContainsKey(compliment))
				{
					if (compliment == currentValue && map[compliment] > 1) return true;
					if (compliment != currentValue) return true;
				}
			}

			return false;
		}

		public bool HasCombination_StillNotGood(int[] a, int n)
		{
			var map = a.Select((number, i) => new {number, i}).ToDictionary(o => o.number, o => o.i);
			for (int i = 0; i < a.Length; i++)
			{
				var curr = a[i];
				var compliment = n - curr;
				if (map.ContainsKey(compliment) && map[compliment] != i) return true;
			}

			return false;
		}

		public bool HasCombination_NotGood(int[] a, int n)
		{
			// Build a lookup table for compliments.
			var map = new HashSet<int>(a);

			foreach (var value in a)
			{
				var compliment = n - value;
				// skip the same number.
				if (compliment == value) continue;
				if (map.Contains(compliment)) return true;
			}

			return false;
		}
	}
}
