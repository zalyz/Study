using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab3
{
    public static class FileReading
    {
        public static string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        public static void SaveInFile(string path, string text)
        {
            using (StreamWriter writer = new StreamWriter(Path.GetFullPath(path)))
            {
                writer.Write(text);
            }
        }
    }
}
