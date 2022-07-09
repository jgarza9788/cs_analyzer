using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/extension-groupwhile-consecutive-by-the-condition-items/train/csharp
	/// </summary>
	public class ExtensionGroupWhileConsecutiveByTheConditionItemsTest
	{
		[Test]
		public void EdgeCaseTest()
		{
			Func<object, bool> isEverything = (e) => 1 == 1;

			List<object> test = new List<object> { 'L', 'e', 't', 't', 'e', 'r', '1', '2', '4', '=', 'a', 'B', 'E', 'l', 'T', '%' };

			var expected = new List<List<object>>
			{
				new List<object> { 'L', 'e', 't', 't', 'e', 'r', '1', '2', '4', '=', 'a', 'B', 'E', 'l', 'T', '%' }
			};

			var actual = test.GroupWhile(isEverything);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void BasicTest1()
		{
			Func<object, bool> isLetter = (e) => char.IsLetter(Convert.ToChar(e));

			List<object> test = new List<object> { 'L', 'e', 't', 't', 'e', 'r', '1', '2', '4', '=', 'a', 'B', 'E', 'l', 'T', '%' };

			var expected = new List<List<object>>
			{
				new List<object> { 'L', 'e', 't', 't', 'e', 'r' },
				new List<object> { '1' },
				new List<object> { '2' },
				new List<object> { '4' },
				new List<object> { '=' },
				new List<object> { 'a', 'B', 'E', 'l', 'T' },
				new List<object> { '%' }
			};

			var actual = test.GroupWhile(isLetter);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void BasicTest2()
		{
			Func<object, bool> isGreaterThan10 = (e) => Convert.ToInt32(e) > 10;

			List<object> test = new List<object> { 7, 8, 9, 10, 12, 14, 16, 18, 20 };

			var expected = new List<List<object>>
			{
				new List<object> { 7 },
				new List<object> { 8 },
				new List<object> { 9 },
				new List<object> { 10 },
				new List<object> { 12, 14, 16, 18, 20 }
			};

			var actual = test.GroupWhile(isGreaterThan10);

			Assert.AreEqual(expected, actual);
		}
	}

	static class Kata1
	{
		public static List<List<object>> GroupWhile(this IEnumerable<object> coll, Func<object, bool> pred)
		{
			var outter = new List<List<object>>();
			var inner = new List<object>();

			foreach (var obj in coll)
			{
				if (pred(obj))
				{
					inner.Add(obj);
				}
				else
				{
					if (inner.Count > 0)
						outter.Add(inner);
					inner = new List<object>();

					outter.Add(new List<object> { obj });
				}
			}

			if (inner.Count > 0)
				outter.Add(inner);

			return outter;
		}
	}
}
