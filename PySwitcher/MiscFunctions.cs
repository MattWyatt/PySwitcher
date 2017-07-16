using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PySwitcher
{
    partial class Program
    {
        public static void AddPathToEnv(string path)
        {
            string CurrentEnvironment = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
            string NewEnvironment = CurrentEnvironment + path + ";";
            Environment.SetEnvironmentVariable("PATH", NewEnvironment, EnvironmentVariableTarget.User);
        }

        public static string GetPath()
        {
            return Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
        }

        public static void WriteToFile(string FilePath, string Text)
        {
            File.WriteAllText(FilePath, Text);
        }

        public static void OverwriteEnv(string currentpath, string newpath)
        {
            string fullpath = GetPath();
            string p = currentpath;
            string npath = fullpath.Replace(p, newpath);

            Environment.SetEnvironmentVariable("PATH", npath, EnvironmentVariableTarget.User);
        }
    }
}
