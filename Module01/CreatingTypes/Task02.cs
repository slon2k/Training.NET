// <copyright file="Task02.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace CreatingTypes
{
    using System;

    /// <summary>
    /// Task 2.
    /// Implement a "bubble" sorting method for an integer array in such a way that it would be possible to order the rows of the matrix.
    /// </summary>
    public static class Task02
    {
        /// <summary>
        /// Sorts rows of two-dimentional array of integers.
        /// </summary>
        /// <param name="a">Sourse array.</param>
        /// <param name="compare">Comparer for rows. Bool function accepting array and indexes of rows to compare.</param>
        /// <param name="ascending">Sorting order. Ascending by default.</param>
        public static void SortRows(int[,] a, Func<int[,], int, int, bool> compare, bool ascending = true)
        {
            int length = a.GetLength(0);
            if (length == 0)
            {
                throw new ArgumentOutOfRangeException("Array is empty");
            }

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (compare(a, j, j + 1) == ascending)
                    {
                        a.SwapRows(j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Compares rows of two dimentional array by minimum value.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="row1">First row index.</param>
        /// <param name="row2">Second row index.</param>
        /// <returns>True if maximum element of the first array is bigger.</returns>
        public static bool CompareByMaxElement(int[,] array, int row1, int row2) => array.MaxElementInRow(row1) >= array.MaxElementInRow(row2);

        /// <summary>
        /// Compares rows of two dimentional array by minimum value.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="row1">First row index.</param>
        /// <param name="row2">Second row index.</param>
        /// <returns>True if minimum element of the first row is bigger.</returns>
        public static bool CompareByMinElement(int[,] array, int row1, int row2) => array.MinElementInRow(row1) >= array.MinElementInRow(row2);

        /// <summary>
        /// Compares rows of two dimentional array by sum of the elements.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="row1">First row index.</param>
        /// <param name="row2">Second row index.</param>
        /// <returns>True if sum of elements of the first row is bigger.</returns>
        public static bool CompareBySumOfRow(int[,] array, int row1, int row2) => array.SumOfRow(row1) >= array.SumOfRow(row2);

        private static int MaxElementInRow(this int[,] a, int row)
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

        private static int MinElementInRow(this int[,] a, int row)
        {
            int length = a.GetLength(1);

            if (length == 0)
            {
                throw new ArgumentOutOfRangeException("Row is empty");
            }

            int minValue = a[row, 0];

            for (int i = 0; i < length; i++)
            {
                if (a[row, i] < minValue)
                {
                    minValue = a[row, i];
                }
            }

            return minValue;
        }

        private static int SumOfRow(this int[,] a, int row)
        {
            int length = a.GetLength(1);

            if (length == 0)
            {
                throw new ArgumentOutOfRangeException("Row is empty");
            }

            int sum = 0;

            for (int i = 0; i < length; i++)
            {
                sum += a[row, i];
            }

            return sum;
        }

        private static void SwapRows(this int[,] a, int index1, int index2)
        {
            int length = a.GetLength(1);
            for (int i = 0; i < length; i++)
            {
                int temp = a[index1, i];
                a[index1, i] = a[index2, i];
                a[index2, i] = temp;
            }
        }
    }
}
