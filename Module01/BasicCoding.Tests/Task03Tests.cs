// <copyright file="Task03Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace BasicCoding.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests for Task 3.
    /// </summary>
    [TestFixture]
    public class Task03Tests
    {
        /// <summary>
        /// Finds an element for which the sum of the elements on the left
        /// and the sum of the elements on the right are equal.
        /// </summary>
        /// <param name="a">Array of double.</param>
        /// <returns>Index of element or -1.</returns>
        [TestCase(new double[] { -3.0, -2.5, -1.5 }, ExpectedResult = -1)]
        [TestCase(new double[] { 1.0, 1.0, 5.5, 2.0 }, ExpectedResult = 2)]
        [TestCase(new double[] { 1.0, 1.0, 2.0, 1.0, 2.0, 5.0 }, ExpectedResult = 4)]
        [TestCase(new double[] { 1.0 }, ExpectedResult = 0)]
        [TestCase(new double[] { 1.0, 2.0 }, ExpectedResult = -1)]
        public int CheckFindIndex(double[] a)
        {
            return Task03.FindIndex(a);
        }
    }
}
