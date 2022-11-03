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
        public DateTime birthday;
        public bool signed;

        public Citizen(string nome, string cognome, DateTime _birthday, string city)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.city = city;
            birthday = _birthday;
            signed = false;
        }

        public void SignPaper(int actualHour)
        {
            if (actualHour >= 9 && actualHour <= 18)
            {
                if (DateTime.Now.Year - birthday.Year >= 18)
                {
                    signed = true;
                    Console.WriteLine($"{nome} {cognome} è stato iscritto al comune.");
                }
                else Console.WriteLine("Cittadino Minorenne. ");
            }
            else Console.WriteLine("Il Comune è chiuso a quest'ora. ");
        }
    }
}
