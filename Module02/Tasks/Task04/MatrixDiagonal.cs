// <copyright file="MatrixDiagonal.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Task04
{
    using System;

    /// <summary>
    /// Diagonal matrix.
    /// </summary>
    /// <typeparam name="T">Type of values.</typeparam>
    public class MatrixDiagonal<T> : MatrixSymmetric<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixDiagonal{T}"/> class.
        /// </summary>
        /// <param name="size">Size.</param>
        public MatrixDiagonal(int size)
            : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixDiagonal{T}"/> class.
        /// </summary>
        /// <param name="array">Sourse array.</param>
        public MatrixDiagonal(T[,] array)
            : base(array)
        {
            if (!this.IsDiagonal(array))
            {
                throw new ArgumentException("Array is not diagonal");
            }
        }

        /// <summary>
        /// Sets values to diagonal cells.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="i">Index 1.</param>
        /// <param name="j">Index 2.</param>
        public new void SetValue(T value, int i, int j)
        {
            if (!this.IsInRange(i) || !this.IsInRange(j))
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            if (i != j)
            {
                throw new ArgumentException("Invalid arguments");
            }

            this.Values[i, i] = value;
        }

        private bool IsDiagonal(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (!array[i, j].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
