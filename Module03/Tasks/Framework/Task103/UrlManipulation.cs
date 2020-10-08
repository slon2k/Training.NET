// <copyright file="UrlManipulation.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Framework.Task103
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Task 3.
    /// Write a function that can manipulate URL parameters.
    /// It should be able to add a parameter to an existing URL, but also to change a parameter if it already exists.
    /// </summary>
    public static class UrlManipulation
    {
        /// <summary>
        /// Changing or adding URL paremeter.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="keyValueParameter">Parameter.</param>
        /// <returns>Changed URL.</returns>
        public static string AddOrChangeUrlParameter(string url, string keyValueParameter)
        {
            var urlParameters = url.Split("?");

            if (urlParameters.Length > 2 || urlParameters.Length == 0)
            {
                throw new ArgumentException(nameof(url));
            }

            var newParameter = keyValueParameter.Split("=");

            if (newParameter.Length != 2)
            {
                throw new ArgumentException(nameof(keyValueParameter));
            }

            string baseUrl = urlParameters[0];

            var oldStringParameters = urlParameters.Length == 2 ? urlParameters[1].Split("&").ToList() : new List<string>();

            var parameters = oldStringParameters.Select(p => KeyValue(p)).ToList().ToDictionary(x => x.Item1, x => x.Item2);

            parameters[newParameter[0]] = newParameter[1];

            var newStringParameters = parameters.Select(item => $"{item.Key}={item.Value}");

            return $"{baseUrl}?{string.Join("&", newStringParameters)}";
        }

        private static Tuple<string, string> KeyValue(string parameter)
        {
            var keyValue = parameter.Split("=");

            if (keyValue.Length != 2)
            {
                throw new ArgumentException(nameof(parameter));
            }

            return new Tuple<string, string>(keyValue[0], keyValue[1]);
        }
    }
}
