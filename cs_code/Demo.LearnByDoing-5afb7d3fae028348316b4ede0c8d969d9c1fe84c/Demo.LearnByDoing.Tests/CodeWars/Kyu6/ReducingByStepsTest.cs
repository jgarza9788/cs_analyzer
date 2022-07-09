using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/reducing-by-steps/train/csharp
	/// </summary>
	[TestFixture]
	public class ReducingByStepsTest
	{
		private static void testing(string actual, string expected)
		{
			Assert.AreEqual(expected, actual);
		}
		public static string Array2String(long[] list)
		{
			return "[" + string.Join(",", list) + "]";
		}
		[Test]
		public static void test0()
		{
			Console.WriteLine("Fixed Tests ; gcdi, lcmu, som, mini, maxi");
			long[] a = { 18, 69, -90, -78, 65, 40 };
			long[] r = { 18, 3, 3, 3, 1, 1 };
			long[] op = Operarray.OperArray(Operarray.gcdi, a, a[0]);
			testing(Array2String(op), Array2String(r));

			r = new long[] { 18, 414, 2070, 26910, 26910, 107640 };
			op = Operarray.OperArray(Operarray.lcmu, a, a[0]);
			testing(Array2String(op), Array2String(r));

			r = new long[] { 18, 87, -3, -81, -16, 24 };
			op = Operarray.OperArray(Operarray.som, a, 0);
			testing(Array2String(op), Array2String(r));

			r = new long[] { 18, 18, -90, -90, -90, -90 };
			op = Operarray.OperArray(Operarray.mini, a, a[0]);
			testing(Array2String(op), Array2String(r));

			r = new long[] { 18, 69, 69, 69, 69, 69 };
			op = Operarray.OperArray(Operarray.maxi, a, a[0]);
			testing(Array2String(op), Array2String(r));


			long[] x = {-73, -79, 19, -15, 99, 84};
			r = new long[] { 73, 5767, 109573, 1643595, 54238635, 1518681780 };
			op = Operarray.OperArray(Operarray.lcmu, x, x[0]);
			testing(Array2String(op), Array2String(r));


		}
	}

	public class Operarray
	{
		// https://en.wikipedia.org/wiki/Greatest_common_divisor#Using_Euclid.27s_algorithm
		//public static long gcdi(long x, long y)
		//{
		//	var a = Math.Abs(x);
		//	var b = Math.Abs(y);

		//	if (a > b) return gcdi(a - b, b);
		//	if (a < b) return gcdi(a, b - a);

		//	return a;
		//}

		public static long gcdi(long x, long y)
		{
			var a = Math.Abs(x);
			var b = Math.Abs(y);

			if (b == 0) return a;

			return gcdi(b, a % b);
		}

		public static long lcmu(long x, long y)
		{
			var a = Math.Abs(x);
			var b = Math.Abs(y);

			return (a * b) / gcdi(a, b);
		}
		public static long som(long a, long b)
		{
			return a + b;
		}
		public static long maxi(long a, long b)
		{
			return Math.Max(a, b);
		}
		public static long mini(long a, long b)
		{
			return Math.Min(a, b);
		}
		//public static long oper(Func<long, long, long> fct, long a, long b)
		//{
		//	// Your code
		//}
		public static long[] OperArray(Func<long, long, long> fct, long[] arr, long init)
		{
			foreach (var x in arr) Console.Write($"{fct.Method.Name} => {x} ");

			var result = new List<long>();
			long a = init;

			try
			{
				foreach (var b in arr)
				{
					long computed = fct(a, b);
					result.Add(computed);

					a = computed;
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			return result.ToArray();
		}
	}
}
