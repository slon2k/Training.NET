// <copyright file="Task04.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace BasicCoding
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Task 4.
    /// Implement an algorithm for concatenating two strings excluding duplicate characters.
    /// </summary>
    public static class Task04
    {
        /// <summary>
        /// Concatenates two strings excluding from the second string characters from the first string.
        /// </summary>
        /// <param name="firstString">First string.</param>
        /// <param name="secondString">Second string.</param>
        /// <returns>Concatenated string.</returns>
        public static string ConcatenateStrings(string firstString, string secondString)
        {
            var charactersUsed = new HashSet<char>();
            foreach (var character in firstString)
            {
                charactersUsed.Add(character);
            }

            var str = new StringBuilder();
            str.Append(firstString);

            foreach (var character in secondString)
            {
                if (!charactersUsed.Contains(character))
                {
                    str.Append(character);
                }
            }

            return str.ToString();
        }
    }
}
