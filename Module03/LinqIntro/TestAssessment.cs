﻿// <copyright file="TestAssessment.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro
{
    using System;

    /// <summary>
    /// Tests results.
    /// </summary>
    public class TestAssessment
    {
        private int assessment;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestAssessment"/> class.
        /// </summary>
        /// <param name="student">Student.</param>
        /// <param name="subject">Subject.</param>
        /// <param name="testDate">Test date.</param>
        /// <param name="assessment">Assessment.</param>
        public TestAssessment(Student student, string subject, DateTime testDate, int assessment)
        {
            this.Student = student ?? throw new ArgumentNullException(nameof(student));
            this.Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            this.TestDate = testDate;
            this.Assessment = assessment;
        }

        /// <summary>
        /// Gets or sets student.
        /// </summary>
        public Student Student { get; set; }

        /// <summary>
        /// Gets or sets subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets date of a test.
        /// </summary>
        public DateTime TestDate { get; set; }

        /// <summary>
        /// Gets or sets assessment.
        /// </summary>
        public int Assessment
        {
            get => this.assessment;

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Assessment));
                }

                this.assessment = value;
            }
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <returns>String with the test assessment data.</returns>
        public override string ToString()
        {
            return $"{this.Student.FullName} {this.Subject} {this.TestDate.ToShortDateString()} {this.Assessment}";
        }
    }
}
