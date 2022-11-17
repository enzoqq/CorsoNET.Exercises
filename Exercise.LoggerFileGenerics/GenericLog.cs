using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.LoggerFileGenerics
{
    public static class GenericLog
    {
        public static void LogToFile<T>(List<T> data, string path) where T : class
        {
            StringBuilder line = new StringBuilder();

            if(data == null || data.Count == 0)
                throw new ArgumentException("data", "empty list or null");

            var element = data[0].GetType().GetProperties();
            foreach (var item in data)
            { 
                foreach (var attr in element)
                    line.Append($"[{attr.Name}] ");

                line.AppendLine();
            }

            File.AppendAllText(path, line.ToString());
        }

        public static void LogToFile<T>(T data, string path) where T : class
        {
            if (data == null)
                throw new ArgumentException("data", "empty item or null");

            StringBuilder line = new StringBuilder();
            foreach (var attr in data.GetType().GetProperties())
                line.Append($"[{attr.Name}] ");

            File.AppendAllText(path, line.ToString());
        }

        public static List<T> GetFromFile<T>(string path) where T : class, new()
        {
            List<T> output = new List<T>();
            T entry = new T();

            var lines = System.IO.File.ReadAllLines(path).ToList();
            string[] headers = lines.ElementAt(0).Split(' ');
            lines.RemoveAt(0);

            if (MoleSearcher.SearchAttributes<T>(headers))
            {
                int i = 0;
                foreach (var line in lines)
                {
                    i = 0;
                    string[] elements = line.Split(' ');
                    foreach (var element in elements)
                    {
                        Console.WriteLine(element);
                        entry = new T();
                        entry.GetType().GetProperty(headers[i])
                            .SetValue(entry, Convert.ChangeType(element, entry.GetType().GetProperty(headers[i]).PropertyType));
                        i++;
                    }
                    output.Add(entry);
                }
            }



            return output;
        }
    }
}
