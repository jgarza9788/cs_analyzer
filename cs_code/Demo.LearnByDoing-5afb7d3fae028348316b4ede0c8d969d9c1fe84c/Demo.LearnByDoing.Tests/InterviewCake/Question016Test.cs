using System;
using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/cake-thief
	/// </summary>
	public class Question016Test
	{
		private readonly Question016 _sut = new Question016();

		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCases(double expected, CakeType[] cakeTypes, int capacity)
		{
			double actual = _sut.MaxDuffelBagValue(cakeTypes, capacity);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[]{0, new []
			{
				new CakeType(0, 0),
				new CakeType(0, 0),
				new CakeType(0, 0),
			}, 0};

			yield return new object[]{0, new []
			{
				new CakeType(2, 15),
				new CakeType(7, 160),
				new CakeType(3, 90),
			}, 0};

			yield return new object[]{555, new []
			{
				new CakeType(2, 15),
				new CakeType(7, 160),
				new CakeType(3, 90),
			}, 20};

			yield return new object[]{630, new []
			{
				new CakeType(2, 15),
				new CakeType(7, 160),
				new CakeType(3, 90),
			}, 21};
		}
	}

	internal class Question016
	{
		public double MaxDuffelBagValue(CakeType[] cakeTypes, int capacity)
		{
			var duffleBag = new int[cakeTypes.Length, capacity + 1];

			for (int rowIndex = 0; rowIndex < cakeTypes.Length; rowIndex++)
			{
				int maxCapacity = 0;
				for (int currentCapacity = 1; currentCapacity <= capacity; currentCapacity++)
				{
					var cake = cakeTypes[rowIndex];

					// If we have less capacity than the current cake's weight, then we can't add it to the dufflebag.
					if (cake.Weight > currentCapacity && rowIndex == 0)
					{
						duffleBag[rowIndex, currentCapacity] = 0;
						continue;
					}

					var previousMax = rowIndex == 0 ? 0 : duffleBag[rowIndex - 1, currentCapacity];
					// -- vs. --

					// Value of current item + 
					var multiplier = currentCapacity / cake.Weight;
					var currentValue = cake.Value * multiplier;

					// Value of remaining space
					var remainingSpace = multiplier == 0 ? 0 : currentCapacity - (cake.Weight * multiplier);
					var remainingSpaceValue = duffleBag[rowIndex, remainingSpace];
					var currentMax = currentValue + remainingSpaceValue;

					var newMax = (int)Math.Max(previousMax, currentMax);
					duffleBag[rowIndex, currentCapacity] = newMax;
				}
			}

			// Return the last item in the last row.
			return duffleBag[cakeTypes.Length - 1, capacity];
		}

		public double MaxDuffelBagValueBad(CakeType[] cakeTypes, int capacity)
		{
			var duffleBag = new int[cakeTypes.Length, capacity + 1];

			for (int rowIndex = 0; rowIndex < cakeTypes.Length; rowIndex++)
			{
				int maxCapacity = 0;
				for (int currentCapacity = 1; currentCapacity <= capacity; currentCapacity++)
				{
					var cake = cakeTypes[rowIndex];

					// If we have less capacity than the current cake's weight, then we can't add it to the dufflebag.
					if (cake.Weight > currentCapacity)
					{
						duffleBag[rowIndex, currentCapacity] = 0;
						continue;
					}

					var previousMax = rowIndex == 0 ? 0 : duffleBag[rowIndex - 1, currentCapacity];

					// currentMax = current value + Remaining space value.
					var multiplier = currentCapacity / cake.Weight;
					var currentValue = cake.Value * multiplier;
					var remainingSpace = capacity - (cake.Weight * multiplier);
					var remainingSpaceValue = rowIndex == 0 ? 0 : duffleBag[rowIndex, remainingSpace];
					var currentMax = currentValue + remainingSpaceValue;

					var newMax = (int) Math.Max(previousMax, currentMax);
					duffleBag[rowIndex, currentCapacity] = newMax;
				}
			}

			// Return the last item in the last row.
			return duffleBag[cakeTypes.Length - 1, capacity];
		}

		public static void PrintMatrix(int[,] matrix)
		{
			for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
			{
				for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
				{
					Console.Write($"{matrix[rowIndex, columnIndex]} ");
				}
				Console.WriteLine();
			}
		}
	}

	public class CakeType
	{
		public int Weight { get; }
		public long Value { get; }

		public CakeType(int weight, long value)
		{
			Weight = weight;
			Value = value;
		}
	}
}
