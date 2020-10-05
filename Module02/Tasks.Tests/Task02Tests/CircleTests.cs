// <copyright file="CircleTests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Task02Tests
{
    using System;
    using NUnit.Framework;
    using Tasks.Task02;

    /// <summary>
    /// Tests for Circle.
    /// </summary>
    [TestFixture]
    public class CircleTests
    {
        private const double Pi = Math.PI;

        /// <summary>
        /// Checking argument range for Circle.
        /// </summary>
        /// <param name="radius">Radius.</param>
        [TestCase(0)]
        [TestCase(-1)]
        public void CheckCreateCircleArgumentOutOfRangeException(double radius)
        {
            Assert.That(() => new Circle(radius), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        /// Checking calculating the perimeter of a circle.
        /// </summary>
        /// <param name="radius">Radius.</param>
        /// <returns>Perimeter.</returns>
        [TestCase(1, ExpectedResult = 2 * Pi)]
        [TestCase(2, ExpectedResult = 4 * Pi)]
        public double CheckCalculatingPerimeter(double radius)
        {
            var circle = new Circle(radius);
            return circle.Perimeter();
        }

        /// <summary>
        /// Checking calculating the square of a circle.
        /// </summary>
        /// <param name="radius">Radius.</param>
        /// <returns>Square.</returns>
        [TestCase(1, ExpectedResult = Pi)]
        [TestCase(2, ExpectedResult = 4 * Pi)]
        public double CheckCalculatingSquare(double radius)
        {
            var circle = new Circle(radius);
            return circle.Square();
        }
    }
}
