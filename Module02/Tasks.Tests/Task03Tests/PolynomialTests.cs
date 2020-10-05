// <copyright file="PolynomialTests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Task03Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;
    using Tasks.Task03;

    /// <summary>
    /// Tests for Polynomial.
    /// </summary>
    [TestFixture]
    public class PolynomialTests
    {
        /// <summary>
        /// Checking string expression.
        /// </summary>
        /// <param name="coefficients">Coefficients.</param>
        /// <returns>Expression.</returns>
        [TestCase(new double[] { 1, 2, 1 }, ExpectedResult = "x^2 + 2x + 1")]
        [TestCase(new double[] { 1, -2, 1 }, ExpectedResult = "x^2 - 2x + 1")]
        [TestCase(new double[] { 1, 0, 1 }, ExpectedResult = "x^2 + 1")]
        [TestCase(new double[] { 1, 0, 0 }, ExpectedResult = "x^2")]
        [TestCase(new double[] { 3, 2, 1, 1 }, ExpectedResult = "3x^3 + 2x^2 + 2x + 1")]
        public string CheckPolynomialExpression(double[] coefficients)
        {
            var polynomial = new Polynomial(coefficients);
            return polynomial.Expression();
        }
    }
}
