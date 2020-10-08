// <copyright file="CustomerExtensions.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Framework.Task101
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Task 1.
    /// Customer class has three public properties - Name (string), ContactPhone (string) and Revenue (decimal).
    /// Implement for the Customer's objects the capability of a various string representation.
    /// </summary>
    public static class CustomerExtensions
    {
        /// <summary>
        /// Record including customer properties.
        /// </summary>
        /// <param name="customer">Customer.</param>
        /// <param name="options">Fields to include: "name", "phone", "revenue".</param>
        /// <returns>Customer record.</returns>
        public static string CustomerRecord(this Customer customer, params string[] options)
        {
            var optionList = options.Select(o => GetProp(customer, o));
            return string.Join(", ", optionList);
        }

        private static string GetProp(Customer customer, string prop)
        {
            string option = prop.ToLowerInvariant();
            var us = CultureInfo.GetCultureInfo("us-Us");
            return option switch
            {
                "name" => customer.Name,
                "phone" => customer.Phone,
                "revenue" => customer.Revenue.ToString("C", us),
                _ => throw new ArgumentException("Invalid option", nameof(prop)),
            };
        }
    }
}
