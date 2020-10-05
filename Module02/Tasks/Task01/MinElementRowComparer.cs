// <copyright file="MinElementRowComparer.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Task01
{
    using System;

    /// <summary>
    /// Compares rows by maximum element in a row.
    /// </summary>
    public class MinElementRowComparer : IRowComparer
    {
        /// <summary>
        /// Compares rows of integer array by minimum element.
        /// </summary>
        /// <param name="array">Sourse array.</param>
        /// <param name="first">Index of the first row.</param>
        /// <param name="second">Index of the second row.</param>
        /// <returns>True if the second row is greater.</returns>
        public bool CompareRows(int[,] array, int first, int second) => MinElementInRow(array, first) >= MinElementInRow(array, second);

        private static int MinElementInRow(int[,] array, int row)
        {
            int length = array.GetLength(1);

            if (length == 0)
            {
                throw new ArgumentOutOfRangeException("Row is empty");
            }

            int minValue = array[row, 0];

            for (int i = 0; i < length; i++)
            {
                if (array[row, i] < minValue)
                {
                    minValue = array[row, i];
                }
            }

            return minValue;
        }
    }
}
