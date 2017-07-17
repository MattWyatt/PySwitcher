using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace PySwitcherSetup
{
    class Program
    {
        static void AddToRegistry()
        {
            string currentLocation = Environment.CurrentDirectory;

            RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey InstallationKey = SoftwareKey.CreateSubKey("PySwitcher");
            InstallationKey.SetValue("Location", currentLocation);
            Console.WriteLine("Added {0} to the registry", InstallationKey.Name);
        }

        static void AddToEnvironment()
        {
            string currentLocation = Environment.CurrentDirectory;

            string CurrentEnvironment = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
            string NewEnvironment = CurrentEnvironment + currentLocation + ";";
            Environment.SetEnvironmentVariable("PATH", NewEnvironment, EnvironmentVariableTarget.User);
        }

        static void Main(string[] args)
        {
            bool end = false;
            string final = String.Empty;
            char answer;

            Console.WriteLine("Would you like to enable command line usage?[y/n]");
            answer = answer = (char)Console.Read();
            Console.ReadLine();

            if (answer == 'y')
            {
                AddToRegistry();
                AddToEnvironment();
            }
            

            Console.WriteLine("Please add your python versions: ");
            while (end != true)
            {
                Console.Write("Version Name: ");
                final += "version " + Console.ReadLine() + " ";

                Console.Write("Path to that version: ");
                final += Console.ReadLine() + "\n";

                Console.Write("Done? [y/n]: ");
                answer = (char)Console.Read();
                Console.ReadLine();

                if (answer == 'y')
                {
                    end = true;
                }
            }

            File.WriteAllText(".\\versions.dat", final);
        }
    }
}
