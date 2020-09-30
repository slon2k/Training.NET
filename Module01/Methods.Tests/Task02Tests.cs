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
        [TestCase(new long[] { 15, 20, 25 }, ExpectedResult = 5)]
        [TestCase(new long[] { 0, 20, 100 }, ExpectedResult = 20)]
        public long CheckEuclideanAlgorithm(long[] args)
        {
            return EuclideanAlgorithm(args);
        }

        /// <summary>
        /// Checking Stein algorithm.
        /// </summary>
        /// <param name="args">Set of integers.</param>
        /// <returns>GCD.</returns>
        [TestCase(new long[] { 15, 20, 25 }, ExpectedResult = 5)]
        [TestCase(new long[] { 0, 20, 100 }, ExpectedResult = 20)]
        public long CheckSteinAlgorithm(long[] args)
        {
            return SteinAlgorithm(args);
        }
    }
}
