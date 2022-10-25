using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurozone.Country
{
    public class City
    {
        private string nome;
        public List<Citizen> citizens;
        public string myCountry;

        public City(string _nome, string _country)
        {
            nome = _nome;
            myCountry = _country;
        }

        public void addCitizen(Citizen newCitizen)
        {
            if (citizens.IndexOf(newCitizen) == -1)
                citizens.Add(newCitizen);
        }

        public void removeCitizen(Citizen newCitizen, City newCity)
        {
            if (citizens.IndexOf(newCitizen) != -1)
                citizens.Remove(newCitizen);

            newCity.addCitizen(newCitizen);
        }


    }
}
