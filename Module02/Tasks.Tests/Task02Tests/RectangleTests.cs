// <copyright file="RectangleTests.cs" company="Boris Korobeinikov">
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
    public class RectangleTests
    {
        /// <summary>
        /// Checking argument range for Rectangle.
        /// </summary>
        /// <param name="side1">Side 1.</param>
        /// <param name="side2">Side 2.</param>
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void CheckCreateCircleArgumentOutOfRangeException(double side1, double side2)
        {
            Assert.That(() => new Rectangle(side1, side2), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        /// Checking calculating the perimeter of a rectangle.
        /// </summary>
        /// <param name="side1">Side 1.</param>
        /// <param name="side2">Side 2.</param>
        /// <returns>Perimeter.</returns>
        [TestCase(1, 1, ExpectedResult = 4)]
        [TestCase(1, 5, ExpectedResult = 12)]
        [TestCase(10.5, 4.5, ExpectedResult = 30)]
        public double CheckCalculatingPerimeter(double side1, double side2)
        {
            var rectangle = new Rectangle(side1, side2);
            return rectangle.Perimeter();
        }

        /// <summary>
        /// Checking calculating the square of a rectangle.
        /// </summary>
        /// <param name="side1">Side 1.</param>
        /// <param name="side2">Side 2.</param>
        /// <returns>Square.</returns>
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(2, 5, ExpectedResult = 10)]
        [TestCase(10.5, 4.5, ExpectedResult = 47.25)]
        public double CheckCalculatingSquare(double side1, double side2)
        {
            var rectangle = new Rectangle(side1, side2);
            return rectangle.Square();
        }
    }
}
