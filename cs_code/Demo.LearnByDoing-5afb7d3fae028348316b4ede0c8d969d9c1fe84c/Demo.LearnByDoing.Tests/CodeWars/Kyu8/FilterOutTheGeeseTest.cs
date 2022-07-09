using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu8
{
	/// <summary>
	/// https://www.codewars.com/kata/filter-out-the-geese/train/csharp
	/// </summary>
	public class FilterOutTheGeeseTest
	{
		[Fact]
		public void SampleTest()
		{
			Assert.Equal(new[] { "Mallard", "Hook Bill", "Crested", "Blue Swedish" },
				Filter.GooseFilter(new[] { "Mallard", "Hook Bill", "African", "Crested", "Pilgrim", "Toulouse", "Blue Swedish" }));

			Assert.Equal(new[] { "Mallard", "Barbary", "Hook Bill", "Blue Swedish", "Crested" },
				Filter.GooseFilter(new[] { "Mallard", "Barbary", "Hook Bill", "Blue Swedish", "Crested" }));

			Assert.Equal(new string[] { },
				Filter.GooseFilter(new[] { "African", "Roman Tufted", "Toulouse", "Pilgrim", "Steinbacher" }));
		}
	}

	public static class Filter
	{
		public static IEnumerable<string> GooseFilter(IEnumerable<string> birds)
		{
			// return IEnumerable of string containing all of the strings in the input collection, except those that match strings in geese
			string[] geese = new string[] { "African", "Roman Tufted", "Toulouse", "Pilgrim", "Steinbacher" };

			return birds.Except(geese);
		}
	}
}
