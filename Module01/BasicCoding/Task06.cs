// <copyright file="Task06.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace BasicCoding
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Task 6.
    /// Implement a method that takes an array of integers and filters it so that only numbers containing the given digit remain.
    /// </summary>
    public static class Task06
    {
        /// <summary>
        /// Filters numbers containing given digit.
        /// </summary>
        /// <param name="a">Array.</param>
        /// <param name="digit">Digit.</param>
        /// <returns>Filtered array.</returns>
        public static int[] FilterDigit(int[] a, int digit)
        {
            if (!IsDigit(digit))
            {
                throw new ArgumentOutOfRangeException("digit is not in range");
            }

            return a;
        }

        private static bool IsDigit(int digit) => digit >= 0 && digit <= 9;
    }
}
