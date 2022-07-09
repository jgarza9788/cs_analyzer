using System;
using System.Collections;
using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// One Away:
    /// There are three types of edits that can be performed on strings:
    /// insert a character,
    /// remove a character,
    /// or replace a character.
    ///  Given two strings, write a function to check if they are onde edit (or zero edits) away.
    /// 
    /// EXAMPLE
    /// pale,   ple     -> true
    /// pales,  pale    -> true
    /// pale,   bale    -> true
    /// pales,  bake    -> false
    /// </summary>
    /// <remarks>
    /// If the number of differences in text is more than one, then it's NOT "one edit away".
    /// </remarks>
    public class Chapter1_5Test : BaseTest
    {
        private readonly Chapter1_5 _sut = new Chapter1_5();

        public Chapter1_5Test(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Test the number of differences between two texts.
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <param name="expected"></param>
        [Theory]
        [ClassData(typeof(Chapter1_5Data))]
        public void TestCharacterDifferenceCount(string text1, string text2, bool expected)
        {
            bool actual = _sut.IsOneEditAway(text1, text2);

            Assert.Equal(expected, actual);
        }
    }

    public class Chapter1_5Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]{"pale", "ple", true},
            new object[]{"abcd", "abc", true},
            new object[]{"abd", "abcd", true},
            new object[]{"ple", "pale", true},
            new object[]{"pale", "plee", false},
            new object[]{"plee", "pale", false},
            new object[]{"pales", "pale", true},
            new object[]{"pale", "pales", true},
            new object[]{"spale", "pale", true},
            new object[]{"pale", "bale", true},
            new object[]{"bale", "pale", true},
            new object[]{"pale", "palee", true},
            new object[]{"palee", "pale", true},
            new object[]{"pale", "baleee", false},
            new object[] { "baleee", "pale", false},
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
