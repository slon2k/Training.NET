// <copyright file="MessageService.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Delegates
{
    using System;

    /// <summary>
    /// Demo message service.
    /// </summary>
    public class MessageService
    {
        /// <summary>
        /// Callback to run.
        /// </summary>
        /// <param name="source">Event source.</param>
        /// <param name="args">Event args.</param>
        public void OnTimeElapsed(object source, CountdownEventArgs args)
        {
            Console.WriteLine($"Message service: {args.Message}");
        }
    }
}
