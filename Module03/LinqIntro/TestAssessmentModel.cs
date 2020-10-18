// <copyright file="TestAssessmentModel.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Model for import values.
    /// </summary>
    public class TestAssessmentModel
    {
        public TestAssessmentModel(string name, string subject, DateTime testDate, int assessment)
        {
            Name = name;
            Subject = subject;
            TestDate = testDate;
            Assessment = assessment;
        }

        public string Name { get; set; }

        public string Subject { get; set; }

        public DateTime TestDate { get; set; }

        public int Assessment { get; set; }
    }
}
