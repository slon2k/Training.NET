// <copyright file="MatrixSquareTests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Task04Tests
{
    using System;
    using NUnit.Framework;
    using Tasks.Task04;

    /// <summary>
    /// Tests for MatrixSquare.
    /// </summary>
    [TestFixture]
    public class MatrixSquareTests
    {
        private static readonly int[,] Array1 = new int[,]
        {
            { 3, 3, 3 },
            { 2, 2, 2 },
            { 1, 1, 1 },
        };

        private static readonly int[,] Array2 = new int[,]
        {
            { 0, 1, 2 },
            { 1, 2, 3 },
            { 2, 3, 1 },
        };

        private static readonly int[,] Array3 = new int[,]
        {
            { 1, 0, 0 },
            { 0, 2, 0 },
            { 0, 0, 3 },
        };

        private static readonly int[,] Array4 = new int[,]
        {
            { 1, 0 },
            { 0, 2 },
            { 0, 0 },
        };

        private static readonly object[] TestDataCreating =
        {
            new object[] { Array1 },
            new object[] { Array2 },
            new object[] { Array3 },
        };

        private static readonly object[] TestDataArgumentExcepton =
        {
            new object[] { Array4 },
        };

        /// <summary>
        /// Testing creating square matrix.
        /// </summary>
        /// <param name="array">Initial array.</param>
        [TestCaseSource("TestDataCreating")]
        public void CheckCreatingMatrix(int[,] array)
        {
            var matrix = new MatrixSquare<int>(array);
            Assert.That(matrix.Values, Is.EqualTo(array));
        }

        /// <summary>
        /// Tests argument exception.
        /// </summary>
        /// <param name="array">Initial array.</param>
        [TestCaseSource("TestDataArgumentExcepton")]
        public void CheckCreatingMatrixArgumentExcepton(int[,] array)
        {
            Assert.That(() => new MatrixSquare<int>(array), Throws.TypeOf<ArgumentException>());
        }

        /// <summary>
        /// Tests ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="size">Size.</param>
        [TestCase(0)]
        [TestCase(-1)]
        public void CheckCreatingMatrixArgumentExcepton(int size)
        {
            Assert.That(() => new MatrixSquare<int>(size), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
