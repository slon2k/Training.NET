// <copyright file="GenericSet.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Collections.Task306
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Task 6.
    /// Develop a generic class-collection Set that implements the basic operations for working with the structure data set with the reference types elements.
    /// Implement the capability to iterate by collection by block iterator yield.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class GenericSet<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets the number of elements that are contained in a set.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Adds the specified element to a set.
        /// </summary>
        /// <param name="item">The element to add to the set.</param>
        /// <returns>True if the element is added. False if the element already presents.</returns>
        public bool Add(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all elements.
        /// </summary>
        public void Clear() => throw new NotImplementedException();

        /// <summary>
        /// Determines whether the Set contains the specified element.
        /// </summary>
        /// <param name="item">The element to locate.</param>
        /// <returns>True if the Set contains the specified element.</returns>
        public bool Contains(T item) => throw new NotImplementedException();

        /// <summary>
        /// Removes the specified element.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        /// <returns>True if the element is successfully found and removed; otherwise, false.</returns>
        public bool Remove(T item) => throw new NotImplementedException();

        /// <summary>
        /// Copies the elements to a new array.
        /// </summary>
        /// <returns>A new array containing elements of the set.</returns>
        public T[] ToArray() => throw new NotImplementedException();

        /// <summary>
        /// Returns an enumerator that iterates through the set.
        /// </summary>
        /// <returns>An enumerator for the queue.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
