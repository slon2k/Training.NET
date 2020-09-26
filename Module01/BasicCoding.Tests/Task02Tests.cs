// <copyright file="Task02Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace BasicCoding.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests for Task 2.
    /// </summary>
    [TestFixture]
    public class Task02Tests
    {
        /// <summary>
        /// Finding maximum element in the array.
        /// </summary>
        /// <param name="a">Array of integers.</param>
        /// <returns>Maximum element.</returns>
        [TestCase(new int[] { 1, 2, 4, 6, 4, 0 }, ExpectedResult = 6)]
        [TestCase(new int[] { 3, 2, 1 }, ExpectedResult = 3)]
        [TestCase(new int[] { -3, -2, -1 }, ExpectedResult = -1)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 0, -1, 11, 21, 1, 2, 8, 65, 34, 21, 765, -12, 566, 7878, -199, 0, 34, 65, 87, 12, 34 }, ExpectedResult = 7878)]
        public int CheckFindMax(int[] a)
        {
            return Task02.FindMax(a);
        }
    }
}
