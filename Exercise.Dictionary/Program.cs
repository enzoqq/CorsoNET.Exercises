using System;
using System.Collections.Generic;

namespace Exercise.Dictionary
{
    internal class Program
    {
        enum Department
        {
            ASL,
            COMUNE,
            POLIZIA,
            INPS,
            SCUOLA
        }

        enum EsameLaurea
        {
            AnalisiMatematica1,
            AnalisiMatematica2,
            Fisica1,
            Fisica2,
            Algebra,
            FondamentiInformatica,
            TeoriaSegnali,
            Elettronica1,
            Elettronica2
        }

        enum CorsoLaurea
        {
            Economia,
            Informatica,
            Chimica
        }
        static void Main(string[] args)
        {
            #region Esercizio Dipartimenti di Anagrafica
            /*
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

            */
            #endregion

            #region Esercizio Corsi di Laurea
            Dictionary<CorsoLaurea, Dictionary<string, Dictionary<EsameLaurea, int>>> universita =
                new Dictionary<CorsoLaurea, Dictionary<string, Dictionary<EsameLaurea, int>>>();


            foreach (CorsoLaurea corsolaurea in (CorsoLaurea[])Enum.GetValues(typeof(CorsoLaurea)))
                universita.Add(corsolaurea, new Dictionary<string, Dictionary<EsameLaurea, int>>());

            foreach (var corsolaurea in universita)
                Console.WriteLine(corsolaurea.Key);

            universita[CorsoLaurea.Economia].Add("Farella Vincenzo", new());
            universita[CorsoLaurea.Economia].Add("Rossi Claudio", new());
            universita[CorsoLaurea.Economia].Add("Ferrari Andrea", new());
            universita[CorsoLaurea.Economia].Add("Romano Luca", new());
            universita[CorsoLaurea.Economia].Add("Marino Marco", new());
            universita[CorsoLaurea.Economia].Add("Costa Federico", new());
            universita[CorsoLaurea.Economia].Add("Gallo Francesco", new());
            universita[CorsoLaurea.Economia].Add("Barbieri Felice", new());
            universita[CorsoLaurea.Economia].Add("Marchetti Michael", new());

            universita[CorsoLaurea.Chimica].Add("Costa Federico", new());
            universita[CorsoLaurea.Chimica].Add("Gallo Francesco", new());
            universita[CorsoLaurea.Chimica].Add("Barbieri Felice", new());
            universita[CorsoLaurea.Chimica].Add("Marchetti Michael", new());

            universita[CorsoLaurea.Informatica].Add("Ferrari Andrea", new());
            universita[CorsoLaurea.Informatica].Add("Romano Luca", new());
            universita[CorsoLaurea.Informatica].Add("Marino Marco", new());

            universita[CorsoLaurea.Economia]["Farella Vincenzo"].Add(EsameLaurea.Fisica1, 28);
            universita[CorsoLaurea.Economia]["Farella Vincenzo"].Add(EsameLaurea.Fisica2, 29);
            universita[CorsoLaurea.Economia]["Farella Vincenzo"].Add(EsameLaurea.AnalisiMatematica1, 25);

            universita[CorsoLaurea.Economia]["Rossi Claudio"].Add(EsameLaurea.Fisica1, 23);
            universita[CorsoLaurea.Economia]["Rossi Claudio"].Add(EsameLaurea.Fisica2, 24);

            universita[CorsoLaurea.Economia]["Romano Luca"].Add(EsameLaurea.TeoriaSegnali, 19);
            universita[CorsoLaurea.Economia]["Costa Federico"].Add(EsameLaurea.Elettronica1, 21);

            foreach (var corsolaurea in universita)
                foreach (var matricola in corsolaurea.Value)
                    foreach (var esame in matricola.Value)
                        Console.WriteLine($"{corsolaurea.Key}, {matricola.Key}, {esame.Key}, {esame.Value}");

            #endregion

            Console.ReadKey();
        }
    }
}
