// <copyright file="ArraySorterTests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Task01Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;
    using static ArraySorter;

    /// <summary>
    /// Tests for array sorter.
    /// </summary>
    [TestFixture]
    public class ArraySorterTests
    {
        private static readonly int[,] ArrayUnordered = new int[,]
        {
            { 3, 3, 3 },
            { 2, 2, 2 },
            { 1, 1, 1 },
            { 4, 4, 4 },
            { 5, 5, 5 },
        };

        private static readonly int[,] ArrayAscending = new int[,]
        {
            { 1, 1, 1 },
            { 2, 2, 2 },
            { 3, 3, 3 },
            { 4, 4, 4 },
            { 5, 5, 5 },
        };

        private static readonly int[,] ArrayDescending = new int[,]
        {
            { 5, 5, 5 },
            { 4, 4, 4 },
            { 3, 3, 3 },
            { 2, 2, 2 },
            { 1, 1, 1 },
        };

        private static readonly object[] SortingTestData =
        {
            new object[] { ArrayUnordered, true, ArrayAscending },
            new object[] { ArrayUnordered, false, ArrayDescending },
        };

        /// <summary>
        /// Check sorting.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <param name="ascending">Sorting order.</param>
        /// <param name="expected">Expected result.</param>
        [TestCaseSource("SortingTestData")]
        public void CheckSorting(int[,] array, bool ascending, int[,] expected)
        {
            SortRows(array, new MockComparer(), ascending);
            Assert.That(this.ArraysAreEqual(array, expected));
        }

        private bool ArraysAreEqual(int[,] a1, int[,] a2)
        {
            if (a1.GetLength(0) != a2.GetLength(0) || a1.GetLength(0) != a2.GetLength(0))
            {
                throw new ArgumentException("Dimensions of the arrays are not the same");
            }

            for (int i = 0; i < a1.GetLength(0); i++)
            {
                for (int j = 0; j < a2.GetLength(1); j++)
                {
                    if (a1[i, j] != a2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Mock comparer. Compares rows by the first element.
        private class MockComparer : IRowComparer
        {
            public bool CompareRows(int[,] array, int first, int second) => array[first, 0] >= array[second, 0];
        }
    }
}
