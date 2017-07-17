using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace PySwitcher
{
    partial class Program
    {
        static VersionParser p;
        static HasRunParser h;
        static CurrentParser c;

        static void AskLoop()
        {
            bool success = false;

            while (success != true)
            {
                string input = Console.ReadLine();

                foreach (string key in p.Versions.Keys)
                {
                    if (key == input && c.CurrentLabel != key)
                    {
                        Console.WriteLine("Added version [" + key + "] to path");

                        if (h.hasrun)
                        {
                            OverwriteEnv(c.CurrentPath, p.Versions[key]);
                        }
                        else
                        {
                            AddPathToEnv(p.Versions[key]);
                        }

                        c.Set(key, p.Versions[key]);
                        success = true;
                    }

                    else if (key == input && c.CurrentLabel == key)
                    {
                        Console.WriteLine("You are using that version");
                        success = false;
                    }
                }

                if (success == false)
                {
                    Console.WriteLine("Something went wrong, try again");
                }
            }
        }

        static void Main(string[] args)
        {
            RegistryKey AppKey = Registry.CurrentUser.OpenSubKey("Software\\PySwitcher");
            string homeDirectory = AppKey.GetValue("Location").ToString();
            Console.WriteLine("HOMEDIR: {0}", homeDirectory);

            p = new VersionParser(homeDirectory + "\\versions.dat");
            h = new HasRunParser(homeDirectory + "\\hasrun.dat");
            c = new CurrentParser(homeDirectory + "\\current.dat");

            Console.WriteLine("Available Python Versions are: ");
            foreach (string key in p.Versions.Keys)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine("You are currently using version: " + c.CurrentLabel + " in path: " + c.CurrentPath);
            Console.WriteLine("\nSelect one by typing the name");

            AskLoop();
            Console.ReadKey();
        }
    }
}
