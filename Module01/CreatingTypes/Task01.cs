// <copyright file="Task01.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace CreatingTypes
{
    using System;

    /// <summary>
    /// Task 1.
    /// Implement an algorithm that allows calculating the nth root of a real number using Newton's method with a given accuracy.
    /// </summary>
    public static class Task01
    {
        /// <summary>
        /// Finds the nth root of a real number.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <param name="degree">Root degree.</param>
        /// <param name="precision">Accuracy.</param>
        /// <returns>Root of the number.</returns>
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if (degree <= 0 || precision <= 0 || (degree % 2 == 0 && number < 0))
            {
                throw new ArgumentOutOfRangeException("Invalid arguments");
            }

            double x = number;
            double prev = number + precision + 1;

            while (Math.Abs(prev - x) >= precision)
            {
                prev = x;
                x = (((degree - 1) * x) + (number / x.Power(degree - 1))) / degree;
            }

            return x;
        }

        private static double Power(this double number, int degree)
        {
            double result = number;

            if (degree < 1)
            {
                throw new ArgumentOutOfRangeException("degree must be natural.");
            }

            for (int i = 1; i < degree; i++)
            {
                result *= number;
            }

            return result;
        }
    }
}
