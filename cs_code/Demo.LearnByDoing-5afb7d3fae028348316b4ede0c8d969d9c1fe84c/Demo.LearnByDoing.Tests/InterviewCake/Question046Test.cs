using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/mesh-message
	/// 
	///   You wrote a trendy new messaging app, MeshMessage, to get around flaky cell phone coverage.
	/// 
	/// Instead of routing texts through cell towers, your app sends messages via the phones of nearby users, passing each message along from one phone to the next until it reaches the intended recipient. (Don't worry—the messages are encrypted while they're in transit.)
	/// 
	/// Some friends have been using your service, and they're complaining that it takes a long time for messages to get delivered. After some preliminary debugging, you suspect messages might not be taking the most direct route from the sender to the recipient.
	/// 
	/// Given information about active users on the network, find the shortest route for a message from one user (the sender) to another (the recipient). Return an array of users that make up this route.
	/// 
	/// There might be a few shortest delivery routes, all with the same length. For now, let's just return any shortest route.
	/// 
	/// Your network information takes the form of a dictionary mapping username strings to an array of other users nearby:
	/// 
	/// var network = new Dictionary&lt;string, string[]&gt;
	/// {
	/// "Min",     new[] { "William", "Jayden", "Omar" }},
	/// "William", new[] { "Min", "Noam" }},
	/// "Jayden",  new[] { "Min", "Amelia", "Ren", "Noam" }},
	/// "Ren",     new[] { "Jayden", "Omar" }},
	/// "Amelia",  new[] { "Jayden", "Adam", "Miguel" }},
	/// "Adam",    new[] { "Amelia", "Miguel", "Sofia", "Lucas" }},
	/// "Miguel",  new[] { "Amelia", "Adam", "Liam", "Nathan" }},
	/// "Noam",    new[] { "Nathan", "Jayden", "William" }},
	/// "Omar",    new[] { "Ren", "Min", "Scott" }},
	/// ...
	/// };
	/// 
	/// For the network above, a message from Jayden to Adam should have this route:
	/// 
	/// { "Jayden", "Amelia", "Adam" }
	/// </summary>
	public class Question046Test
	{
		private readonly Dictionary<string, string[]> _network = new Dictionary<string, string[]>
		{
			{"Min", new[] {"William", "Jayden", "Omar"}},
			{"William", new[] {"Min", "Noam"}},
			{"Jayden", new[] {"Min", "Amelia", "Ren", "Noam"}},
			{"Ren", new[] {"Jayden", "Omar"}},
			{"Amelia", new[] {"Jayden", "Adam", "Miguel"}},
			{"Adam", new[] {"Amelia", "Miguel", "Sofia", "Lucas"}},
			{"Miguel", new[] {"Amelia", "Adam", "Liam", "Nathan"}},
			{"Noam", new[] {"Nathan", "Jayden", "William"}},
			{"Omar", new[] {"Ren", "Min", "Scott"}}
		};

		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCases(string[] expected, string userFrom, string userTo)
		{
			string[] actual = GetShortedRouteBetween(_network, userFrom, userTo);
			Assert.True(expected.SequenceEqual(actual));
		}

		/// <summary>
		/// Refer to https://youtu.be/SmnUqWmWvz0
		/// </summary>
		private string[] GetShortedRouteBetween(Dictionary<string, string[]> network, string userFrom, string userTo)
		{
			if (userFrom == userTo) return new[]{userFrom};

			var emptyResult = new string[0];
			if (string.IsNullOrWhiteSpace(userFrom) || string.IsNullOrWhiteSpace(userTo)) return emptyResult;
			if (network == null) return emptyResult;

			var q = new Queue<string>();
			q.Enqueue(userFrom);
			var parents = new Dictionary<string, string>();
			parents.Add(userFrom, null);

			while (q.Count > 0)
			{
				string currentUser = q.Dequeue();
				// We found the match!
				if (currentUser == userTo) break;
				if (!network.ContainsKey(currentUser)) continue;

				foreach (string neighboringUser in network[currentUser])
				{
					if (!parents.ContainsKey(neighboringUser))
					{
						q.Enqueue(neighboringUser);
						parents.Add(neighboringUser, currentUser);
					}
				}
			}

			if (!parents.ContainsKey(userTo) || parents[userTo] == null) return emptyResult;

			var output = new Stack<string>();
			var user = userTo;
			while (user != null)
			{
				output.Push(user);
				user = parents[user];
			}

			return output.ToArray();
		}

		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[] { new[] { "William", "Min", "Jayden", "Amelia", "Adam", "Lucas" }, "William", "Lucas" };
			yield return new object[] { new[] { "Jayden", "Amelia", "Adam" }, "Jayden", "Adam" };
			yield return new object[] { new[] { "Omar", "Ren", "Jayden" }, "Omar", "Jayden" };
			yield return new object[] { new string[] { }, "Lucas", "Sofia" };
			yield return new object[] { new string[] { }, "Liam", "Nathan" };
			yield return new object[] { new string[] { }, "Nathan", "Liam" };
			yield return new object[] { new[] { "Nathan" }, "Nathan", "Nathan" };
		}
	}
}
