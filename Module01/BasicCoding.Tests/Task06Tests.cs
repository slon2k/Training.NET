// <copyright file="Task06Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace BasicCoding.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Tests for Task 6.
    /// </summary>
    [TestFixture]
    public class Task06Tests
    {
        /// <summary>
        /// Filters numbers containing given digit.
        /// </summary>
        /// <param name="sourceArray">Array.</param>
        /// <param name="digit">Digit.</param>
        /// <returns>Filtered array.</returns>
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, -69, 70, 15, 17 }, 6, ExpectedResult = new int[] { 6, 68, -69 })]
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, -88, 70, 15, 17 }, 9, ExpectedResult = new int[] { })]
        public int[] CheckDigitFiltering(int[] sourceArray, int digit)
        {
            return Task06.FilterDigit(sourceArray, digit);
        }

        /// <summary>
        /// Checking range of given digit.
        /// </summary>
        /// <param name="sourceArray">Array.</param>
        /// <param name="digit">Digit.</param>
        [TestCase(new int[] { 7, 1 }, -1)]
        [TestCase(new int[] { 0, 1 }, 11)]
        public void CheckDigitFilteringArgumentOutOfRangeException(int[] sourceArray, int digit)
        {
            Assert.That(() => Task06.FilterDigit(sourceArray, digit), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
