// <copyright file="Task03.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Methods
{
    /// <summary>
    /// Task 3.
    /// Implement a method for nullable types to determine whether a reference is null or not.
    /// </summary>
    public static class Task03
    {
        /// <summary>
        /// Extends nullable struct to check null-reference.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="value">Value to check.</param>
        /// <returns>True if reference is null.</returns>
        public static bool IsNull<T>(this T? value)
            where T : struct
        {
            if (value == null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Extends reference types to check null-reference.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="value">Value to check.</param>
        /// <returns>True if reference is null.</returns>
        public static bool IsNull<T>(this T value)
            where T : class
        {
            if (value == null)
            {
                return true;
            }

            return false;
        }
    }
}
