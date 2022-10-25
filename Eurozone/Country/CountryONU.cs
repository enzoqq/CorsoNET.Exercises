using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurozone.Country
{
    internal class CountryONU : Country, ONU, CorteEuropea
    {

        public CountryONU(int popolazione, float areaGeografica, string continente, string nome, string costituzione, string bandiera, string moneta, string linguaUfficiale, float pil, bool penaMorte) : base(popolazione, areaGeografica, continente, nome, costituzione, bandiera, moneta, linguaUfficiale, pil, penaMorte)
        {

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
            if (this.penaMorte)
                Console.WriteLine("Non rispetta i diritti umani");
            else Console.WriteLine("Rispetta i diritti umani");
        }
    }
}
