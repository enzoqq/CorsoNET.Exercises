using Eurozone.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurozone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> timeParser = new Dictionary<string, string>();
            timeParser.Add("Albania", "Central Europe Standard Time");
            timeParser.Add("Andorra", "W. Europe Standard Time");
            timeParser.Add("Austria", "W. Europe Standard Time");
            timeParser.Add("Bosnia and Herzegovina", "Central European Standard Time");
            timeParser.Add("Croatia", "Central European Standard Time");
            timeParser.Add("Cyprus", "E. Europe Standard Time");
            timeParser.Add("Czech Republic", "Central Europe Standard Time");
            timeParser.Add("France", "Romance Standard Time");
            timeParser.Add("Germany", "W. Europe Standard Time");
            timeParser.Add("United Kingdom", "W. Europe Standard Time");
            timeParser.Add("Hungary", "Central Europe Standard Time");
            timeParser.Add("Italy", "W. Europe Standard Time");
            timeParser.Add("Jan Mayen", "W. Europe Standard Time");
            timeParser.Add("Kosovo", "Central European Standard Time");
            timeParser.Add("Libya", "E. Europe Standard Time");
            timeParser.Add("Liechtenstein", "W. Europe Standard Time");
            timeParser.Add("Luxembourg", "W. Europe Standard Time");
            timeParser.Add("Macedonia", "Central European Standard Time");
            timeParser.Add("Malta", "W. Europe Standard Time");
            timeParser.Add("Monaco", "W. Europe Standard Time");
            timeParser.Add("Montenegro", "Central European Standard Time");
            timeParser.Add("Netherlands", "W. Europe Standard Time");
            timeParser.Add("Norway", "W. Europe Standard Time");
            timeParser.Add("Poland", "Central European Standard Time");
            timeParser.Add("San Marino", "W. Europe Standard Time");
            timeParser.Add("Serbia", "Central Europe Standard Time");
            timeParser.Add("Slovakia", "Central Europe Standard Time");
            timeParser.Add("Slovenia", "Central Europe Standard Time");
            timeParser.Add("Svalbard", "W. Europe Standard Time");
            timeParser.Add("Sweden", "W. Europe Standard Time");
            timeParser.Add("Switzerland", "W. Europe Standard Time");
            timeParser.Add("Vatican City", "W. Europe Standard Time");

            Console.WriteLine(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard time"));
            // Generazione Paese
            CountryEU_ONU italiaCountry = new CountryEU_ONU(60000, 324000, "Europa", "Italia", "Costituzione Italiana", "VerdeBiancoRosso", "Euro", "Italiano", 100, false);

            // Generazione Città con un massimo numero di Cittadini
            City romeCity = new City("Rome", "Italy", 20);
            City milanCity = new City("Milan", "Italy", 10);

            City londonCity = new City("London", "United Kingdom", 10);

            // Generazione Randomica di un certo numero di Cittadini
            romeCity.randomAddCitizens(8);
            milanCity.randomAddCitizens(4);

            // Generazione Manuale di un Cittadino
            milanCity.manualAddCitizen();

            Console.Clear();

            // Stampa dei Cittadini della Città
            milanCity.printCitizens();

            Console.ReadKey();

            Console.Clear();

            milanCity.signAllPrinted(timeParser[milanCity.myCountry]);

            Console.ReadKey();

            Console.Clear();

            DateTime thistime;
            foreach (var element in timeParser)
            {
                thistime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, element.Value);
                Console.WriteLine($"{element.Key} {element.Value}\n{thistime}\n");
            }

            Console.ReadKey();
        }
    }
}
