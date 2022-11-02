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
            CountryEU_ONU italiaCountry = new CountryEU_ONU(60000, 324000, "Europa", "Italia", "Costituzione Italiana", "VerdeBiancoRosso", "Euro", "Italiano", 100, false);
            //CountryEU_ONU franciaCountry = new CountryEU_ONU(67000, 675000, "Europa", "Francia", "Costituzione Francese", "BluBiancoRosso", "Euro", "Francese", 150, false);
            //CountryEU_ONU germaniaCountry = new CountryEU_ONU(83000, 357000, "Europa", "Germania", "Legge Fondamentale Tedesca", "NeroRossoGiallo", "Euro", "Tedesco", 200, false);
            //CountryONU cinaCountry = new CountryONU(1400000, 9706000, "Asia", "Cina", "Costituzione della Repubblica Popolare Cinese", "RossoGiallo", "Renminbi", "Cinese Mandarino", 30, true);

            City romeCity = new City("Rome", "Italy", 20);
            City milanCity = new City("Milan", "Italy", 10);

            romeCity.randomAddCitizens(8);
            milanCity.randomAddCitizens(4);

            milanCity.manualAddCitizen();

            Console.Clear();

            milanCity.printCitizens();

            Console.ReadKey();
        }
    }
}
