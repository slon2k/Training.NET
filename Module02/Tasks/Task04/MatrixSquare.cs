// <copyright file="MatrixSquare.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Task04
{
    using System;

    /// <summary>
    /// Square matrix.
    /// </summary>
    /// <typeparam name="T">Type of values.</typeparam>
    public class MatrixSquare<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixSquare{T}"/> class.
        /// </summary>
        /// <param name="size">Size of the matrix.</param>
        public MatrixSquare(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            this.Size = size;
            this.Values = new T[size, size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixSquare{T}"/> class.
        /// </summary>
        /// <param name="array">Sourse array.</param>
        public MatrixSquare(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException("Array must be square");
            }

            this.Size = array.GetLength(0);
            this.Values = new T[this.Size, this.Size];
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
        public T[,] Values { get; }

        /// <summary>
        /// Gets Size.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Sets value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="i">Index 1.</param>
        /// <param name="j">Index 2.</param>
        public void SetValue(T value, int i, int j)
        {
            if (!this.IsInRange(i) || !this.IsInRange(j))
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            this.Values[i, j] = value;
        }

        private bool IsInRange(int number) => number >= 0 && number < this.Size;
    }
}
