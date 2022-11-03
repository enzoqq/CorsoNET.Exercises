using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurozone.Country
{

    public class City
    {
        public string nome;
        public List<Citizen> citizens;
        public string myCountry;
        public int maxCitizens;
        private Random _random = new Random();
        private string[] names = { "Luca", "Claudio", "Armando", "Francesco", "Andrea" };
        private string[] surnames = { "Bianchi", "Rossi", "Colle", "Russo", "Soleri" };

        public City(string _nome, string _country, int _maxCitizens)
        {
            nome = _nome;
            myCountry = _country;
            maxCitizens = _maxCitizens;
            citizens = new List<Citizen>();
        }

        public void addCitizen(Citizen newCitizen)
        {
            if (citizens.IndexOf(newCitizen) == -1 && citizens.Count < maxCitizens)
                citizens.Add(newCitizen);
        }

        public void removeCitizen(Citizen newCitizen, City newCity)
        {
            if (citizens.IndexOf(newCitizen) != -1)
                citizens.Remove(newCitizen);

            newCity.addCitizen(newCitizen);
        }

        public void manualAddCitizen()
        {
            if (citizens.Count < maxCitizens)
            {
                DateTime birthday = new DateTime();
                string newnome = "", newcognome = "";
                Console.WriteLine("Città: " + nome + "\n");
                Console.Write("* Nome: ");
                newnome = Console.ReadLine();
                Console.Write("* Cognome: ");
                newcognome = Console.ReadLine();
                Console.Write("Data di Nascita: ");
                if (DateTime.TryParse(Console.ReadLine(), out birthday))
                    citizens.Add(new Citizen(newnome, newcognome, birthday, nome));
                else
                    Console.WriteLine("Data non corretta.");
            }
            else Console.WriteLine("Città " + nome + " al completo. ");
        }

        public void randomAddCitizens(int _random_generation)
        {
            if(_random_generation > (maxCitizens - citizens.Count))
                _random_generation = (maxCitizens - citizens.Count);

            for (int i = 0; i < _random_generation; i++)
            {
                citizens.Add(new Citizen(genName(), genSurname(), genBirthday(), nome));

            }
        }

        public void printCitizens()
        {
            Console.WriteLine("Città: " + nome + "\n");
            for (int i = 0; i < citizens.Count; i++)
                Console.WriteLine($"> {citizens[i].nome} {citizens[i].cognome} {citizens[i].birthday.ToString("dd/MM/yyyy")}");
        }

        public void printCitizensSigned()
        {
            Console.WriteLine("Città: " + nome + "\n");
            for (int i = 0; i < citizens.Count; i++)
                if (citizens[i].signed)
                    Console.WriteLine($"- {citizens[i].nome} {citizens[i].cognome} {citizens[i].birthday.ToString("dd/MM/yyyy")}");
        }

        public void signAllPrinted(string _timezone)
        {
            DateTime thistime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, _timezone);
            Console.WriteLine(thistime);
            Console.WriteLine("Città: " + nome + "\n");
            for (int i = 0; i < citizens.Count; i++)
                citizens[i].SignPaper(thistime.Hour);
        }

        public string genName()
        {
            return names[_random.Next(names.Length)];
        }

        public string genSurname()
        {
            return surnames[_random.Next(surnames.Length)];
        }

        public DateTime genBirthday()
        {
            return Convert.ToDateTime($"{_random.Next(1, 28)}-{_random.Next(1, 12)}-{_random.Next(1970, 2000)}");
        }


    }
}
