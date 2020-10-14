// <copyright file="GenericQueue.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Collections.Task304
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Task 4.
    /// Develop a generic class-collection Queue that implements the basic operations for working with the structure data queue.
    /// Implement the capability to iterate by collection by design pattern Iterator.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class GenericQueue<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 100;
        private T[] items;
        private int start = 0;
        private int end = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericQueue{T}"/> class.
        /// </summary>
        public GenericQueue()
        {
            this.items = new T[InitialCapacity];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericQueue{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new GenericQueue.</param>
        public GenericQueue(IEnumerable<T> collection)
        {
            this.Initialize(collection.ToArray());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericQueue{T}"/> class.
        /// </summary>
        /// <param name="array">The array whose elements are copied to the new GenericQueue.</param>
        public GenericQueue(T[] array)
        {
            this.Initialize(array);
        }

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        public int Count => this.end - this.start + 1;

        /// <summary>
        /// Removes all elements.
        /// </summary>
        public void Clear()
        {
            this.start = 0;
            this.end = -1;
        }

        /// <summary>
        /// Removes and returns the element at the beginning.
        /// </summary>
        /// <returns>The element that is removed from the beginning.</returns>
        public T Dequeue() => this.Count > 0 ? this.items[this.start++] : throw new InvalidOperationException();

        /// <summary>
        /// Adds an object to the end.
        /// </summary>
        /// <param name="item">The element to add.</param>
        public void Enqueue(T item)
        {
            if (this.end >= this.items.Length - 1)
            {
                this.AddCapacity(InitialCapacity);
            }

            this.items[++this.end] = item;
        }

        /// <summary>
        /// Returns the element at the beginning without removing it.
        /// </summary>
        /// <returns>The element at the beginning.</returns>
        public T Peek() => this.Count > 0 ? this.items[this.start] : throw new InvalidOperationException();

        /// <summary>
        /// Copies the elements to a new array.
        /// </summary>
        /// <returns>A new array containing elements of the queue.</returns>
        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            Array.Copy(this.items[this.start..], array, this.Count);
            return array;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the queue.
        /// </summary>
        /// <returns>An enumerator for the queue.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void AddCapacity(int size)
        {
            int count = this.Count;
            T[] array = new T[count + size];
            Array.Copy(this.items[this.start..], array, count);
            this.items = array;
            this.start = 0;
            this.end = count - 1;
        }

        private void Initialize(T[] array)
        {
            int length = array.Length;
            this.items = new T[length + InitialCapacity];
            Array.Copy(array, this.items, length);
            this.end = length - 1;
        }

        private class Enumerator : IEnumerator<T>
        {
            private readonly T[] items;
            private int currentIndex = -1;

            public Enumerator(GenericQueue<T> queue)
            {
                this.items = queue.ToArray();
            }

            public T Current => this.IndexIsInRange() ? this.items[this.currentIndex] : throw new InvalidOperationException("Index out of range");

            object IEnumerator.Current => this.IndexIsInRange() ? this.items[this.currentIndex] : throw new InvalidOperationException("Index out of range");

            public bool MoveNext() => ++this.currentIndex < this.items.Length;

            public void Reset() => this.currentIndex = -1;

            void IDisposable.Dispose()
            {
            }

            private bool IndexIsInRange() => this.currentIndex > -1 && this.currentIndex < this.items.Length;
        }
    }
}
