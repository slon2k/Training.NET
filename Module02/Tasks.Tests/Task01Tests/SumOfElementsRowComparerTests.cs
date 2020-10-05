// <copyright file="SumOfElementsRowComparerTests.cs" company="Boris Korobeinikov">
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
    public class SumOfElementsRowComparerTests
    {
        private static readonly int[,] Arr = new int[,]
{
            { 1, 1, 1 },
            { 5, 5, 5 },
            { 3, 3, 3 },
};

        private static readonly object[] ComparingBySumTestData =
        {
            new object[] { Arr, 0, 1, false },
            new object[] { Arr, 1, 2, true },
            new object[] { Arr, 0, 2, false },
        };

        /// <summary>
        /// Checking comparing by the sum of elements in a row.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="row1">First row index.</param>
        /// <param name="row2">Second row index.</param>
        /// <param name="expected">Expected result.</param>
        [TestCaseSource("ComparingBySumTestData")]
        public void CheckComparingBySumElement(int[,] array, int row1, int row2, bool expected)
        {
            var comparer = new SumOfElementsRowComparer();
            Assert.That(comparer.CompareRows(array, row1, row2), Is.EqualTo(expected));
        }
    }
}
