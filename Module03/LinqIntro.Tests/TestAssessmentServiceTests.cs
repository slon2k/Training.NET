// <copyright file="TestAssessmentServiceTests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Tests for TestAssessmentService.
    /// </summary>
    public class TestAssessmentServiceTests
    {
        private TestAssessmentService assessmentService;

        /// <summary>
        /// Set up TestAssessmentService.
        /// </summary>
        [SetUp]
        public void SetUpService()
        {
            this.assessmentService = new TestAssessmentService();
            var assessments = TestAssessmentDataGenerator.GetAssessments();
            foreach (var item in assessments)
            {
                this.assessmentService.AddAssessment(item.Name, item.Subject, item.TestDate, item.Assessment);
            }
        }

        /// <summary>
        /// Test for GetAll.
        /// </summary>
        [Test]
        public void CheckTestAssessmentServiceGetAll()
        {
            var assessments = this.assessmentService.GetAll().ToList();
            Assert.That(assessments.Count, Is.EqualTo(3));
        }
    }
}
