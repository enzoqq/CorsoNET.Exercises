using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDictionary
{
    internal class Program
    {
        enum Department { 
            ASL,
            COMUNE,
            POLIZIA,
            INPS,
            SCUOLA
        }

        static string userSearch = "SRCPBL001";
        static Department departmentSearch = Department.SCUOLA;

        static void Main(string[] args)
        {
            Dictionary<Department, Dictionary<string, DateTime>> gestionaleStato = 
                new Dictionary<Department, Dictionary<string, DateTime>>();

            foreach (Department department in (Department[])Enum.GetValues(typeof(Department)))
                gestionaleStato.Add(department, new Dictionary<string, DateTime>());

            #region Valori in Anagrafica
            gestionaleStato[Department.ASL].Add("FRLVCN001", Convert.ToDateTime("06-09-1999"));
            gestionaleStato[Department.COMUNE].Add("PLLBRS001", Convert.ToDateTime("15-02-1988"));
            gestionaleStato[Department.COMUNE].Add("PLLBRS002", Convert.ToDateTime("02-03-2001"));
            gestionaleStato[Department.POLIZIA].Add("CLDMRC001", Convert.ToDateTime("12-12-1989"));
            gestionaleStato[Department.SCUOLA].Add("SRCPBL001", Convert.ToDateTime("06-06-1972"));
            gestionaleStato[Department.SCUOLA].Add("SRCPBL002", Convert.ToDateTime("13-07-1969"));
            gestionaleStato[Department.SCUOLA].Add("SRCPBL003", Convert.ToDateTime("03-04-1993"));
            #endregion

            foreach (var department in gestionaleStato)
                if (department.Value.ContainsKey(userSearch))
                    Console.WriteLine($"- Utente {userSearch}\nAnagrafica Trovata: {department.Value["SRCPBL001"].Date.ToString("MM/dd/yyyy")}\n");

            Console.WriteLine($"- Users in {departmentSearch}");
            foreach(var user in gestionaleStato[departmentSearch])
                Console.WriteLine($"{user.Key} in {user.Value.Date.ToString("MM/dd/yyyy")}");


            Console.WriteLine("\n- All Users: ");
            foreach (var department in gestionaleStato)
                foreach (var user in department.Value)
                    Console.WriteLine($"{user.Key} in {user.Value.Date.ToString("MM/dd/yyyy")}");

            Console.ReadKey();
        }
    }
}
