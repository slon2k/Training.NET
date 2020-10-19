using System;
using System.IO;
using System.Text;

namespace Streams
{

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static long ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using var fileReader = new FileStream(sourcePath, FileMode.Open);
            using var fileWriter = new FileStream(destinationPath, FileMode.OpenOrCreate);

            long count = 0;
            int currentByte;
                
            for (int i = 0; i < fileReader.Length; i++)
            {
                currentByte = fileReader.ReadByte();
                fileWriter.WriteByte((byte)currentByte);
                count++;
            }
                
            fileWriter.SetLength(fileReader.Length);
            return count;
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            // TODO: step 1. Use StreamReader to read entire file in string
            string fileString;
            using var streamReader = new StreamReader(sourcePath);
            fileString = streamReader.ReadToEnd();


            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class
            Encoding encoding = Encoding.UTF8;
            var byteArray = encoding.GetBytes(fileString);
            char[] charArray;

            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)
            using var memStream = new MemoryStream();
            memStream.Write(byteArray, 0, byteArray.Length);               
            memStream.Seek(0, SeekOrigin.Begin);

            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array
            var newByteArray = new byte[memStream.Length];
            var count = 0;
            while (count < memStream.Length)
            {
                newByteArray[count++] = Convert.ToByte(memStream.ReadByte());
            }

            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content
            charArray = new char[encoding.GetCharCount(newByteArray, 0, count)];

            // TODO: step 6. Use StreamWriter here to write char array content in new file
            int charsCount = 0;
            using var streamWriter = new StreamWriter(destinationPath);
            foreach (var c in charArray)
            {
                streamWriter.Write(c);
                charsCount++;
            }

            return charsCount;
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static long ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using var fileReader = new FileStream(sourcePath, FileMode.Open);
            using var fileWriter = new FileStream(destinationPath, FileMode.OpenOrCreate);
            fileReader.CopyTo(fileWriter, 20);
            fileWriter.SetLength(fileReader.Length);
            return fileWriter.Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static long InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using var fileReader = new FileStream(sourcePath, FileMode.Open);
            using var memStream = new MemoryStream();
            using var fileWriter = new FileStream(destinationPath, FileMode.OpenOrCreate);
            fileReader.CopyTo(memStream, 20);
            memStream.CopyTo(fileWriter, 20);

            return fileWriter.Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static long BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using var fileReader = new FileStream(sourcePath, FileMode.Open);
            using var fileWriter = new FileStream(destinationPath, FileMode.OpenOrCreate);
            using var bufferedWriter = new BufferedStream(fileWriter);

            fileReader.CopyTo(bufferedWriter);
            return bufferedWriter.Length;
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (!File.Exists(sourcePath))
            {
                throw new ArgumentException(nameof(sourcePath), "File does not exist.");
            }

            try
            {
                var fi = new FileInfo(destinationPath);
            }
            catch (Exception)
            {
                throw new ArgumentException(nameof(destinationPath), "Invalid file name.");
            }
        }

        #endregion

        #endregion

    }
}
