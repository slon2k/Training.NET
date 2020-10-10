// <copyright file="Task02Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace CreatingTypes.Tests
{
    using System;
    using NUnit.Framework;
    using static CreatingTypes.Task02;

    /// <summary>
    /// Tests for Task 2.
    /// </summary>
    [TestFixture]
    public class Task02Tests
    {
        private static readonly int[,] Arr1 = new int[,]
        {
            { 10, 11, 12 },
            { 9, 10, 13 },
            { 8, 11, 20 },
        };

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

        private static readonly object[] ComparingByMaxTestData =
        {
            new object[] { Arr1, 0, 1, false },
            new object[] { Arr1, 2, 1, true },
            new object[] { Arr1, 0, 2, false },
        };

        private static readonly object[] ComparingByMinTestData =
        {
            new object[] { Arr1, 0, 1, true },
            new object[] { Arr1, 2, 1, false },
            new object[] { Arr1, 1, 2, true },
        };

        private static readonly object[] ComparingBySumTestData =
        {
            new object[] { Arr1, 0, 1, true },
            new object[] { Arr1, 2, 1, true },
            new object[] { Arr1, 0, 2, false },
        };

        private static readonly object[] SortingTestData =
        {
            new object[] { ArrayUnordered, true, ArrayAscending },
            new object[] { ArrayUnordered, false, ArrayDescending },
        };

        /// <summary>
        /// Checking comparing by max element in a row.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="row1">First row index.</param>
        /// <param name="row2">Second row index.</param>
        /// <param name="expected">Expected result.</param>
        [TestCaseSource("ComparingByMaxTestData")]
        public void CheckComparingByMaxElement(int[,] array, int row1, int row2, bool expected)
        {
            Assert.That(CompareByMaxElement(array, row1, row2), Is.EqualTo(expected));
        }

        /// <summary>
        /// Checking comparing by min element in a row.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="row1">First row index.</param>
        /// <param name="row2">Second row index.</param>
        /// <param name="expected">Expected result.</param>
        [TestCaseSource("ComparingByMinTestData")]
        public void CheckComparingByMinElement(int[,] array, int row1, int row2, bool expected)
        {
            Assert.That(CompareByMinElement(array, row1, row2), Is.EqualTo(expected));
        }

        /// <summary>
        /// Checking comparing by sum of elements in a row.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="row1">First row index.</param>
        /// <param name="row2">Second row index.</param>
        /// <param name="expected">Expected result.</param>
        [TestCaseSource("ComparingBySumTestData")]
        public void CheckComparingBySumOfRow(int[,] array, int row1, int row2, bool expected)
        {
            Assert.That(CompareBySumOfRow(array, row1, row2), Is.EqualTo(expected));
        }

        /// <summary>
        /// Check sorting.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <param name="ascending">Sorting order.</param>
        /// <param name="expected">Expected result.</param>
        [TestCaseSource("SortingTestData")]
        public void CheckSorting(int[,] array, bool ascending, int[,] expected)
        {
            SortRows(array, CompareByMaxElement, ascending);
            Assert.That(array, Is.EqualTo(expected));
            SortRows(array, CompareByMaxElement, !ascending);
            SortRows(array, CompareByMinElement, ascending);
            Assert.That(array, Is.EqualTo(expected));
            SortRows(array, CompareByMinElement, !ascending);
            SortRows(array, CompareBySumOfRow, ascending);
            Assert.That(array, Is.EqualTo(expected));
        }
    }
}
