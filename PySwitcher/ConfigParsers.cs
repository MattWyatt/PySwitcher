using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PySwitcher
{
    public class VersionParser
    {
        public VersionParser(string FilePath)
        {
            Versions = new SortedDictionary<string, string>();

            foreach (string line in File.ReadLines(FilePath))
            {
                if (line.StartsWith("version"))
                {
                    string text = line.Substring(8); //Number of letters in 'version' is 7; add one to clear the whitespace


                    int whitespaceIndex = text.LastIndexOf(" ");


                    string key = text.Substring(0, whitespaceIndex);

                    string value = text.Substring(whitespaceIndex+1);

                    Versions.Add(key, value);
                }
            }

        }

        public SortedDictionary<string, string> Versions;
        public string CurrentVersion;
    }

    public class HasRunParser
    {
        public HasRunParser(string FilePath)
        {
            string answer = File.ReadAllText(FilePath);
            if (answer.ToUpper().Contains("YES"))
            {
                hasrun = true;
            }

            else
            {
                hasrun = false;
                File.WriteAllText(FilePath, "YES");
            }
        }

        public bool hasrun;
    }

    public class CurrentParser
    {
        public CurrentParser(string FilePath)
        {
            this.FilePath = FilePath;
            foreach (string line in File.ReadLines(FilePath))
            {
                if (line.StartsWith("currentlabel"))
                {
                    string label = line.Substring(13);
                    CurrentLabel = label;
                }

                else if (line.StartsWith("currentpath"))
                {
                    string path = line.Substring(12);
                    CurrentPath = path;
                }
            }
        }

        public void Set(string label, string path)
        {
            string text = "currentlabel " + label + "\ncurrentpath " + path;
            Program.WriteToFile(FilePath, text);
        }

        public string CurrentLabel;
        public string CurrentPath;
        private string FilePath;
    }
}
