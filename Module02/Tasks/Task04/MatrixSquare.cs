// <copyright file="MatrixSquare.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Task04
{
    using System;

    /// <summary>
    /// Square matrix.
    /// </summary>
    public class MatrixSquare
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixSquare"/> class.
        /// </summary>
        /// <param name="size">Size of the matrix.</param>
        public MatrixSquare(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            this.Size = size;
            this.Values = new double[size, size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixSquare"/> class.
        /// </summary>
        /// <param name="array">Sourse array.</param>
        public MatrixSquare(double[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException("Array must be square");
            }

            this.Size = array.GetLength(0);
            this.Values = new double[this.Size, this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    this.Values[i, j] = array[i, j];
                }
            }
        }

        /// <summary>
        /// Gets values.
        /// </summary>
        public double[,] Values { get; }

        /// <summary>
        /// Gets Size.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Addition operator.
        /// </summary>
        /// <param name="m1">Matrix 1.</param>
        /// <param name="m2">Matrix 2.</param>
        /// <returns>Sum of matrices.</returns>
        public static MatrixSquare operator +(MatrixSquare m1, MatrixSquare m2)
        {
            if (m1.Size != m2.Size)
            {
                throw new ArgumentException("Invalid size.");
            }

            int size = m1.Size;

            var array = new double[size, size];
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    array[i, j] = m1.Values[i, j] + m2.Values[i, j];
                }
            }

            return new MatrixSquare(array);
        }

        /// <summary>
        /// Sets value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="i">Index 1.</param>
        /// <param name="j">Index 2.</param>
        public void SetValue(double value, int i, int j)
        {
            if (!this.IsInRange(i) || !this.IsInRange(j))
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            this.Values[i, j] = value;
        }

        /// <summary>
        /// Checks if the number is valid.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <returns>True if the number is valid.</returns>
        protected bool IsInRange(int number) => number >= 0 && number < this.Size;
    }
}
