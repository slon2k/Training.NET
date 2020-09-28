// <copyright file="Task01.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Methods
{
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;
    using System.Text;

    /// <summary>
    /// Task 1.
    /// Extend the functionality of the System.Double type by implementing the ability to get the string representation of a real number in the IEEE 754 format.
    /// </summary>
    public static class Task01
    {
        /// <summary>
        /// String representation of a number in the IEEE 754 format.
        /// </summary>
        /// <param name="number">Floating point number.</param>
        /// <returns>String in the IEEE 754 format.</returns>
        public static string ToIEEE754(this double number)
        {
            return "0";
        }
    }
}
