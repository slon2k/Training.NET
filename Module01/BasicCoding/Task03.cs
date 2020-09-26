// <copyright file="Task03.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace BasicCoding
{
    using System;

    /// <summary>
    /// Task 3.
    /// Implement the search algorithm in a real array for an element index for which the sum of the elements on the left
    /// and the sum of the elements on the right are equal.
    /// </summary>
    public static class Task03
    {
        private const double Epsilon = 1E-10;

        /// <summary>
        /// Finds an element for which the sum of the elements on the left
        /// and the sum of the elements on the right are equal.
        /// </summary>
        /// <param name="a">Array of double.</param>
        /// <returns>Index of element or -1.</returns>
        public static int FindIndex(double[] a)
        {
            double sumTotal = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sumTotal += a[i];
            }

            double sumLeft = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sumLeft += a[i];
                double sumRight = sumTotal - sumLeft + a[i];
                if (AreEqual(sumLeft, sumRight))
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool AreEqual(double a, double b) => Math.Abs(a - b) < Epsilon;
    }
}
