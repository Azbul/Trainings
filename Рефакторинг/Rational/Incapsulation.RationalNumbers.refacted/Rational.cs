using System;

namespace Incapsulation.RationalNumbers
{
    public class Rational
    {
        public Rational(int numerator)
        {
            Numerator = numerator;
            Denominator = 1;
        }

        public Rational(int numerator, int denominator)
        {
            Check(ref numerator, ref denominator);
            Numerator = numerator;
            Denominator = denominator;
        }

        public bool IsNan => Denominator == 0; 

        public int Numerator { get; }

        public int Denominator { get; }

        private void Check(ref int num, ref int den)
        {
            if (den == 0) return;
            if (num == 0)
            {
                den = 1;
                return;
            }
            if (den < 0)
            {
                num = num * (-1);
                den = den * (-1);
            }

            CheckToDiv(ref num, ref den);
        }

        private void CheckToDiv(ref int num, ref int den)
        {
            int numRem, denRem;

            for (int i = 9; i > 1; i--)
            {
                numRem = Math.Abs(num) % i;
                denRem = Math.Abs(den) % i;
                if (numRem == 0 && denRem == 0)
                {
                    num = num / i;
                    den = den / i;
                    CheckToDiv(ref num, ref den);
                    return;
                }
            }
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            var newSumVls = new NewSumSubValues(r1, r2);
            return new Rational(newSumVls.FirstRNum + newSumVls.SecondRNum, newSumVls.GenDen);
        }

        public static Rational operator -(Rational r1, Rational r2)
        {
            var newSubVls = new NewSumSubValues(r1, r2);
            return new Rational(newSubVls.FirstRNum - newSubVls.SecondRNum, newSubVls.GenDen);
        }
        
        public static Rational operator  *(Rational r1, Rational r2)
        {
            return new Rational(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
        }

        public static Rational operator /(Rational r1, Rational r2)
        {
            return new Rational(r1.Numerator * r2.Denominator, 
                                r2.IsNan ? 0 : r1.Denominator * r2.Numerator);
        }

        public static implicit operator double(Rational r)
        {
            return r.IsNan ? double.NaN : (double)r.Numerator / r.Denominator;
        }

        public static implicit operator Rational(int n)
        {
            return new Rational(n);
        }

        public static explicit operator int(Rational r)
        {
            if (r.Numerator % r.Denominator != 0)
                throw new InvalidCastException();

            return r.Numerator / r.Denominator;
        }

        struct NewSumSubValues
        {
            public NewSumSubValues(Rational r1, Rational r2)
            {
                FirstRNum = r1.Numerator * r2.Denominator;
                SecondRNum = r2.Numerator * r1.Denominator;
                GenDen = r1.Denominator * r2.Denominator;
            }
            public int FirstRNum { get; }

            public int SecondRNum { get; }

            public int GenDen { get; }
        }
    }
}
