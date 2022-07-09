using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/cartesian-neighbors/train/csharp
	/// </summary>
	public class CartesianNeighborsTest : BaseTest
	{
		public CartesianNeighborsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[MemberData(nameof(GetSampleData))]
		public void ExampleTests(List<int[]> expected, int x, int y)
		{
			var actual = Kata.cartesianNeighbor(2, 2).ToList();
			//actual.Sort((a1, a2) => a1[0] < a2[0] && a1[1] < a2[1] ? -1 :
			//	a1[0] == a2[0] && a1[1] == a2[1] ? 0 : 1);
			//expected.Sort((a1, a2) => a1[0] < a2[0] && a1[1] < a2[1] ? -1 :
			//	a1[0] == a2[0] && a1[1] == a2[1] ? 0 : 1);

			Assert.True(expected.SequenceEqual(actual));
		}

		public static IEnumerable<object[]> GetSampleData()
		{
			yield return new object[] {new List<int[]>{
				new []{1,1}, new []{1,2}, new []{1,3},
				new []{2,1}, new []{2,3}, new []{3,1},
				new []{3,2}, new []{3,3}
			}, 2, 2};
			yield return new object[] {new List<int[]>{
				new [] {6,7}, new [] {6,6}, new [] {6,8},
				new [] {4,7}, new [] {4,6}, new [] {4,8},
				new [] {5,6}, new [] {5,8}
			}, 5, 7};
		}
	}

	public partial class Kata
	{
		public static IEnumerable<int[]> cartesianNeighbor(int x, int y)
		{
			yield return new [] {x - 1, y - 1};
			yield return new [] {x - 1, y};
			yield return new [] {x - 1, y + 1};
			yield return new [] {x, y - 1};
			yield return new [] {x, y + 1};
			yield return new [] {x + 1, y - 1};
			yield return new [] {x + 1, y};
			yield return new [] {x + 1, y + 1};
		}
	}
}
