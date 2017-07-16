using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PySwitcherSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            string final = String.Empty;
            char answer;

            Console.WriteLine("Please add your python versions: ");
            while (end != true)
            {
                Console.Write("Label(What you would like it to show up as): ");
                final += "version " + Console.ReadLine() + " ";

                Console.Write("Path to that version(double backslashes please): ");
                final += Console.ReadLine() + "\n";

                Console.Write("Done? [y/n]: ");
                answer = (char)Console.Read();
                Console.ReadLine();
                if (answer == 'y')
                {
                    end = true;
                }
            }

            File.WriteAllText(Environment.CurrentDirectory + "\\versions.dat", final);
        }
    }
}
