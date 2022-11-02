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
            // Generazione Paese
            CountryEU_ONU italiaCountry = new CountryEU_ONU(60000, 324000, "Europa", "Italia", "Costituzione Italiana", "VerdeBiancoRosso", "Euro", "Italiano", 100, false);

            // Generazione Città con un massimo numero di Cittadini
            City romeCity = new City("Rome", "Italy", 20);
            City milanCity = new City("Milan", "Italy", 10);

            // Generazione Randomica di un certo numero di Cittadini
            romeCity.randomAddCitizens(8);
            milanCity.randomAddCitizens(4);

            // Generazione Manuale di un Cittadino
            milanCity.manualAddCitizen();

            Console.Clear();

            // Stampa dei Cittadini della Città
            milanCity.printCitizens();

            Console.ReadKey();
        }
    }
}
