using System;
using Demo.LearnByDoing.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2TestBase : BaseTest
    {
        protected Chapter2TestBase(ITestOutputHelper output) : base(output)
        {
        }

        protected bool AreNodesEqual<T>(Node<T> expected, Node<T> actual)
        {
            if (expected == null || actual == null) return false;

            while (expected != null)
            {
                //if (expected.Data != actual.Data) return false;
                if (!expected.Data.Equals(actual.Data)) return false;

                expected = expected.Next;
                actual = actual.Next;

                if ((expected != null && actual == null) || (expected == null && actual != null)) return false;
            }

            return true;
        }
    }
}