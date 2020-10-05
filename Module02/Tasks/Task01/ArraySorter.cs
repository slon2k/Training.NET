// <copyright file="ArraySorter.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Refactor the sorting algorithm from Module 1 (don't use delegates and standard interfaces), allowing to sorting both in ascending and descending directions,
    /// depending on comparison criterion of the matrix rows.
    /// </summary>
    public static class ArraySorter
    {
        /// <summary>
        /// Sorts rows of given array.
        /// </summary>
        /// <param name="array">Sourse array.</param>
        /// <param name="comparer">Row comparer.</param>
        /// <param name="ascending">Sorting order. Ascending by default.</param>
        public static void SortRows(int[,] array, IRowComparer comparer, bool ascending = true)
        {
            int length = array.GetLength(0);
            if (length == 0)
            {
                throw new ArgumentOutOfRangeException("Array is empty");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (comparer.CompareRows(array, j, j + 1) == ascending)
                    {
                        array.SwapRows(j, j + 1);
                    }
                }
            }
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
