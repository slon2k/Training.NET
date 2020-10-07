// <copyright file="Task101.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Customer class has three public properties - Name (string), ContactPhone (string) and Revenue (decimal).
    /// Implement for the Customer's objects the capability of a various string representation.
    /// </summary>
    public class Task101
    {
        /// <summary>
        /// Customer class.
        /// </summary>
        public class Customer
        {
            /// <summary>
            /// Gets or sets name.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets phone.
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// Gets or sets revenue.
            /// </summary>
            public decimal Revenue { get; set; }
        }
    }
}
