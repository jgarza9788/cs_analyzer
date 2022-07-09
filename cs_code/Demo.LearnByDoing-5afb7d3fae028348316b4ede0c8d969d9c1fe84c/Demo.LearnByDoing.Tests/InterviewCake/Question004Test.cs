using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	public class Question004Test
	{
		//private static IEnumerable<TestCaseData> TestCases
		//{
		//	get
		//	{
		//		yield return new TestCaseData(new Meeting[]{ new Meeting(0, 1), new Meeting(3, 5), new Meeting(4, 8), new Meeting(10, 12), new Meeting(9, 10) })
		//			.Returns(new Meeting[] { new Meeting(0, 1), new Meeting(3, 8), new Meeting(9, 12) });
		//		yield return new TestCaseData(new Meeting[] { new Meeting(9, 10), new Meeting(0, 1), new Meeting(10, 12), new Meeting(4, 8), new Meeting(3, 5), new Meeting(11, 15) })
		//			.Returns(new Meeting[] { new Meeting(0, 1), new Meeting(3, 8), new Meeting(9, 12) });
		//		// edge cases
		//		yield return new TestCaseData(new Meeting[] { new Meeting(1, 2), new Meeting(2, 3) })
		//			.Returns(new Meeting[] { new Meeting(1, 3) });
		//		yield return new TestCaseData(new Meeting[] { new Meeting(1, 5), new Meeting(2, 3) })
		//			.Returns(new Meeting[] { new Meeting(1, 5) });
		//	}
		//}

		//[Test, TestCaseSource("TestCases")]
		//public Meeting[] Test(Meeting[] meetings) => MeetingMerger.MergeRanges(meetings);

		public static IEnumerable<object[]> TestCases()
		{
			yield return new object[]
			{
				new Meeting[] {new Meeting(0, 1), new Meeting(3, 5), new Meeting(4, 8), new Meeting(10, 12), new Meeting(9, 10)},
				new Meeting[] {new Meeting(0, 1), new Meeting(3, 8), new Meeting(9, 12)}
			};
			yield return new object[]
			{
				new Meeting[] { new Meeting(9, 10), new Meeting(0, 1), new Meeting(10, 12), new Meeting(4, 8), new Meeting(3, 5), new Meeting(11, 15) },
				new Meeting[] { new Meeting(0, 1), new Meeting(3, 8), new Meeting(9, 15) }
			};

			// edge cases
			yield return new object[]
			{
				new Meeting[] { new Meeting(1, 2), new Meeting(2, 3) },
				new Meeting[] { new Meeting(1, 3) }
			};
			yield return new object[]
			{
				new Meeting[] { new Meeting(1, 5), new Meeting(2, 3) },
				new Meeting[] { new Meeting(1, 5) }
			};
			yield return new object[]
			{
				new Meeting[] { new Meeting(1, 10), new Meeting(2, 6), new Meeting(3, 5), new Meeting(7, 9) },
				new Meeting[] { new Meeting(1, 10) }
			};
		}

		[Theory]
		[MemberData(nameof(TestCases))]
		public void TestAllCases(Meeting[] input, Meeting[] expected)
		{
			var sut = new MeetingMerger();
			var actual = sut.MergeRanges(input);

			Assert.True(expected.SequenceEqual(actual, new MeetingEqualityComparer()));
		}
	}

	public class MeetingEqualityComparer : IEqualityComparer<Meeting>
	{
		public bool Equals(Meeting x, Meeting y)
		{
			return x.StartTime == y.StartTime && x.EndTime == y.EndTime;
		}

		public int GetHashCode(Meeting obj)
		{
			return obj.GetHashCode();
		}
	}

	public class MeetingMerger
	{
		public Meeting[] MergeRanges(Meeting[] meetings)
		{
			// Order by Start Time (ST)
			var newMeetings = meetings.OrderBy(meeting => meeting.StartTime).ToList();

			// until the last Right Element (RE) is reached,
			// check two conditions
			// #1. Left elemnent's (LE) EndTime (ET) is between RE.ST and RE.ET
			// #2. LE.ST is between RE.ST and RE.ET
			// if either one of the conditions is true, then insert the new record to the meeting, and remove the LE, RE

			// "i < newMeetings.Count - 1" because we are dealing with RE
			for (int i = 0; i < newMeetings.Count - 1; i++)
			{
				var leftElement = newMeetings[i];
				var rightElement = newMeetings[i + 1];

				// Case #1 || Case #2
				bool leftElementEndTimeIsInRightElementRange = rightElement.StartTime <= leftElement.EndTime && leftElement.EndTime <= rightElement.EndTime;
				bool leftElementStartTimeIsInRightElementRange = leftElement.StartTime <= rightElement.StartTime && rightElement.StartTime <= leftElement.EndTime;
				if (leftElementEndTimeIsInRightElementRange || leftElementStartTimeIsInRightElementRange)
				{
					var newStartTime = Math.Min(leftElement.StartTime, rightElement.StartTime);
					var newEndTime = Math.Max(leftElement.EndTime, rightElement.EndTime);

					newMeetings.RemoveAt(i + 1);
					newMeetings.RemoveAt(i);

					newMeetings.Insert(i, new Meeting(newStartTime, newEndTime));

					i--;
				}
			}

			// return the result.
			return newMeetings.ToArray();
		}
	}

	public class Meeting
	{
		public int StartTime { get; }
		public int EndTime { get; }

		public Meeting(int startTime, int endTime)
		{
			// Number of 30 min blocks past 9:00 am
			StartTime = startTime;
			EndTime = endTime;
		}

		public override string ToString()
		{
			return $"({StartTime}, {EndTime})";
		}
	}
}
