// <copyright file="TestAssesstmentDataGenerator.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro.Tests
{
    using System;
    using System.Collections.Generic;


    /// <summary>
    /// Fake data generator for TestAssessment.
    /// </summary>
    public static class TestAssessmentDataGenerator
    {
        public static List<TestAssessmentModel> GetAssessments()
        {
            return new List<TestAssessmentModel>()
            {
                new TestAssessmentModel("Luna Lovegood", "Transfiguration", new DateTime(1995, 5, 25), 65),
                new TestAssessmentModel("Luna Lovegood", "Herbology", new DateTime(1995, 5, 26), 70),
                new TestAssessmentModel("Luna Lovegood", "Potion making", new DateTime(1995, 5, 27), 60),
                new TestAssessmentModel("Padma Patil", "Transfiguration", new DateTime(1995, 5, 25), 80),
                new TestAssessmentModel("Padma Patil", "Herbology", new DateTime(1995, 5, 26), 75),
                new TestAssessmentModel("Padma Patil", "Potion making", new DateTime(1995, 5, 27), 70),
                new TestAssessmentModel("Parvati Patil", "Transfiguration", new DateTime(1995, 5, 25), 75),
                new TestAssessmentModel("Parvati Patil", "Herbology", new DateTime(1995, 5, 26), 80),
                new TestAssessmentModel("Parvati Patil", "Potion making", new DateTime(1995, 5, 27), 75),
                new TestAssessmentModel("Neville Longbottom", "Transfiguration", new DateTime(1995, 5, 25), 60),
                new TestAssessmentModel("Neville Longbottom ", "Herbology", new DateTime(1995, 5, 26), 100),
                new TestAssessmentModel("Neville Longbottom ", "Potion making", new DateTime(1995, 5, 27), 70),

            };
        }
    }
}
