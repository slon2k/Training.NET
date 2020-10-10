// <copyright file="Task01Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace CreatingTypes.Tests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Tests for Task 1.
    /// </summary>
    [TestFixture]
    public class Task01Tests
    {
        /// <summary>
        /// Checks finding the nth root of a real number.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <param name="degree">Root degree.</param>
        /// <param name="precision">Accuracy.</param>
        /// <param name="expected">Expected result.</param>
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.001, 0.3)]
        [TestCase(-0.008, 3, 0.001, -0.2)]
        [TestCase(-8, 3, 0.001, -2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void CheckFindingNthRoot(double number, int degree, double precision, double expected)
        {
            double result = Task01.FindNthRoot(number, degree, precision);

            Assert.That(Math.Abs(expected - result), Is.LessThan(precision));
        }

        /// <summary>
        /// Checking arguments.
        /// </summary>
        /// <param name="number">Must be positive in the case of an even degree.</param>
        /// <param name="degree">Must be natural number.</param>
        /// <param name="precision">Must be positive.</param>
        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.01, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        [TestCase(0.01, 2, 0)]
        public void CheckFindNthRootArgumentOutOfRange(double number, int degree, double precision)
        {
            Assert.That(() => Task01.FindNthRoot(number, degree, precision), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
