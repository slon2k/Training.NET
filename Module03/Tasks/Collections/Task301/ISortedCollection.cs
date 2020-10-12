// <copyright file="ISortedCollection.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Collections.Task301
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Sorted collection with binary search.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    public interface ISortedCollection<T>
    {
        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public T this[int index] { get; }

        /// <summary>
        /// Search for a specific element.
        /// </summary>
        /// <param name="element">Enement to find.</param>
        /// <returns>Index of specific element or -1.</returns>
        public int BinarySearch(T element);

        /// <summary>
        /// Adds an object to the end.
        /// </summary>
        /// <param name="item">The object to be added.</param>
        public void Add(T item);

        /// <summary>
        /// Removes the first occurrence of a specific element.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        /// <returns>True if item is successfully removed; otherwise, false.</returns>
        public bool Remove(T item);
    }
}
