using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.LoggerFileGenerics
{
    public static class MoleSearcher
    {
        public static bool SearchAttributes<T>(string[] properties) where T : class, new()
        {
            bool correct = false;
            foreach (var property in properties)
                if (SearchAttribute<T>(property) == true)
                    correct = true;

            return correct;
        }
        public static bool SearchAttribute<T>(string value) where T : class, new()
        {
            foreach (var property in new T().GetType().GetProperties())
                if (property.Name == value)
                    return true;

            return false;
        }
    }
}
