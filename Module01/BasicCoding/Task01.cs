// <copyright file="Task01.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace BasicCoding
{
    using System;

    /// <summary>
    /// Task 1.
    /// Implement the InsertNumber algorithm for inserting bits from the j-th to the i-th of one number into another.
    /// </summary>
    public static class Task01
    {
        /// <summary>
        /// Inserts j-th to i-th bits from one integer to another.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <param name="i">The last bit.</param>
        /// <param name="j">The first bit.</param>
        /// <returns>The modified number.</returns>
        public static int InsertNumber(int a, int b, int i, int j)
        {
            if (!IsInRangeIndex(i) || !IsInRangeIndex(j))
            {
                throw new ArgumentOutOfRangeException("Indexes i and j must be in range 0..32");
            }

            if (i > j)
            {
                throw new ArgumentException("i must not be greater than j");
            }

            var mask = GetMask(i, j);
            var inversedMask = ~mask;

            return (a & inversedMask) | (b << i & mask);
        }

        private static bool IsInRangeIndex(int i) => i >= 0 && i <= 32;

        // returns mask like 00000000 00000111 11110000 00000000.
        private static int GetMask(int lastBit, int firstBit)
        {
            int mask = 0;
            int size = firstBit - lastBit + 1;

            for (int i = 0; i < size; i++)
            {
                mask *= 2;
                mask += 1;
            }

            mask <<= lastBit;
            return mask;
        }
    }
}
