// <copyright file="Program.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro
{
    using System;
    using LinqIntro.Services;

    /// <summary>
    /// Task 1.
    /// Develop a console application that uses LINQ queries to retrieve and display data.
    /// Data is stored in a binary file and represents information about the results of students’ tests.
    /// Information about the student contains the name of the student, the name of the test,
    /// the date of the test and the assessment of the test for this student.
    /// To work with data the information is read into a binary search tree.
    /// Provide the ability to define user criteria for viewing data.
    /// Expand the ability to work with the application in such a way that users can specify the sort order and limit the number of rows retrieved.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args">Args.</param>
        public static void Main(string[] args)
        {
            var fileService = new FileService();

            // var seededAssessments = DataGenerator.GetAssessments();
            // fileService.ExportAssestmentsToBinaryFile(seededAssessments);
            var assessments = fileService.ImportAssestmentsFromBinaryFile();

            var testAssessmentsService = new TestAssessmentService();

            foreach (var item in assessments)
            {
                testAssessmentsService.AddAssessment(item.Name, item.Subject, item.TestDate, item.Assessment);
            }

            Console.WriteLine();
            Console.WriteLine("Selecting subject transfiguration:");
            var list = testAssessmentsService.GetAssessments(new RequestParams { Subject = "transfiguration" });
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Selecting student Patil:");
            list = testAssessmentsService.GetAssessments(new RequestParams { Name = "patil" });
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("First 5 assessments:");
            list = testAssessmentsService.GetAssessments(new RequestParams { PageSize = 5 });
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Order by subject:");
            list = testAssessmentsService.GetAssessments(new RequestParams { OrderBy = "subject" });
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
