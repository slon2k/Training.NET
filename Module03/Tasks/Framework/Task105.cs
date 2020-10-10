// <copyright file="Task105.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Framework
{
    using System.Linq;

    /// <summary>
    /// Task 5.
    /// Reverse all of the words within the string.
    /// </summary>
    public static class Task105
    {
        /// <summary>
        /// Reverses all of the words within the string.
        /// </summary>
        /// <param name="sourceString">Source string.</param>
        /// <returns>Result string.</returns>
        public static string ReverseWords(string sourceString)
        {
            var words = sourceString.Split().ToList();
            words.Reverse();
            return string.Join(" ", words);
        }
    }
}
