using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/rectangular-love?
	/// </summary>
	public class Question006Test
	{
	}

	class Rectangle
	{
		// Coordinates of bottom left corner
		public int LeftX { get; set; }									
		public int BottomY { get; set; }

		// Dimensions
		public int Width { get; set; }
		public int Height { get; set; }

		public Rectangle() { }

		public Rectangle(int leftX, int bottomY, int width, int height)
		{
			LeftX = leftX;
			BottomY = bottomY;
			Width = width;
			Height = height;
		}
	}
}
