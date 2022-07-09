using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/556deca17c58da83c00002db/train/csharp
	/// </summary>
	[TestFixture]
	public class TribonacciSequenceTest
	{
		private Xbonacci variabonacci;

		[SetUp]
		public void SetUp()
		{
			variabonacci = new Xbonacci();
		}

		[TearDown]
		public void TearDown()
		{
			variabonacci = null;
		}

		[Test]
		public void Tests()
		{
			Assert.AreEqual(new double[] { 1, 1, 1, 3, 5, 9, 17, 31, 57, 105 }, variabonacci.Tribonacci(new double[] { 1, 1, 1 }, 10));
			Assert.AreEqual(new double[] { 0, 0, 1, 1, 2, 4, 7, 13, 24, 44 }, variabonacci.Tribonacci(new double[] { 0, 0, 1 }, 10));
			Assert.AreEqual(new double[] { 0, 1, 1, 2, 4, 7, 13, 24, 44, 81 }, variabonacci.Tribonacci(new double[] { 0, 1, 1 }, 10));
		}
	}

	public class Xbonacci
	{
		public double[] Tribonacci(double[] signature, int n)
		{
			if (n == 0) return new double[1] { 0.0d };
			Console.WriteLine($"n={n}, {string.Join(",", signature.Select(x => x.ToString()))}");

			double n1 = signature[0];
			double n2 = signature[1];
			double n3 = signature[2];

			var result = new List<double>(signature.Take(3));

			for (int i = 3; i < n; i++)
			{
				var current = n1 + n2 + n3;
				n1 = n2;
				n2 = n3;
				n3 = current;

				result.Add(current);
			}

			return result.Take(n == 0 ? 1 : n).ToArray();
		}
	}
}
