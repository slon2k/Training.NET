// <copyright file="MatrixSymmetric.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Task04
{
    using System;

    /// <summary>
    /// Symmetric matrix.
    /// </summary>
    public class MatrixSymmetric : MatrixSquare
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixSymmetric"/> class.
        /// </summary>
        /// <param name="size">Size.</param>
        public MatrixSymmetric(int size)
            : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixSymmetric"/> class.
        /// </summary>
        /// <param name="array">Sourse array.</param>
        public MatrixSymmetric(double[,] array)
            : base(array)
        {
            if (!this.IsSymmetric(array))
            {
                throw new ArgumentException("Array is not symmetric");
            }
        }

        /// <summary>
        /// Sets values to symmetric cells.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="i">Index 1.</param>
        /// <param name="j">Index 2.</param>
        public new void SetValue(double value, int i, int j)
        {
            if (!this.IsInRange(i) || !this.IsInRange(j))
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            this.Values[i, j] = value;
            this.Values[j, i] = value;
        }

        private bool IsSymmetric(double[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (!array[i, j].Equals(array[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
