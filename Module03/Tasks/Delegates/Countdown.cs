// <copyright file="Countdown.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Delegates
{
    using System;
    using System.Threading;

    /// <summary>
    /// Task 3.
    /// Develop a Countdown class, which implements the capability after the appointed time (waiting time is provided by the user)
    /// to transmit a message to any subscriber who subscribes to the event.
    /// </summary>
    public class Countdown
    {
        /// <summary>
        /// Event handler.
        /// </summary>
        public event EventHandler<CountdownEventArgs> TimeElapsed;

        /// <summary>
        /// Starts countdown.
        /// </summary>
        /// <param name="delay">Delay in ms.</param>
        public void Start(int delay)
        {
            Console.WriteLine($"Starting countdown at {DateTime.Now}");
            Thread.Sleep(delay);
            this.OnTimeElapsed(DateTime.Now);
        }

        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="time">Execution time.</param>
        protected virtual void OnTimeElapsed(DateTime time)
        {
            this.TimeElapsed?.Invoke(this, new CountdownEventArgs() { Message = $"Executed at {time}" });
        }
    }
}
