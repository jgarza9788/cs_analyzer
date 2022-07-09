using System;
using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	public class Question012Test
	{
		private readonly Question012 _sut;

		public Question012Test()
		{
			_sut = new Question012();
		}

		public static IEnumerable<object[]> GoodPathData()
		{
			yield return new object[] { true, new[] { 1, 2, 3, 4, 5 }, 1 };
			yield return new object[] { true, new[] { 1, 2, 3, 4, 5 }, 2 };
			yield return new object[] { true, new[] { 1, 2, 3, 4, 5 }, 3 };
			yield return new object[] { true, new[] { 1, 2, 3, 4, 5 }, 4 };
			yield return new object[] { true, new[] { 1, 2, 3, 4, 5 }, 5 };
			yield return new object[] { false, new[] { 1, 2, 3, 4, 5 }, 6 };
			yield return new object[] { true, new[] { -11, -2, 3, 4, 5 }, -11 };
			yield return new object[] { true, new[] { -11, -2, 3, 4, 5 }, -2 };
			yield return new object[] { false, new[] { -11, -2, 3, 4, 5 }, -5 };
			yield return new object[] { false, new[] { -11, -2, 3, 4, 5 }, 6 };
			yield return new object[] { false, new[] { -11, -2, 3, 4, 5 }, -99 };

			yield return new object[] { true, new[] { 1,2,3,4,5,6,7,8,9 }, 1 };
			yield return new object[] { true, new[] { 1,2,3,4,5,6,7,8,9 }, 2 };
			yield return new object[] { true, new[] { 1,2,3,4,5,6,7,8,9 }, 3 };
			yield return new object[] { true, new[] { 1,2,3,4,5,6,7,8,9 }, 4 };
			yield return new object[] { true, new[] { 1,2,3,4,5,6,7,8,9 }, 5 };
			yield return new object[] { true, new[] { 1,2,3,4,5,6,7,8,9 }, 6 };
			yield return new object[] { true, new[] { 1,2,3,4,5,6,7,8,9 }, 7 };
			yield return new object[] { true, new[] { 1,2,3,4,5,6,7,8,9 }, 8 };
			yield return new object[] { true, new[] { 1,2,3,4,5,6,7,8,9 }, 9 };
		}

		[Theory]
		[MemberData(nameof(GoodPathData))]
		public void TestGoodPaths(bool expected, int[] a, int n)
		{
			bool actual = _sut.Contains(a, n);
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestEdgeCases()
		{
			const int n = 1;
			Assert.Throws<ArgumentNullException>(() => _sut.Contains(null, n));
		}
	}

	public class Question012
	{
		public bool Contains(int[] a, int n)
		{
			if (a == null) throw new ArgumentNullException();

			// Use Binary Search

			// Get the middle index
			// Get the value in the middle of the array
			// If n == middle value then return.
			// If the value is less than the middle value, then search the left
			// If the value is greater than the middle value, then search the right

			int startIndex = 0;
			int endIndex = a.Length - 1;

			while (startIndex <= endIndex)
			{
				var middleIndex = (startIndex + endIndex) / 2;
				var middle = a[middleIndex];
				if (middle == n) return true;

				if (n < middle)
					endIndex = middleIndex - 1;
				else
					startIndex = middleIndex + 1;
			}
			
			return false;
		}
	}
}
