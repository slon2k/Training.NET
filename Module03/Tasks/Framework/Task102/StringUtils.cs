// <copyright file="StringUtils.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Framework.Task102
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a function that will convert a string into title case, given an optional list of exceptions (minor words).
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Converts a string into title case.
        /// </summary>
        /// <param name="originalString">The original string to be converted.</param>
        /// <param name="minorWords">Space-delimited list of minor words that must always be lowercase.</param>
        /// <returns>String in title case.</returns>
        public static string ConvertToTitleCase(string originalString, string minorWords = null)
        {
            if (string.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException(nameof(originalString));
            }

            var minors = !string.IsNullOrWhiteSpace(minorWords) ? minorWords.Split().ToList<string>() : new List<string>();

            var wordsToExclude = new HashSet<string>(minors.Select(w => w.ToLowerInvariant()));

            var words = originalString.Split();

            var wordsInTitleCase = words.Select(word => wordsToExclude.Contains(word.ToLowerInvariant()) ? word.ToLowerInvariant() : Capitalize(word)).ToList();

            wordsInTitleCase[0] = Capitalize(wordsInTitleCase[0]);

            return string.Join(" ", wordsInTitleCase);
        }

        private static string Capitalize(string word)
        {
            return $"{word.Substring(0, 1).ToUpperInvariant()}{word.Substring(1).ToLowerInvariant()}";
        }
    }
}
