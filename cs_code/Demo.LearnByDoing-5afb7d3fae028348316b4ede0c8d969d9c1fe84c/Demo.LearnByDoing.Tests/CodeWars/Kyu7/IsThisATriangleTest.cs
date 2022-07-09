using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu7
{
	/// <summary>
	/// https://www.codewars.com/kata/is-this-a-triangle/train/csharp
	/// </summary>
	public class IsThisATriangleTest : BaseTest
	{
		public IsThisATriangleTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(5, 7, 10, true)]
		[InlineData(3, 4, 9, false)]
		public void IsTriangle_ValidPostiveNumbers_ReturnsTrue(int a, int b, int c, bool expected)
		{
			bool actual = Triangle.IsTriangle(a, b, c);
			Assert.Equal(expected, actual);
		}
	}

	public class Triangle
	{
		/// <remarks>
		/// http://www.summithill.org/FileUploads/TeacherFiles/Determiningifatriangleispossible_3_12_2013_9_05_23_AM.ppt
		/// </remarks>
		public static bool IsTriangle(int a, int b, int c)
		{
			if (a + b <= c) return false;
			if (a + c <= b) return false;
			if (b + c <= a) return false;

			return true;
		}
	}
}
