// <copyright file="MinElementRowComparerTests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Task01Tests
{
    using NUnit.Framework;
    using Tasks.Task01;

    /// <summary>
    /// Tests for MaxElementRowComparer.
    /// </summary>
    [TestFixture]
    public class MinElementRowComparerTests
    {
        private static readonly int[,] Arr = new int[,]
        {
            { 10, 11, 12 },
            { 9, 10, 13 },
            { 8, 11, 20 },
        };

        private static readonly object[] ComparingByMinTestData =
        {
            new object[] { Arr, 0, 1, true },
            new object[] { Arr, 2, 1, false },
            new object[] { Arr, 0, 2, true },
        };

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
            var comparer = new MinElementRowComparer();
            Assert.That(comparer.CompareRows(array, row1, row2), Is.EqualTo(expected));
        }
    }
}
