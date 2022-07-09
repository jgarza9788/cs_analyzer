using System;

namespace Demo.LearnByDoing.General
{
	public class FindValueInSortedArrayProgram
	{
		public static void Main(string[] args)
		{
			int[] a = {1, 2, 3, 4, 5, 6, 7};

			for (int i = 0; i < 100000000; i++)
			{
				bool isFound = FindValue(a, i);
				if (i % 100000 == 0)
					Console.WriteLine("{0} is found? {1}", i, isFound);
			}
		}

		private static bool FindValue(int[] a, int value)
		{
			int low = 0;
			int high = a.Length;
			int mid = (low + high) / 2;

			while (low <= high)
			{
				if (mid > a.Length - 1) return false;
				if (a[mid] == value) return true;

				if (a[mid] < value)
					low = mid + 1;
				else
					high = mid - 1;

				mid = (low + high) / 2;
			}

			return false;
		}
	}
}
