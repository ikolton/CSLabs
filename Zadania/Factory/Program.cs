// Program.cs in Fabryka project
using System;
using System.Reflection;
using Common;

namespace Fabryka
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                var parts = arg.Split(';');
                if (parts.Length == 2)
                {
                    string assemblyPath = parts[0];
                    string zlecenieTitle = parts[1];

                    var assembly = Assembly.LoadFile(assemblyPath);
                    var types = assembly.GetTypes();

                    foreach (var type in types)
                    {
                        if (typeof(IZlecenie).IsAssignableFrom(type) && type.IsClass)
                        {
                            var zlecenie = (IZlecenie)Activator.CreateInstance(type);

                            // Set the Tytuł property using PropertyInfo
                            var tytulProperty = type.GetProperty("Title");
                            if (tytulProperty != null && tytulProperty.CanWrite)
                            {
                                tytulProperty.SetValue(zlecenie, zlecenieTitle);
                            }
                            
                            System.Console.WriteLine("*********************************************");
                            System.Console.WriteLine($"Processing {zlecenie.GetType().Name}...");
                            zlecenie.Process();
                        }
                    }
                }
            }
        }
    }
}