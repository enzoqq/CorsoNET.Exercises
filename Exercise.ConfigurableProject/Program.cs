using Microsoft.Extensions.Configuration;
using System;

namespace Exercise.ConfigurableProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appconfig.json").Build();
            Settings settings = config.GetRequiredSection("settings").Get<Settings>();
            Console.WriteLine(settings.Value1 + " " + settings.Value2);
        }
    }

    public class Settings
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
}
