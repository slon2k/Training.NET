// <copyright file="CountdownEventArgs.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Delegates
{
    using System;

    /// <summary>
    /// Event args.
    /// </summary>
    public class CountdownEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets message.
        /// </summary>
        public string Message { get; set; }
    }
}
