using System;
using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/paginationhelper/train/csharp
	/// </summary>
	public class PaginationHelperTest : BaseTest
	{
		private readonly IList<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };

		private readonly PagnationHelper<int> _sutInt;
		private readonly PagnationHelper<char> _sutChar;

		public PaginationHelperTest(ITestOutputHelper output) : base(output)
		{
			_sutInt = new PagnationHelper<int>(intList, 10);
		}

		[Theory]
		[InlineData(-1, -1)]
		[InlineData(0, 10)]
		[InlineData(1, 10)]
		[InlineData(2, 4)]
		[InlineData(3, -1)]
		public void PageItemCountTest(int itemIndex, int expected)
		{
			int actual = _sutInt.PageItemCount(itemIndex);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(-1, -1)]
		[InlineData(0, 0)]
		[InlineData(1, 0)]
		[InlineData(2, 0)]
		[InlineData(9, 0)]
		[InlineData(10, 1)]
		[InlineData(11, 1)]
		[InlineData(12, 1)]
		[InlineData(13, 1)]
		[InlineData(19, 1)]
		[InlineData(20, 2)]
		[InlineData(21, 2)]
		[InlineData(22, 2)]
		[InlineData(23, 2)]
		[InlineData(24, -1)]
		public void PageIndexTest(int itemIndex, int expected)
		{
			int actual = _sutInt.PageIndex(itemIndex);
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ItemCountTest()
		{
			Assert.Equal(24, _sutInt.ItemCount);
		}

		[Fact]
		public void PageCountTest()
		{
			Assert.Equal(3, _sutInt.PageCount);
		}
	}

	public class PagnationHelper<T>
	{
		public IList<T> Collection { get; }

		public int ItemsPerPage { get; }

		/// <summary>
		/// Constructor, takes in a list of items and the number of items that fit within a single page
		/// </summary>
		/// <param name="collection">A list of items</param>
		/// <param name="itemsPerPage">The number of items that fit within a single page</param>
		public PagnationHelper(IList<T> collection, int itemsPerPage)
		{
			Collection = collection;
			ItemsPerPage = itemsPerPage;
		}

		/// <summary>
		/// The number of items within the collection
		/// </summary>
		public int ItemCount
		{
			get { return Collection.Count; }
		}

		/// <summary>
		/// The number of pages
		/// </summary>
		public int PageCount
		{
			get { return (int)Math.Ceiling(ItemCount / (double)ItemsPerPage); }
		}

		/// <summary>
		/// Returns the number of items in the page at the given page index 
		/// </summary>
		/// <param name="pageIndex">The zero-based page index to get the number of items for</param>
		/// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
		public int PageItemCount(int pageIndex)
		{
			if (pageIndex < 0) return -1;
			if (pageIndex > PageCount - 1) return -1;

			var totalUpto = ItemsPerPage * (pageIndex + 1);
			return totalUpto < ItemCount ? ItemsPerPage : ItemCount - (ItemsPerPage * pageIndex);
		}

		/// <summary>
		/// Returns the page index of the page containing the item at the given item index.
		/// </summary>
		/// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
		/// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
		public int PageIndex(int itemIndex)
		{
			if (itemIndex < 0) return -1;
			if (itemIndex >= ItemCount) return -1;

			return (int) Math.Floor((double) (itemIndex / ItemsPerPage));
		}
	}
}
