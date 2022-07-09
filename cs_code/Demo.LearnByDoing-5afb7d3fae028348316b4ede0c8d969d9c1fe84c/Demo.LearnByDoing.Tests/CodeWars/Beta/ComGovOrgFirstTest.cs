using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Beta
{
	/// <summary>
	/// https://www.codewars.com/kata/com-gov-org-first
	/// </summary>
	public class ComGovOrgFirstTest : BaseTest
	{
		public ComGovOrgFirstTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void SimpleTests()
		{
			var source = new[] {
				"http://www.google.en/?x=jsdfkj",
				"http://www.google.de/?x=jsdfkj",
				"http://www.google.com/?x=jsdfkj",
				"http://www.google.com/?x=jsdfkj",
				"http://www.google.org/?x=jsdfkj",
				"http://www.google.gov/?x=jsdfkj",
			};
			var result = source.OrderByDomain();

			var expected = new[] {
				"http://www.google.com/?x=jsdfkj",
				"http://www.google.com/?x=jsdfkj",
				"http://www.google.gov/?x=jsdfkj",
				"http://www.google.org/?x=jsdfkj",
				"http://www.google.de/?x=jsdfkj",
				"http://www.google.en/?x=jsdfkj",
			};

			Assert.True(expected.SequenceEqual(result));

			//should be sorted  to
			//"http://www.google.com/?x=jsdfkj",
			//"http://www.google.com/?x=jsdfkj",
			//"http://www.google.gov/?x=jsdfkj",
			//"http://www.google.org/?x=jsdfkj",
			//"http://www.google.de/?x=jsdfkj",
			//"http://www.google.en/?x=jsdfkj",
		}
	}

	public static class SortingTask
	{
		public static IEnumerable<string> OrderByDomain(this IEnumerable<string> source)
		{
			return source.OrderBy(arg => arg, new DomainComparer());
		}
	}

	public class DomainComparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			var map = new Dictionary<string, int> { {".com", 1}, {".gov", 5}, {".org", 10} };
			var hostX = new Uri(x).Host;
			var hostY = new Uri(y).Host;

			var domainX = System.IO.Path.GetExtension(hostX);
			var domainY = System.IO.Path.GetExtension(hostY);

			const int notFound = 100;
			int xValue = notFound;
			if (map.ContainsKey(domainX))
				xValue = map[domainX];

			int yValue = notFound;
			if (map.ContainsKey(domainY))
				yValue = map[domainY];

			// Both domains are not in "com", "gov" or "org" so order alphabetically
			if (xValue == yValue)
			{
				if (xValue == notFound)
				{
					return String.Compare(x, y, StringComparison.Ordinal);
				}
				return 0;
			}
				

			if (xValue == notFound)
				return 1;
			if (yValue == notFound)
				return -1;
			return xValue - yValue;

			//return xValue - yValue;
		}
	}
}
