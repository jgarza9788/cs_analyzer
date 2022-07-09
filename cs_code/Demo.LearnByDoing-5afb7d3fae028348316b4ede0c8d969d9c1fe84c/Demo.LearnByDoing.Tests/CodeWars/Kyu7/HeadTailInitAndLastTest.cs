using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/head-tail-init-and-last/train/csharp
	/// </summary>
	public class HeadTailInitAndLastTest : BaseTest
	{
		public HeadTailInitAndLastTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void SampleTest()
		{
			Assert.Equal(5, new List<int> { 5, 1 }.Head());
			Assert.Equal(new List<int> { 2, 3 }, new List<int> { 1, 2, 3 }.Tail());
			Assert.Equal(new List<int> { 1, 5, 7 }, new List<int> { 1, 5, 7, 9 }.Init());
			Assert.Equal(2, new List<int> { 7, 2 }.Last_());
		}
	}

	public static class ArrayMethods
	{
		public static TSource Head<TSource>(this List<TSource> list)
		{
			return list.FirstOrDefault();
		}

		public static List<TSource> Tail<TSource>(this List<TSource> list)
		{
			if (list == null || list.Count <= 1) return new List<TSource>();

			return list.Skip(1).ToList();
		}

		public static List<TSource> Init<TSource>(this List<TSource> list)
		{
			if (list == null || list.Count <= 1) return new List<TSource>();

			return list.Where((val, index) => index < list.Count - 1).ToList();
		}

		public static TSource Last_<TSource>(this List<TSource> list)
		{
			return list.LastOrDefault();
		}
	}
}
