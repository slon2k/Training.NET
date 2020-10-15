// <copyright file="HashTable.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Collections.Task306
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Hash-table with chaining.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the table.</typeparam>
    public class HashTable<T>
    {
        private readonly IList<T>[] buckets;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashTable{T}"/> class.
        /// </summary>
        /// <param name="size">Size of tthe table.</param>
        public HashTable(int size)
        {
            this.buckets = new IList<T>[size];
        }
    }
}
