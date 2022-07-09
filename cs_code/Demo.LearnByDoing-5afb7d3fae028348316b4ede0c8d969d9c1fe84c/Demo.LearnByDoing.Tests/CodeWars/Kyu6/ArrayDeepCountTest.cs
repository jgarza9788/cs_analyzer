using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/array-deep-count/train/csharp
	/// </summary>
	public class ArrayDeepCountTest
	{
		[Theory]
		[MemberData(nameof(GetBasicTestCases))]
		public void Basic_Tests(object test, int expected)
		{
			Assert.Equal(expected, Kata.DeepCount(test));
		}

		public static IEnumerable<object[]> GetBasicTestCases()
		{
			yield return new object[] {new object[] { }, 0};
			yield return new object[] { new object[] {1, 2, 3}, 3 };
			yield return new object[] { new object[] {"x", "y", new object[] {"z"}}, 4 };
			yield return new object[] { new object[] {1, 2, new object[] {3, 4, new object[] {5}}}, 7 };
			yield return new object[] { new object[] { new object[] { new object[] { new object[] { new object[] { new object[] { new object[] { new object[] { new object[] {}}}}}}}}}, 8 };
		}
	}

	public partial class Kata
	{
		public static int DeepCount(object o)
		{
			var a = o as object[];
			if (a == null) return 0;

			return a.Length + a.Where(x => x.GetType().IsArray).Select(DeepCount).Sum();

			/*
					var o = o as object[];
					if (o == null) return 0;

			  foreach (var i in o) {
				Console.WriteLine(i);
			  }

					bool hasArray = o.Count(x => x.GetType().IsArray) > 0;
					if (!hasArray && o.Length == 0) return 0;
					if (!hasArray) return o.Length;

					return o.Length == 0 ? 1 : o.Length + DeepCount(o.First(x => x.GetType().IsArray));
			  */
		}
	}
}
