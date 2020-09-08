using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeKata
{
    public class BuildFile
    {
        public static string CreateFile(string folder, string fileName)
        {
            CreateDirectoryIfDoesNotExist(folder);
            CreateFileIfDoesNotExist(fileName);
            var fullFilePath = folder + fileName;
            return fullFilePath;
        }

        private static void CreateFileIfDoesNotExist(string v)
        {
            if (!File.Exists(v)) File.Create(v);
        }

        private static void CreateDirectoryIfDoesNotExist(string v)
        {
            if (!Directory.Exists(v)) Directory.CreateDirectory(v);
        }


    }
}
