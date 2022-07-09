using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Xunit;

namespace Demo.LearnByDoing.Tests.LeetCode.Medium
{
	/// <summary>
	/// https://leetcode.com/problems/add-two-numbers/description/
	/// </summary>
	public class AddTwoNumbersTest
	{
		[Fact]
		public void TestSampleCase()
		{
			var sut = new Solution();

			var left = sut.BuildNode(342);
			var right = sut.BuildNode(465);

			var sumNode = sut.AddTwoNumbers(left, right);
			BigInteger expected = 807;
			Assert.Equal(expected, sut.GetNodeValue(sumNode));

			left = sut.BuildNode(5);
			right = sut.BuildNode(5);

			sumNode = sut.AddTwoNumbers(left, right);
			expected = 10;
			Assert.Equal(expected, sut.GetNodeValue(sumNode));

		}
	}

	public class Solution
	{
		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			Func<ListNode, int> getValue = n => n?.val ?? 0;
			Func<ListNode, ListNode, int> getSum = (n1, n2) => getValue(n1) + getValue(n2);
			Func<int, int> getDigit = n => n % 10;
			Func<int, int> getCarry = n => n >= 10 ? 1 : 0;

			var sum = getSum(l1, l2);
			ListNode node = new ListNode(getDigit(sum));
			ListNode head = node;
			int carryOver = getCarry(sum);
			l1 = l1?.next;
			l2 = l2?.next;

			while (l1 != null || l2 != null)
			{
				sum = getSum(l1, l2) + carryOver;
				node.next = new ListNode(getDigit(sum));
				carryOver = getCarry(sum);

				l1 = l1?.next;
				l2 = l2?.next;
				node = node.next;
			}

			if (carryOver == 1)
				node.next = new ListNode(carryOver);

			return head;
		}

		public ListNode AddTwoNumbers1(ListNode l1, ListNode l2)
		{
			var left = GetNodeValue(l1);
			var right = GetNodeValue(l2);
			var sum = left + right;

			return BuildNode(sum);
		}

		public BigInteger GetNodeValue(ListNode n)
		{
			var buffer = new StringBuilder();

			while (n != null)
			{
				buffer.Insert(0, n.val);
				n = n.next;
			}

			return BigInteger.Parse(buffer.ToString());
		}

		public ListNode BuildNode(BigInteger value)
		{
			var digits = GetDigitsReverse(value).ToList();
			var node = new ListNode(digits[0]);
			var head = node;
			digits.Skip(1).Aggregate(node, (acc, digit) =>
			{
				var newNode = new ListNode(digit);
				acc.next = newNode;
				return newNode;
			});

			return head;
		}

		private IEnumerable<int> GetDigitsReverse(BigInteger value)
		{
			return value.ToString().Reverse().Select(c => int.Parse(c.ToString()));
		}
	}

	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}
}
