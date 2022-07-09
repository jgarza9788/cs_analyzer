using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// Temperature Tracker
	/// https://www.interviewcake.com/question/csharp/temperature-tracker
	/// </summary>
	public class Question007Test
	{
		[Theory]
		[MemberData(nameof(GetTestInsertData))]
		public void TestInsert(int[] temperatures, int max, int min, double mean, int mode)
		{
			var sut = new TemperatureTracker();
			temperatures.ToList().ForEach(n => sut.Insert(n));

			Assert.Equal(max, sut.GetMax());
			Assert.Equal(min, sut.GetMin());
			Assert.Equal(mean, sut.GetMean(), 2);
			Assert.Equal(mode, sut.GetMode());
		}

		public static IEnumerable<object[]> GetTestInsertData()
		{
			// [3]
			yield return new object[] {new []{3}, 3, 3, 3, 3};
			// [3, 3]
			yield return new object[] { new[] { 3, 3 }, 3, 3, 3, 3};
			// [3, 3, 1]
			yield return new object[] { new[] { 3, 3, 1 }, 3, 1, (double)7/3, 3};
			// [3, 3, 1, 2]
			yield return new object[] { new[] { 3, 3, 1, 2 }, 3, 1, (double)9/4, 3};
			// [3, 3, 1, 2, 1]
			yield return new object[] { new[] { 3, 3, 1, 2, 1 }, 3, 1, 2, 3};
		}
	}

	class TemperatureTracker
	{

		private int _max = int.MinValue;
		private int _min = int.MaxValue;

		// For keeping track of mean.
		private int _sum = 0;
		private int _count = 0;
		private double _mean = 0;

		// For keeping track of mode.
		private int _maxOccurrences = 0;
		private int _mode = 0;
		/// <summary>
		/// key = unique value, value = count of items
		/// </summary>
		private readonly Dictionary<int, int> _map = new Dictionary<int, int>();

		public void Insert(int temperature)
		{
			if (temperature > _max) _max = temperature;
			if (temperature < _min) _min = temperature;

			//_mean = (double)_map.Sum(p => p.Key * p.Value) / _map.Values.Sum();
			_sum += temperature;
			_count++;
			_mean = (double) _sum / _count;

			//int maxOccurrence = _map.Max(p => p.Value);
			//_mode = _map.First(p => p.Value == maxOccurrence).Key;
			if (!_map.ContainsKey(temperature))
				_map.Add(temperature, 0);
			_map[temperature]++;

			if (_map[temperature] > _maxOccurrences)
			{
				_maxOccurrences = _map[temperature];
				_mode = temperature;
			};
		}


		public int GetMax() => _max;
		public int GetMin() => _min;
		public double GetMean() => _mean;
		public int GetMode() => _mode;
	}
}
