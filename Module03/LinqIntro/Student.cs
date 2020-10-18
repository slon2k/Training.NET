// <copyright file="Student.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro
{
    using System;

    /// <summary>
    /// Student.
    /// </summary>
    public class Student : IComparable<Student>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="name">Full name.</param>
        public Student(string name)
        {
            var strings = name.Trim().Split();
            string lastName = strings[^1];
            string firstName = string.Join(" ", strings[0..^1]);
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException(nameof(name));
            }

            this.LastName = lastName;
            this.FirstName = firstName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        public Student(string firstName, string lastName)
        {
            this.FirstName = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            this.LastName = !string.IsNullOrWhiteSpace(lastName) ? lastName : throw new ArgumentNullException(nameof(lastName));
        }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets full name.
        /// </summary>
        public string FullName => $"{this.FirstName} {this.LastName}";

        /// <summary>
        /// Student comparison.
        /// </summary>
        /// <param name="other">Object to compare with.</param>
        /// <returns>Integer, representing sorting order for students.</returns>
        public int CompareTo(Student other)
        {
            return this.FullName.CompareTo(other.FullName);
        }
    }
}
