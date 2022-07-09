using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/find-unique-int-among-duplicates
	/// 
	/// Your company delivers breakfast via autonomous quadcopter drones. And something mysterious has happened. 
	/// 
	///   Each breakfast delivery is assigned a unique ID, a positive integer. When one of the company's 100 drones takes off with a delivery, the delivery's ID is added to an array, deliveryIdConfirmations. When the drone comes back and lands, the ID is again added to the same array.
	/// 
	/// After breakfast this morning there were only 99 drones on the tarmac. One of the drones never made it back from a delivery. We suspect a secret agent from Amazon placed an order and stole one of our patented drones. To track them down, we need to find their delivery ID.
	/// 
	/// Given the array of IDs, which contains many duplicate integers and one unique integer, find the unique integer.
	/// 
	/// The IDs are not guaranteed to be sorted or sequential. Orders aren't always fulfilled in the order they were received, and some deliveries get cancelled before takeoff. 
	/// </summary>
	public class Question021Test
	{
		[Theory]
		[MemberData(nameof(GetSampleData))]
		public void TestSampleCases(int expected, int[] deliveryIdConfirmations)
		{
			int actual = FindUniqueInteger(deliveryIdConfirmations);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[MemberData(nameof(GetSampleData))]
		public void TestSampleCasesUsingLinq(int expected, int[] deliveryIdConfirmations)
		{
			int actual = FindUniqueIntegerUsingLinq(deliveryIdConfirmations);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[MemberData(nameof(GetSampleData))]
		public void TestSampleCasesUsingHashtable(int expected, int[] deliveryIdConfirmations)
		{
			int actual = FindUniqueIntegerUsingHashtable(deliveryIdConfirmations);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetSampleData()
		{
			yield return new object[] { 1, new[] { 1 } };
			yield return new object[] { 1, new[] { 22, 22, 3, 3, 1, 4, 4 } };
			yield return new object[] { 99, new[] { 99, 22, 22, 3, 3, 1, 1, 4, 4 } };
			yield return new object[] { 44, new[] { 22, 22, 3, 3, 1, 1, 4, 4, 44 } };
		}

		private int FindUniqueIntegerUsingHashtable(int[] deliveryIdConfirmations)
		{
			if (deliveryIdConfirmations == null || deliveryIdConfirmations.Length == 0)
				throw new ArgumentException("There should be at least 1 record", nameof(deliveryIdConfirmations));

			Dictionary<int, int> countMap = new Dictionary<int, int>();
			foreach (var id in deliveryIdConfirmations)
			{
				if (!countMap.ContainsKey(id))
					countMap.Add(id, 0);
				countMap[id]++;
			}

			foreach (KeyValuePair<int, int> pair in countMap)
			{
				if (pair.Value == 1)
					return pair.Key;
			}

			throw new ArgumentException("Could not find a unique ID!");
		}

		private int FindUniqueIntegerUsingLinq(int[] deliveryIdConfirmations)
		{
			if (deliveryIdConfirmations == null || deliveryIdConfirmations.Length == 0)
				throw new ArgumentException("There should be at least 1 record", nameof(deliveryIdConfirmations));

			return deliveryIdConfirmations
				.GroupBy(id => id)
				.ToDictionary(g => g.Key, g => g.Count())
				.Single(pair => pair.Value == 1).Key;
		}

		private int FindUniqueInteger(int[] deliveryIdConfirmations)
		{
			if (deliveryIdConfirmations == null || deliveryIdConfirmations.Length == 0)
				throw new ArgumentException("There should be at least 1 record", nameof(deliveryIdConfirmations));

			int uniqueValue = deliveryIdConfirmations[0];
			for (int i = 1; i < deliveryIdConfirmations.Length; i++)
			{
				uniqueValue ^= deliveryIdConfirmations[i];
			}

			return uniqueValue;
		}
	}
}
