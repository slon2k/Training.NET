// <copyright file="Task02Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Methods.Tests
{
    using NUnit.Framework;
    using static Task02;

    /// <summary>
    /// Tests for Task 2.
    /// </summary>
    [TestFixture]
    public class Task02Tests
    {
        /// <summary>
        /// Checking Euclidean algorithm.
        /// </summary>
        /// <param name="args">Set of integers.</param>
        /// <returns>GCD.</returns>
        [TestCase(new int[] { 15, 20, 25 }, ExpectedResult = 5)]
        [TestCase(new int[] { 0, 20, 100 }, ExpectedResult = 20)]
        public int CheckEuclideanAlgorithm(int[] args)
        {
            return EuclideanAlgorithm(args);
        }

        /// <summary>
        /// Checking Stein algorithm.
        /// </summary>
        /// <param name="args">Set of integers.</param>
        /// <returns>GCD.</returns>
        [TestCase(new int[] { 15, 20, 25 }, ExpectedResult = 5)]
        [TestCase(new int[] { 0, 20, 100 }, ExpectedResult = 20)]
        public int CheckSteinAlgorithm(int[] args)
        {
            return SteinAlgorithm(args);
        }
    }
}
