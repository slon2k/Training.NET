// <copyright file="Circle.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Task02
{
    using System;

    /// <summary>
    /// Circle.
    /// </summary>
    public class Circle : Shape
    {
        private const double Pi = Math.PI;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">Radius.</param>
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius));
            }

            this.Radius = radius;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">Radius.</param>
        public Circle(int radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius));
            }

            this.Radius = radius;
        }

        /// <summary>
        /// Gets radius of the circle.
        /// </summary>
        public double Radius { get; }

        /// <inheritdoc/>
        public override double Perimeter() => 2 * Pi * this.Radius;

        /// <inheritdoc/>
        public override double Square() => Pi * this.Radius * this.Radius;
    }
}
