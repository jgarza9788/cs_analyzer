using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    /// <summary>
    /// Binary to String:
    /// Given a real number between 0 and 1 (e.g., 0.72) that is passed in as a double,
    /// print the binary representation.
    /// If the number cannot be represented accurantely in binary with at most 32 characters,
    /// print "ERROR".
    /// 
    /// Hints: #143, #167, #173, #269, #297
    /// 
    /// NOTE: Didn't solve it. This is the answer from the book.
    /// </summary>
    public class Chapter5_2Test : BaseTest
    {
        private readonly Chapter5_2 _sut = new Chapter5_2();

        public Chapter5_2Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestGettingStringRepresentationOfBinaryDecimal()
        {
            double num = 0.72;
            string actual = _sut.GetBinaryString(num);

            const string expected = ".101110000101000111101011100001";
            Assert.Equal(expected, actual);
        }
    }

    public class Chapter5_2
    {
        public string GetBinaryString(double num)
        {
            const string ERROR_STRING = "ERROR";
            if (num >= 1 || num <= 0) return ERROR_STRING;

            StringBuilder binary = new StringBuilder();
            binary.Append(".");

            while (num > 0)
            {
                // setting a limit on length: 32 characters
                if (binary.Length >= 31) return binary.ToString();

                double r = num*2;
                if (r >= 1)
                {
                    binary.Append(1);
                    num = r - 1;
                }
                else
                {
                    binary.Append(0);
                    num = r;
                }
            }

            return binary.ToString();
        }
    }
}
