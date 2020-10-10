// <copyright file="SumOfElementsRowComparer.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Task01
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Compares rows by maximum element in a row.
    /// </summary>
    public class SumOfElementsRowComparer : IRowComparer
    {
        /// <summary>
        /// Compares rows of integer array by sum of elements.
        /// </summary>
        /// <param name="array">Sourse array.</param>
        /// <param name="first">Index of the first row.</param>
        /// <param name="second">Index of the second row.</param>
        /// <returns>True if the sum of the second row is greater.</returns>
        public bool CompareRows(int[,] array, int first, int second) => SumOfElementsInRow(array, first) >= SumOfElementsInRow(array, second);

        private static int SumOfElementsInRow(int[,] array, int row)
        {
            int length = array.GetLength(1);

            if (length == 0)
            {
                throw new ArgumentOutOfRangeException("Row is empty");
            }

            int sum = 0;

            for (int i = 0; i < length; i++)
            {
                sum += array[row, i];
            }

            return sum;
        }
    }
}
