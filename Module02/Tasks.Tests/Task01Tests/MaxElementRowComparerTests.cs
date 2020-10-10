// <copyright file="MaxElementRowComparerTests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Task01Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;
    using Tasks.Task01;

    /// <summary>
    /// Tests for MaxElementRowComparer.
    /// </summary>
    [TestFixture]
    public class MaxElementRowComparerTests
    {
        private static readonly int[,] Arr = new int[,]
        {
            { 10, 11, 12 },
            { 9, 10, 13 },
            { 8, 11, 20 },
        };

        private static readonly object[] ComparingByMaxTestData =
        {
            new object[] { Arr, 0, 1, false },
            new object[] { Arr, 2, 1, true },
            new object[] { Arr, 0, 2, false },
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
            var comparer = new MaxElementRowComparer();
            Assert.That(comparer.CompareRows(array, row1, row2), Is.EqualTo(expected));
        }
    }
}
