using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using FractionCalulator.Structures;
using Xunit;

namespace UnitTests
{
    public class FractionTests
    {
        [Fact]
        public void CheckGfc()
        {
            var expected = 6;
            var actual = FractionHelper.Gfc(36, 42);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckLcm()
        {
            var expected = 252;
            var actual = FractionHelper.Lcm(36, 42);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckExpressionParser()
        {
            var exp = @"((?:[1-9][0-9]*|0)(?:\/[1-9][0-9]*)?)[\s+]?([+|-|\*|/])?";
            var input = "1/2 / 1/3";
            var match = Regex.Matches(input, exp);
            var f1 = match[0].Groups[1].Value;
            var operation = match[0].Groups[2].Value;
            var f2 = match[1].Groups[1].Value;
            Assert.Equal(@"1/2", f1);
            Assert.Equal(@"/", operation);
            Assert.Equal(@"1/3", f2);
        }
    }
}
