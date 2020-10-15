// <copyright file="GenericSet.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Collections.Task306
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Task 6.
    /// Develop a generic class-collection Set that implements the basic operations for working with the structure data set with the reference types elements.
    /// Implement the capability to iterate by collection by block iterator yield.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the set.</typeparam>
    public class GenericSet<T> : IEnumerable<T>
    {
        private const int TableSize = 1000;
        private SinglyLinkedList<T>[] buckets = new SinglyLinkedList<T>[TableSize];

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericSet{T}"/> class.
        /// </summary>
        public GenericSet()
        {
            this.Count = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericSet{T}"/> class.
        /// </summary>
        /// <param name="array">The array whose elements are added to the new set.</param>
        public GenericSet(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this.Add(array[i]);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericSet{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are added to the new set.</param>
        public GenericSet(ICollection<T> collection)
        {
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Gets the number of elements that are contained in a set.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Adds the specified element to a set.
        /// </summary>
        /// <param name="item">The element to add to the set.</param>
        /// <returns>True if the element is added. False if the element already presents.</returns>
        public bool Add(T item)
        {
            int position = this.Position(item);
            if (this.buckets[position] == null)
            {
               this.buckets[position] = new SinglyLinkedList<T>();
            }

            var list = this.buckets[position];

            if (list.Contains(item))
            {
                return false;
            }

            list.Add(item);
            this.Count++;

            return true;
        }

        /// <summary>
        /// Removes all elements.
        /// </summary>
        public void Clear()
        {
            this.Count = 0;
            this.buckets = new SinglyLinkedList<T>[TableSize];
        }

        /// <summary>
        /// Determines whether the Set contains the specified element.
        /// </summary>
        /// <param name="item">The element to locate.</param>
        /// <returns>True if the Set contains the specified element.</returns>
        public bool Contains(T item) => this.buckets[this.Position(item)] == null ? false : this.buckets[this.Position(item)].Contains(item);

        /// <summary>
        /// Removes the specified element.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        /// <returns>True if the element is successfully found and removed; otherwise, false.</returns>
        public bool Remove(T item)
        {
            int position = this.Position(item);
            if (this.buckets[position] == null)
            {
                return false;
            }

            var list = this.buckets[position];

            if (list.Remove(item) == true)
            {
                this.Count--;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Copies the elements to a new array.
        /// </summary>
        /// <returns>A new array containing elements of the set.</returns>
        public T[] ToArray()
        {
            var list = new List<T>();
            for (int i = 0; i < this.buckets.Length; i++)
            {
                if (this.buckets[i] == null)
                {
                    continue;
                }

                var array = this.buckets[i].ToArray();
                for (int j = 0; j < array.Length; j++)
                {
                    list.Add(array[j]);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the set.
        /// </summary>
        /// <returns>An enumerator for the queue.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var array = this.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private int GetHash(T item) => item.GetHashCode();

        private int Position(T item) => this.GetHash(item) % TableSize;
    }
}
