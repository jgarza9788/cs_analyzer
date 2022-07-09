using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/friend-or-foe/train/csharp
	/// </summary>
	public class FriendOrFoeTest
	{
		[Test]
		public void Test1()
		{
			string[] expected = { "Ryan", "Mark" };
			string[] names = { "Ryan", "Kieran", "Mark", "Jimmy" };
			CollectionAssert.AreEqual(expected, Kata.FriendOrFoe(names));
		}
	}

	public partial class Kata
	{
		public static IEnumerable<string> FriendOrFoe(string[] names)
		{
			return names.Where(name => name.Length == 4);
		}
	}
}
