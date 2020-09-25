// <copyright file="Task02.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace BasicCoding
{
    using System;

    /// <summary>
    /// Task 2.
    /// Implement a recursive algorithm for finding the maximum element in an unsorted integer array.
    /// </summary>
    public static class Task02
    {
        /// <summary>
        /// Finds maximum element in array.
        /// </summary>
        /// <param name="a">Array of integers.</param>
        /// <returns>Maximum element.</returns>
        public static int FindMax(int[] a)
        {
            return FindMax(a, a.Length - 1);
        }

        private static int FindMax(int[] a, int index)
        {
            if (index >= a.Length || index < 0)
            {
                throw new ArgumentOutOfRangeException("index is out of range");
            }

            if (index == 0)
            {
                return a[0];
            }

            return Math.Max(FindMax(a, index - 1), a[index]);
        }
    }
}
