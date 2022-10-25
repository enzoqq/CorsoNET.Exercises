using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurozone.Country
{
    public class Continent
    {
        private List<Country> _countries;
        private string _nome;

        public Continent(string nome)
        {
            _countries = new List<Country>();
            _nome = nome;
        }

        public void addCountry(Country newCountry)
        {
            if(_countries.IndexOf(newCountry) == -1 && newCountry.continente == _nome)
                _countries.Add(newCountry);
        }

        public void removeCountry(Country newCountry)
        {
            if (_countries.IndexOf(newCountry) != -1 && newCountry.continente == _nome)
                _countries.Remove(newCountry);
        }
    }
}
