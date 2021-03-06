﻿// <copyright file="MatrixDiagonalTests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Task04Tests
{
    using System;
    using NUnit.Framework;
    using Tasks.Task04;

    /// <summary>
    /// Tests for MatrixDiagonal.
    /// </summary>
    [TestFixture]
    public class MatrixDiagonalTests
    {
        private static readonly double[,] Array1 = new double[,]
        {
            { 3, 3, 3 },
            { 2, 2, 2 },
            { 1, 1, 1 },
        };

        private static readonly double[,] Array2 = new double[,]
        {
            { 0, 1, 2 },
            { 1, 2, 3 },
            { 2, 3, 1 },
        };

        private static readonly double[,] Array3 = new double[,]
        {
            { 1, 0, 0 },
            { 0, 2, 0 },
            { 0, 0, 3 },
        };

        private static readonly double[,] Array4 = new double[,]
        {
            { 1, 0 },
            { 0, 2 },
            { 0, 0 },
        };

        private static readonly double[,] Array5 = new double[,]
        {
            { 1, 0, 0 },
            { 0, 10, 0 },
            { 0, 0, 3 },
        };

        private static readonly object[] TestDataCreating =
        {
            new object[] { Array3 },
        };

        private static readonly object[] TestDataArgumentExcepton =
        {
            new object[] { Array4 },
            new object[] { Array1 },
            new object[] { Array2 },
        };

        private static readonly object[] TestDataSetValue =
        {
            new object[] { Array3, Array5 },
        };

        /// <summary>
        /// Testing creating square matrix.
        /// </summary>
        /// <param name="array">Initial array.</param>
        [TestCaseSource("TestDataCreating")]
        public void CheckCreatingMatrix(double[,] array)
        {
            var matrix = new MatrixDiagonal(array);
            Assert.That(matrix.Values, Is.EqualTo(array));
        }

        /// <summary>
        /// Tests argument exception.
        /// </summary>
        /// <param name="array">Initial array.</param>
        [TestCaseSource("TestDataArgumentExcepton")]
        public void CheckCreatingMatrixArgumentExcepton(double[,] array)
        {
            Assert.That(() => new MatrixDiagonal(array), Throws.TypeOf<ArgumentException>());
        }

        /// <summary>
        /// Tests updating matrix.
        /// </summary>
        /// <param name="array">Initial array.</param>
        /// <param name="expected">Expected result.</param>
        [TestCaseSource("TestDataSetValue")]
        public void CheckUpdatingMatrix(double[,] array, double[,] expected)
        {
            var matrix = new MatrixDiagonal(array);
            matrix.SetValue(10, 1, 1);
            Assert.That(matrix.Values, Is.EqualTo(expected));
        }
    }
}
