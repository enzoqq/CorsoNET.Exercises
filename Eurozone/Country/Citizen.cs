using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurozone.Country
{
    public class Citizen
    {
        public string nome;
        public string cognome;
        public string city;

        public Citizen(string nome, string cognome, string city)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.city = city;
        }
    }
}
