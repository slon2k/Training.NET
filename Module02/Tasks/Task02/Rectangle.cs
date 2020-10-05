// <copyright file="Rectangle.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Task02
{
    using System;

    /// <summary>
    /// Rectangle.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="side1">Side 1.</param>
        /// <param name="side2">Side 2.</param>
        public Rectangle(double side1, double side2)
        {
            if (side1 <= 0 || side2 <= 0)
            {
                throw new ArgumentOutOfRangeException("Side of a rectangle must be positive.");
            }

            this.Side1 = side1;
            this.Side2 = side2;
        }

        /// <summary>
        /// Gets side 1.
        /// </summary>
        public double Side1 { get; }

        /// <summary>
        /// Gets side 2.
        /// </summary>
        public double Side2 { get; }

        /// <inheritdoc/>
        public override double Perimeter() => (this.Side1 + this.Side2) * 2;

        /// <inheritdoc/>
        public override double Square() => this.Side1 * this.Side2;
    }
}
