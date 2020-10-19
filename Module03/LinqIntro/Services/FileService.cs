// <copyright file="FileService.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// File service.
    /// </summary>
    public class FileService
    {
        /// <summary>
        /// Writes test assessments to binary file.
        /// </summary>
        /// <param name="testAssessments">Test assessments to export.</param>
        /// <param name="fileName">File to write.</param>
        public void ExportAssestmentsToBinaryFile(IEnumerable<TestAssessmentModel> testAssessments, string fileName = "assessments.dat")
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            try
            {
                using (var writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    foreach (var item in testAssessments)
                    {
                        writer.Write(item.Name);
                        writer.Write(item.Subject);
                        writer.Write(item.TestDate.ToString());
                        writer.Write(item.Assessment);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Error writing file.");
            }
        }

        /// <summary>
        /// Reads test assessments from binary file.
        /// </summary>
        /// <param name="fileName">File to read.</param>
        /// <returns>Imported assessments.</returns>
        public IEnumerable<TestAssessmentModel> ImportAssestmentsFromBinaryFile(string fileName = "assessments.dat")
        {
            var testAssessments = new List<TestAssessmentModel>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            try
            {
                using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();
                        string subject = reader.ReadString();
                        string dateString = reader.ReadString();
                        DateTime date = DateTime.Parse(dateString);
                        int assessment = reader.ReadInt32();
                        testAssessments.Add(new TestAssessmentModel(name, subject, date, assessment));
                    }
                }

                return testAssessments;
            }
            catch (Exception)
            {
                throw new Exception("Error reading file.");
            }
        }
    }
}
