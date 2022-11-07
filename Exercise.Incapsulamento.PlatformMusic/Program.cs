using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Incapsulamento.PlatformMusic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application Spotify = new Application("Spotify");
            Spotify.Start();
        }

        public static class Utility
        {
            public static string LogInData(string _data)
            {
                Console.Clear();
                Console.WriteLine($"{_data}: ");
                return Console.ReadLine(); 
            }

            public static int CatchCommand()
            {
                int command = 0;
                Console.Clear();
                Console.WriteLine("Inserisci la tua scelta: ");
                Console.WriteLine("0 - Esci dal Programma");
                Console.WriteLine("1 - Visualizza Canzoni");
                Console.WriteLine("2 - Aggiungi Canzone");
                Console.WriteLine("3 - Elimina Canzone");
                Console.WriteLine("4 - Avvia Canzone");
                Console.WriteLine("5 - Pausa Canzone");
                Console.WriteLine("6 - Stop Canzone");

                int.TryParse(Console.ReadLine(), out command);
                return command >= 0 || command <= 6 ? command : -5;
            }

            public static void ErrorCommand()
            {
                Console.WriteLine("Comando non riconosciuto.");
            }

            public static void PressKeyToContinue()
            {
                Console.WriteLine("\nPremi Enter per continuare...");
                Console.ReadKey();
            }

            public static void QuitProgram()
            {
                System.Environment.Exit(0);
            }

            public static string CatchSongData(string data)
            {
                Console.Clear();
                Console.WriteLine($"{data} della Canzone: ");
                return Console.ReadLine();
            }

            public static void CatchAction(bool action)
            {
                Console.Clear();

                if (action)
                    Console.WriteLine("Comando Effettuato con successo.");
                else Console.WriteLine("Comando non Effettuato.");
            }

            public static void LogInProgramIndex(string _application_name)
            {
                Console.Clear();
                Console.WriteLine($"Benvenuto nella schermata di Accesso a {_application_name}\nInserisci qui di seguito i tuoi dati per effettuare l'accesso.");
                PressKeyToContinue();
            }

            public static void IntoProgramIndex(string _application_name)
            {
                Console.Clear();
                Console.WriteLine($"Accesso effettuato a {_application_name}");
                PressKeyToContinue();
            }

            public static void ChangeTitleAppProgram(string _application_name)
            {
                Console.Title = _application_name;
            }

        }
    }
}
