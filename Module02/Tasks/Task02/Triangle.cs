// <copyright file="Triangle.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Task02
{
    using System;

    /// <summary>
    /// Triangle.
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="side1">Side 1.</param>
        /// <param name="side2">Side 2.</param>
        /// <param name="side3">Side 3.</param>
        public Triangle(double side1, double side2, double side3)
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                throw new ArgumentOutOfRangeException("Side of a triangle must be positive.");
            }

            if (side1 + side2 - side3 <= 0 || side1 - side2 + side3 <= 0 || -side1 + side2 + side3 <= 0)
            {
                throw new ArgumentException("Invalid sides of a triangle.");
            }

            this.Side1 = side1;
            this.Side2 = side2;
            this.Side3 = side3;
        }

        /// <summary>
        /// Gets side 1.
        /// </summary>
        public double Side1 { get; }

        /// <summary>
        /// Gets side 2.
        /// </summary>
        public double Side2 { get; }

        /// <summary>
        /// Gets side 3.
        /// </summary>
        public double Side3 { get; }

        /// <inheritdoc/>
        public override double Perimeter() => this.Side1 + this.Side2 + this.Side3;

        /// <inheritdoc/>
        public override double Square()
        {
            double a = this.Side1 + this.Side2 + this.Side3;
            double b = -this.Side1 + this.Side2 + this.Side3;
            double c = this.Side1 - this.Side2 + this.Side3;
            double d = this.Side1 + this.Side2 - this.Side3;

            return Math.Sqrt(a * b * c * d) / 4;
        }
    }
}
