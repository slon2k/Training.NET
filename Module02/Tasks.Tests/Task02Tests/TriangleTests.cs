// <copyright file="TriangleTests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Task02Tests
{
    using System;
    using NUnit.Framework;
    using Tasks.Task02;

    /// <summary>
    /// Tests for Rectangle.
    /// </summary>
    [TestFixture]
    public class TriangleTests
    {
        /// <summary>
        /// Checking argument range for Triangle.
        /// </summary>
        /// <param name="side1">Side 1.</param>
        /// <param name="side2">Side 2.</param>
        /// <param name="side3">Side 3.</param>
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 0)]
        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        public void CheckCreateTriangleArgumentOutOfRangeException(double side1, double side2, double side3)
        {
            Assert.That(() => new Triangle(side1, side2, side3), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        /// Checking arguments validation for Triangle.
        /// </summary>
        /// <param name="side1">Side 1.</param>
        /// <param name="side2">Side 2.</param>
        /// <param name="side3">Side 3.</param>
        [TestCase(2, 1, 1)]
        [TestCase(1, 2, 1)]
        [TestCase(1, 1, 2)]
        [TestCase(3, 1, 1)]
        [TestCase(1, 3, 1)]
        [TestCase(1, 1, 3)]
        public void CheckCreateTriangleArgumentException(double side1, double side2, double side3)
        {
            Assert.That(() => new Triangle(side1, side2, side3), Throws.TypeOf<ArgumentException>());
        }

        /// <summary>
        /// Checking calculating the perimeter of a triangle.
        /// </summary>
        /// <param name="side1">Side 1.</param>
        /// <param name="side2">Side 2.</param>
        /// <param name="side3">Side 3.</param>
        /// <returns>Perimeter.</returns>
        [TestCase(4, 5, 6, ExpectedResult = 15)]
        [TestCase(3, 4, 5, ExpectedResult = 12)]
        [TestCase(5, 12, 13, ExpectedResult = 30)]
        public double CheckCalculatingPerimeter(double side1, double side2, double side3)
        {
            var triangle = new Triangle(side1, side2, side3);
            return triangle.Perimeter();
        }

        /// <summary>
        /// Checking calculating the square of a triangle.
        /// </summary>
        /// <param name="side1">Side 1.</param>
        /// <param name="side2">Side 2.</param>
        /// <param name="side3">Side 3.</param>
        /// <returns>Perimeter.</returns>
        [TestCase(3, 4, 5, ExpectedResult = 6)]
        [TestCase(5, 12, 13, ExpectedResult = 30)]
        public double CheckCalculatingSquare(double side1, double side2, double side3)
        {
            var triangle = new Triangle(side1, side2, side3);
            return triangle.Square();
        }
    }
}
