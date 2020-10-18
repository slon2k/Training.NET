// <copyright file="RequestParams.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro
{
    using System;

    /// <summary>
    /// Request parameters.
    /// </summary>
    public class RequestParams
    {
        /// <summary>
        /// Gets or sets order.
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Gets or sets subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets page starting with 1.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Gets or sets page size.
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Gets or sets start date.
        /// </summary>
        public DateTimeOffset? From { get; set; }

        /// <summary>
        /// Gets or sets last date.
        /// </summary>
        public DateTimeOffset? Till { get; set; }
    }
}