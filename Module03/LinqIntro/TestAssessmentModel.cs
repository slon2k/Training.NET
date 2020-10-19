// <copyright file="TestAssessmentModel.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro
{
    using System;

    /// <summary>
    /// Model for import values.
    /// </summary>
    public class TestAssessmentModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestAssessmentModel"/> class.
        /// Model for import and export.
        /// </summary>
        /// <param name="name">Full name.</param>
        /// <param name="subject">Subject.</param>
        /// <param name="testDate">Date.</param>
        /// <param name="assessment">Assessment.</param>
        public TestAssessmentModel(string name, string subject, DateTime testDate, int assessment)
        {
            this.Name = name;
            this.Subject = subject;
            this.TestDate = testDate;
            this.Assessment = assessment;
        }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets date.
        /// </summary>
        public DateTime TestDate { get; set; }

        /// <summary>
        /// Gets or sets assessment.
        /// </summary>
        public int Assessment { get; set; }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <returns>String with the test assessment data.</returns>
        public override string ToString()
        {
            return $"{this.Name} {this.Subject} {this.TestDate.ToShortDateString()} {this.Assessment}";
        }
    }
}
