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
        public void CheckIfFractionParsedFromString()
        {
            var fractionStr = "1/2";
            var fraction = new Fraction(fractionStr);
            Assert.Equal(1, fraction.Numerator);
            Assert.Equal(2, fraction.Denominator);
        }

        [Fact]
        public void CheckIfFractionReduce()
        {
            var fractionStr = "8/24";
            var fraction = new Fraction(fractionStr);
            Assert.Equal(1, fraction.Numerator);
            Assert.Equal(3, fraction.Denominator);
        }

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

        [Fact]
        public void CheckFractionExceptions()
        {
            Exception ex = Assert.Throws<FractionException>(() => "er/2".ToFraction());
            Assert.Equal("The Numerator value is not valid", ex.Message);

            ex = Assert.Throws<FractionException>(() => new Fraction(1, 0));
            Assert.Equal("Denominator cannot be assigned to 0 value", ex.Message);
        }

        [Fact]
        public void AddFractionsTest()
        {
            var expexted = "5/6";
            var f1 = new Fraction("1/2");
            var f2 = new Fraction("1/3");
            var actual = f1 + f2;
            Assert.Equal(expexted, actual.ToString());

            actual = f1 + new Fraction("2");
            Assert.Equal("5/2", actual.ToString());
        }

        [Fact]
        public void SubstractFractionsTest()
        {
            var expexted = "-1/6";
            var f1 = new Fraction("1/2");
            var f2 = new Fraction("1/3");
            var actual = f2 - f1;
            Assert.Equal(expexted, actual.ToString());
        }

        [Fact]
        public void MultiplyFractionsTest()
        {
            var expexted = "5/16";
            var f1 = new Fraction("3/6");
            var f2 = new Fraction("5/8");
            var actual = f2*f1;
            Assert.Equal(expexted, actual.ToString());
        }

        [Fact]
        public void DivisionFractionsTest()
        {
            var expexted = "5/4";
            var f1 = new Fraction("3/6");
            var f2 = new Fraction("5/8");
            var actual = f2 / f1;
            Assert.Equal(expexted, actual.ToString());
        }
    }
}
