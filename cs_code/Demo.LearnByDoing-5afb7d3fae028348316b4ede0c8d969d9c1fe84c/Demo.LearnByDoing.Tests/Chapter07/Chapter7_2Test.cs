using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter07
{
    public class Chapter7_2Test : BaseTest
    {
        private readonly Chapter7_2 _sut = new Chapter7_2();

        public Chapter7_2Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestHandlingTheCalls()
        {
        }
    }

    public class Chapter7_2
    {
    }
}
