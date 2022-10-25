using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurozone.Country
{
    internal class CountryEU_ONU : Country, UnioneEuropea, ONU, CorteEuropea, EuroCentralBank
    {
        public CountryEU_ONU(int popolazione, float areaGeografica, string continente, string nome, string costituzione, string bandiera, string moneta, string linguaUfficiale, float pil, bool penaMorte) : base(popolazione, areaGeografica, continente, nome, costituzione, bandiera, moneta, linguaUfficiale, pil, penaMorte)
        {

        }
        public void monetaUnica()
        {
            if (this.moneta.ToLower() == "euro")
                Console.WriteLine("E' un paese con Moneta Unica");
            else Console.WriteLine("Non è un paese con Moneta Unica");
        }

        public void costituzioneEuro()
        {
            Console.WriteLine("Aderisce alla Costituzione Europea");
        }

        public void EMA()
        {
            Console.WriteLine("Aderisce all' Agenzia Europea per i Medicinali");
        }

        public bool checkEuroZona()
        {
            if (this.moneta.ToLower().Contains("euro"))
                return true;
            else return false;
        }

        public void OMS()
        {
            Console.WriteLine("Aderisce all' Organizzazione Mondiale della Sanità");
        }

        public void FMI()
        {
            Console.WriteLine("Aderisce al Fondo Monetario Internazionale");
        }
        public void PenaMorte()
        {
            if(this.penaMorte)
                Console.WriteLine("Non rispetta i diritti umani");
            else Console.WriteLine("Rispetta i diritti umani");
        }

        public void calculateSpread()
        {
            Random random = new Random();

            if (checkEuroZona())
                Console.WriteLine("SPREAD: " + (this.pil + random.Next(100, 300)));
            else Console.WriteLine(this.nome + " non appartiene all' Eurozona.");
        }
    }
}
