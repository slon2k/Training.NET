// <copyright file="Shape.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Task02
{
    /// <summary>
    /// Basic class for Geometric Shapes.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Perimeter of the shape.
        /// </summary>
        /// <returns>Perimeter.</returns>
        public abstract double Perimeter();

        /// <summary>
        /// Square of the shape.
        /// </summary>
        /// <returns>Square.</returns>
        public abstract double Square();
    }
}
