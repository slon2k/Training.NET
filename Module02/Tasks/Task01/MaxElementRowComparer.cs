// <copyright file="MaxElementRowComparer.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Task01
{
    using System;

    /// <summary>
    /// Compares rows by maximum element in a row.
    /// </summary>
    public class MaxElementRowComparer : IRowComparer
    {
        /// <summary>
        /// Compares rows of integer array by maximum element.
        /// </summary>
        /// <param name="array">Sourse array.</param>
        /// <param name="first">Index of the first row.</param>
        /// <param name="second">Index of the second row.</param>
        /// <returns>True if the second row is greater.</returns>
        public bool CompareRows(int[,] array, int first, int second) => MaxElementInRow(array, first) >= MaxElementInRow(array, second);

        private static int MaxElementInRow(int[,] a, int row)
        {
            int length = a.GetLength(1);

            if (length == 0)
            {
                throw new ArgumentOutOfRangeException("Row is empty");
            }

            int maxValue = a[row, 0];

            for (int i = 0; i < length; i++)
            {
                if (a[row, i] > maxValue)
                {
                    maxValue = a[row, i];
                }
            }

            return maxValue;
        }
    }
}
