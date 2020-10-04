// <copyright file="Task01.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Methods
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 1.
    /// Extend the functionality of the System.Double type by implementing the ability to get the string representation of a real number in the IEEE 754 format.
    /// </summary>
    public static class Task01
    {
        private const string MinValue = "1111111111101111111111111111111111111111111111111111111111111111";
        private const string MaxValue = "0111111111101111111111111111111111111111111111111111111111111111";
        private const string Epsilon = "0000000000000000000000000000000000000000000000000000000000000001";
        private const string NaN = "1111111111111000000000000000000000000000000000000000000000000000";
        private const string NegativeInfinity = "1111111111110000000000000000000000000000000000000000000000000000";
        private const string PositiveInfinity = "0111111111110000000000000000000000000000000000000000000000000000";
        private const string PositiveZero = "0000000000000000000000000000000000000000000000000000000000000000";
        private const string NegativeZero = "1000000000000000000000000000000000000000000000000000000000000000";
        private const int BaseExponent = 1023;
        private const int BitsExponent = 11;
        private const int BitsMantissa = 52;

        /// <summary>
        /// String representation of a number in the IEEE 754 format.
        /// </summary>
        /// <param name="number">Floating point number.</param>
        /// <returns>String in the IEEE 754 format.</returns>
        public static string ToIEEE754(this double number)
        {
            return number switch
            {
                double.MinValue => MinValue,
                double.MaxValue => MaxValue,
                double.Epsilon => Epsilon,
                double.NaN => NaN,
                double.NegativeInfinity => NegativeInfinity,
                double.PositiveInfinity => PositiveInfinity,
                0.0d => PositiveZero,
                _ => ConvertToIEEE(number)
            };
        }

        private static string ConvertToIEEE(double number)
        {
            char sign = number >= 0 ? '0' : '1';
            number = Math.Abs(number);
            string exponent = number >= 1 ? ExpPlus(number) : ExpMinus(number);
            string mantissa = Mantissa(number);
            return $"{sign}{exponent}{mantissa}";
        }

        private static string Mantissa(double number)
        {
            number = Normalize(number);

            number -= 1;

            var digits = new List<string>();

            while (digits.Count < BitsMantissa)
            {
                number *= 2;
                int digit = (int)number;
                digits.Add($"{digit}");
                number -= digit;
            }

            return string.Join(string.Empty, digits);
        }

        private static double Normalize(double number)
        {
            while (number >= 2)
            {
                number /= 2;
            }

            while (number < 1)
            {
                number *= 2;
            }

            return number;
        }

        private static string ExpPlus(double number)
        {
            if (number < 1)
            {
                throw new ArgumentOutOfRangeException("Number is out of range.");
            }

            long integerPart = (long)number;
            int exp = -1;

            while (integerPart >= 1)
            {
                integerPart >>= 1;
                exp++;
            }

            return ConvertToBinaryString(BaseExponent + exp, BitsExponent);
        }

        private static string ConvertToBinaryString(int number, int bits)
        {
            var digits = new List<string>();

            while (digits.Count < bits)
            {
                digits.Add($"{number % 2}");
                number /= 2;
            }

            digits.Reverse();

            return string.Join(string.Empty, digits);
        }

        private static string ExpMinus(double number)
        {
            if (number >= 1)
            {
                throw new ArgumentOutOfRangeException("Number is out of range.");
            }

            int exp = 0;

            while (number < 1)
            {
                number *= 2;
                exp--;
            }

            return ConvertToBinaryString(BaseExponent + exp, BitsExponent);
        }
    }
}
