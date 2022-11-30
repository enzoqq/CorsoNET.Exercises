using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Delegates.ATM
{
    public class ATM
    {
        private string _id;
        public string Id { get { return _id; } set { _id = value; } }
        public Country _country { get; set; }

        public ATM(string id, Country country)
        {
            _id = id;
            _country = country;
        }

        public void Deposito(float _value, ContoCorrente _conto)
        {
            Utility.LogAction("Deposito", _conto.Deposito(_value, _country));
        }

        public void Interessi(ContoCorrente _conto)
        {
            Utility.LogValue("Interessi", _conto.Interessi(_country));
        }

        public void Prelievo(float _value, ContoCorrente _conto)
        {
            Utility.LogAction("Prelievo", _conto.Prelievo(_value, _country));
        }

        public void Saldo(ContoCorrente _conto)
        {
            Utility.LogValue("Saldo", _conto.Saldo(_country));
        }
    }

    public enum Country
    {
        IT,
        FR
    }

    public static class Utility
    {
        public static void LogValue(string _action, float _value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{_action} {_value}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LogAction(string _action, bool _value)
        {
            if (_value)
                Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"{_action} {_value}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
