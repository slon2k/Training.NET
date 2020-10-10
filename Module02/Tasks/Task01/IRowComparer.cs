// <copyright file="IRowComparer.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks
{
    /// <summary>
    /// Row comparer.
    /// </summary>
    public interface IRowComparer
    {
        /// <summary>
        /// Compares rows of integer array.
        /// </summary>
        /// <param name="array">Sourse array.</param>
        /// <param name="first">Index of the first row.</param>
        /// <param name="second">Index of the second row.</param>
        /// <returns>True if the second row is greater.</returns>
        public bool CompareRows(int[,] array, int first, int second);
    }
}