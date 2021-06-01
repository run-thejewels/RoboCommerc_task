using System;
using System.IO;
using System.Reflection;

namespace RoboCommerc
{
    class Program
    {
        static string AssemblyStruct(string path)
        {
            string result = "";
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path, "*.ddl");
                foreach (string f in files)
                {
                    Assembly assembly = Assembly.LoadFile(f);
                    var classes = assembly.GetTypes();
                    foreach (var c in classes)
                    {
                        result += c.Name + "\n";
                        var methods = c.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                        foreach (var m in methods)
                            result += "-" + m.Name + "\n";
                    }
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            string dir = @"C:\Users\test";
            Console.Write(AssemblyStruct(dir));
        }
    }
}
