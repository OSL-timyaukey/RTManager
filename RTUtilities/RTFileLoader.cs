using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace RTUtilities
{
    public static class RTFileLoader
    {
        private static List<FileContents> _Files = new List<FileContents>();

        public static string[] GetFileContents(string fileName)
        {
            FileContents matchedFile = _Files.Find(
                delegate (FileContents contents) { return contents.FileName.Equals(fileName, StringComparison.InvariantCultureIgnoreCase); }
                );
            if (matchedFile == null)
            {
                string fullPath = RTSettings.GetConfigFilePath(fileName);
                matchedFile = new FileContents();
                matchedFile.FileName = fileName;
                matchedFile.Lines = File.ReadAllLines(fullPath);
                _Files.Add(matchedFile);
            }
            return matchedFile.Lines;
        }

        public class FileContents
        {
            public string FileName;
            public string[] Lines;
        }
    }
}
