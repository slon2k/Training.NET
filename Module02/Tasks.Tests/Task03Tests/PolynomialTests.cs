// <copyright file="PolynomialTests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Task03Tests
{
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
        [TestCase(new double[] { 3, 2, 1, 1 }, ExpectedResult = "3x^3 + 2x^2 + x + 1")]
        public string CheckPolynomialExpression(double[] coefficients)
        {
            var polynomial = new Polynomial(coefficients);
            return polynomial.Expression();
        }

        /// <summary>
        /// Checking addition of Polynomials.
        /// </summary>
        /// <param name="coefficients1">Polynomial 1.</param>
        /// <param name="coefficients2">Polynomial 2.</param>
        /// <returns>Sum of the Polynomials.</returns>
        [TestCase(new double[] { 1, 1, 1 }, new double[] { 1, 2 }, ExpectedResult = new double[] { 1, 2, 3 })]
        [TestCase(new double[] { 1, 1, 1 }, new double[] { -1, 0, 0 }, ExpectedResult = new double[] { 1, 1 })]
        [TestCase(new double[] { 1, 1, 1 }, new double[] { -1, -1, -1 }, ExpectedResult = new double[] { 0 })]
        public double[] CheckAdditionOfPolynomials(double[] coefficients1, double[] coefficients2)
        {
            var p1 = new Polynomial(coefficients1);
            var p2 = new Polynomial(coefficients2);
            var p3 = p1 + p2;
            return p3.GetCoefficients();
        }

        /// <summary>
        /// Checking - for Polynomials.
        /// </summary>
        /// <param name="coefficients">Polynomial.</param>
        /// <returns>The resulting polynomial.</returns>
        [TestCase(new double[] { 1, 2, 3 }, ExpectedResult = new double[] { -1, -2, -3 })]
        [TestCase(new double[] { 1, 0, -1 }, ExpectedResult = new double[] { -1, 0, 1 })]
        [TestCase(new double[] { 0 }, ExpectedResult = new double[] { 0 })]
        public double[] CheckMinusForPolynomials(double[] coefficients)
        {
            var p1 = new Polynomial(coefficients);
            var p2 = -p1;
            return p2.GetCoefficients();
        }

        /// <summary>
        /// Checking subtraction for Polynomials.
        /// </summary>
        /// <param name="coefficients1">Polynomial 1.</param>
        /// <param name="coefficients2">Polynomial 2.</param>
        /// <returns>The resulting polynomial.</returns>
        [TestCase(new double[] { 1, 1, 1 }, new double[] { 1, 2 }, ExpectedResult = new double[] { 1, 0, -1 })]
        [TestCase(new double[] { 1, 1, 1 }, new double[] { 1, 1, 0 }, ExpectedResult = new double[] { 1 })]
        [TestCase(new double[] { 1, 1, 1 }, new double[] { 1, 1, 1 }, ExpectedResult = new double[] { 0 })]
        public double[] CheckSubtractionForPolynomials(double[] coefficients1, double[] coefficients2)
        {
            var p1 = new Polynomial(coefficients1);
            var p2 = new Polynomial(coefficients2);
            var p3 = p1 - p2;
            return p3.GetCoefficients();
        }

        /// <summary>
        /// Checking multiplication by number.
        /// </summary>
        /// <param name="coefficients">Polynomial.</param>
        /// <param name="number">Number.</param>
        /// <returns>The resulting polynomial.</returns>
        [TestCase(new double[] { 1, -2, 1 }, 2, ExpectedResult = new double[] { 2, -4, 2 })]
        [TestCase(new double[] { 1, -2, 1 }, 0, ExpectedResult = new double[] { 0 })]
        public double[] CheckMultiplicationByNumber(double[] coefficients, double number)
        {
            var p1 = new Polynomial(coefficients);
            var p2 = p1 * number;
            return p2.GetCoefficients();
        }

        /// <summary>
        /// Checking miltiplication of Polynomials.
        /// </summary>
        /// <param name="coefficients1">Polynomial 1.</param>
        /// <param name="coefficients2">Polynomial 2.</param>
        /// <returns>The resulting polynomial.</returns>
        [TestCase(new double[] { 1, 1 }, new double[] { 1, -1 }, ExpectedResult = new double[] { 1, 0, -1 })]
        [TestCase(new double[] { 1, -1 }, new double[] { 1, -1 }, ExpectedResult = new double[] { 1, -2, 1 })]
        [TestCase(new double[] { 1, 2, 1 }, new double[] { 1, 1 }, ExpectedResult = new double[] { 1, 3, 3, 1 })]
        [TestCase(new double[] { 1, 2, 1 }, new double[] { 1, 2, 1 }, ExpectedResult = new double[] { 1, 4, 6, 4, 1 })]
        [TestCase(new double[] { 0 }, new double[] { 1, -1 }, ExpectedResult = new double[] { 0 })]
        [TestCase(new double[] { 0 }, new double[] { 0 }, ExpectedResult = new double[] { 0 })]
        public double[] CheckMultiplicationOfPolynomials(double[] coefficients1, double[] coefficients2)
        {
            var p1 = new Polynomial(coefficients1);
            var p2 = new Polynomial(coefficients2);
            var p3 = p1 * p2;
            return p3.GetCoefficients();
        }

        /// <summary>
        /// Checking addition a number to a Polynomial.
        /// </summary>
        /// <param name="coefficients">Polynomial.</param>
        /// <param name="number">Number.</param>
        /// <returns>The resulting polynomial.</returns>
        [TestCase(new double[] { 1, 1, 1 }, 5, ExpectedResult = new double[] { 1, 1, 6 })]
        [TestCase(new double[] { 1, 1, 1 }, -1, ExpectedResult = new double[] { 1, 1, 0 })]
        [TestCase(new double[] { 0 }, 0, ExpectedResult = new double[] { 0 })]
        public double[] CheckAdditionNumberToPolynomial(double[] coefficients, double number)
        {
            var p1 = new Polynomial(coefficients);
            Polynomial p2 = p1 + number;
            return p2.GetCoefficients();
        }
    }
}
