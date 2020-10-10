// <copyright file="Task106.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Framework
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Write a function that returns the sum of two big numbers. The input numbers are strings and the function must return a string.
    /// </summary>
    public static class Task106
    {
        private static readonly Regex NumericCharacters = new Regex("^[0-9]+$");

        /// <summary>
        /// Addition of big numbers in string format.
        /// </summary>
        /// <param name="number1">First number.</param>
        /// <param name="number2">Second number.</param>
        /// <returns>Sum.</returns>
        public static string AddBigNumbers(string number1, string number2)
        {
            if (!IsNumber(number1) || !IsNumber(number2))
            {
                throw new ArgumentException("Numbers are not valid");
            }

            int length = Math.Max(number1.Length, number2.Length);

            int[] number = new int[length + 1];

            var n1 = number1.Reverse().ToList();
            var n2 = number2.Reverse().ToList();

            for (int i = 0; i < length; i++)
            {
                int digit1 = i < n1.Count() ? Digit(n1[i]) : 0;
                int digit2 = i < n2.Count() ? Digit(n2[i]) : 0;
                int sum = digit1 + digit2;
                number[i] += sum % 10;
                number[i + 1] += sum / 10;
            }

            return ConvertToString(number);
        }

        private static string ConvertToString(int[] array)
        {
            var number = array.ToList();
            number.Reverse();

            var index = number.FindIndex(x => x != 0);
            if (index == -1)
            {
                return "0";
            }

            var str = new StringBuilder();

            for (int i = index; i < number.Count(); i++)
            {
                str.Append($"{number[i]}");
            }

            return str.ToString();
        }

        private static bool IsNumber(string number) => NumericCharacters.IsMatch(number);

        private static int Digit(char c)
        {
            int.TryParse(c.ToString(), out int result);
            return result;
        }
    }
}
