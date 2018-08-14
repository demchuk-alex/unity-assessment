using System;

namespace FractionCalulator.Structures
{
    public class Fraction
    {
        #region Fields

        private long _denominator;

        #endregion

        #region Constructors

        public Fraction(long numerator, long denomirator)
        {
            Numerator = numerator;
            Denominator = denomirator;
            this.Reduce();
        }

        public Fraction(string strFraction)
        {
            var temp = strFraction.ToFraction();
            Numerator = temp.Numerator;
            Denominator = temp.Denominator;
        }

        #endregion

        #region Properties

        public long Denominator
        {
            get => _denominator;
            set
            {
                if (value == 0)
                    throw new FractionException("Denominator cannot be assigned to 0 value");
                _denominator = value;
            }
        }

        public long Numerator { get; set; }

        #endregion

        public override string ToString()
        {
            var str = Denominator == 1
                ? Numerator.ToString()
                : $"{Numerator}/{Denominator}";
            return str;
        }

        private static Fraction Add(Fraction a, Fraction b)
        {
            try
            {
                checked
                {
                    var numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
                    var denominator = a.Denominator * b.Denominator;
                    return new Fraction(numerator, denominator);
                }
            }
            catch (OverflowException)
            {
                throw new FractionException("Overflow occurred while performing Add operation");
            }
            catch (Exception)
            {
                throw new FractionException("An error occurred while performing Add operation");
            }
        }

        private static Fraction Multiply(Fraction a, Fraction b)
        {
            try
            {
                checked
                {
                    var numerator = a.Numerator * b.Numerator;
                    var denominator = a.Denominator * b.Denominator;
                    return new Fraction(numerator, denominator);
                }
            }
            catch (OverflowException)
            {
                throw new FractionException("Overflow occurred while performing Multiply operation");
            }
            catch (Exception)
            {
                throw new FractionException("An error occurred while performing Multiply operation");
            }
        }

        public static Fraction operator -(Fraction a) => a.Negate();
        public static Fraction operator +(Fraction a, Fraction b) => Add(a, b);
        public static Fraction operator -(Fraction a, Fraction b) => Add(a, -b);
        public static Fraction operator *(Fraction a, Fraction b) => Multiply(a, b);
        public static Fraction operator /(Fraction a, Fraction b) => Multiply(a, b.Inverse());

    }
}
