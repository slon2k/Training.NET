// <copyright file="TestAssessmentServiceTests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro.Tests
{
    using System;
    using System.Linq;
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
            var studentService = new StudentService();
            this.assessmentService = new TestAssessmentService(studentService);
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
            Assert.That(assessments.Count, Is.EqualTo(12));
        }

        /// <summary>
        /// Testing filtering by subject.
        /// </summary>
        [Test]
        public void CheckTestAssessmentServiceFilteringBySubject()
        {
            var assessments = this.assessmentService.GetAssessments(new RequestParams() { Subject = "transfiguration" }).ToList();
            Assert.That(assessments.Count, Is.EqualTo(4));
        }

        /// <summary>
        /// Testing filtering by name.
        /// </summary>
        [Test]
        public void CheckTestAssessmentServiceFilteringByName()
        {
            var assessments = this.assessmentService.GetAssessments(new RequestParams() { Name = "patil" }).ToList();
            Assert.That(assessments.Count, Is.EqualTo(6));
        }

        /// <summary>
        /// Testing filtering by Date.
        /// </summary>
        public void CheckTestAssessmentServiceFilteringByDate()
        {
            var assessments = this.assessmentService.GetAssessments(new RequestParams() { From = new DateTime(1995, 5, 26) }).ToList();
            Assert.That(assessments.Count, Is.EqualTo(8));

            assessments = this.assessmentService.GetAssessments(new RequestParams() { Till = new DateTime(1995, 5, 25) }).ToList();
            Assert.That(assessments.Count, Is.EqualTo(4));

            assessments = this.assessmentService.GetAssessments(new RequestParams() { From = new DateTime(1995, 5, 26), Till = new DateTime(1995, 5, 26) }).ToList();
            Assert.That(assessments.Count, Is.EqualTo(4));
        }

        /// <summary>
        /// Testing pagination.
        /// </summary>
        [Test]
        public void CheckTestAssessmentPagination()
        {
            var assessments = this.assessmentService.GetAssessments(new RequestParams() { }).ToList();
            Assert.That(assessments.Count, Is.EqualTo(10));

            assessments = this.assessmentService.GetAssessments(new RequestParams() { Page = 2 }).ToList();
            Assert.That(assessments.Count, Is.EqualTo(2));

            assessments = this.assessmentService.GetAssessments(new RequestParams() { PageSize = 5 }).ToList();
            Assert.That(assessments.Count, Is.EqualTo(5));
        }
    }
}
