using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    }
}
