using System;

namespace FractionCalulator.Structures
{
    public static class FractionHelper
    {
        #region Methods

        public static long Gfc(long a, long b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static long Lcm(long a, long b)
        {
            return b * (a / Gfc(a, b));
        }

        public static void Reduce(this Fraction fraction)
        {
            try
            {
                if (fraction.Numerator == 0)
                {
                    fraction.Denominator = 1;
                    return;
                }

                var gfc = Gfc(fraction.Numerator, fraction.Denominator);
                fraction.Numerator /= gfc;
                fraction.Denominator /= gfc;
            }
            catch (Exception e)
            {
                throw new Exception($"The Fraction cannot be reduced {e}");
            }
        }

        public static Fraction ToFraction(this string str)
        {
            var fractionSegments = str.Split(new[] {"/"}, StringSplitOptions.None);
            var numeratorStr = fractionSegments.Length > 1 ? fractionSegments[0] : str;
            var denominatorStr = fractionSegments.Length > 1 ? fractionSegments[1] : "1"; ;
          
            if (!long.TryParse(numeratorStr, out var numerator))
            {
                throw new Exception("The Numerator value is not valid");
            }
            if (!long.TryParse(denominatorStr, out var denominator))
            {
                throw new Exception("The Denominator value is not valid");
            }

            return new Fraction(numerator, denominator);
        }

        public static Fraction Inverse(this Fraction frac)
        {
            if (frac.Numerator == 0)
                throw new Exception("Operation not possible (Denominator cannot be assigned to 0 value)");

            var numerator = frac.Denominator;
            var denominator = frac.Numerator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction Negate(this Fraction frac)
        {
            var iNumerator = -frac.Numerator;
            var iDenominator = frac.Denominator;
            return new Fraction(iNumerator, iDenominator);
        }

        #endregion
    }
}
