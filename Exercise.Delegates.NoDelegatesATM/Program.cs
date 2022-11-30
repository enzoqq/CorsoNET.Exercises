using System;

namespace Exercise.Delegates.ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATM _atmItaly = new ATM("ATM1", Country.IT);
            ContoCorrente _cc1 = new ContoCorrente("CC1", 3000, Country.FR);

            _atmItaly.Prelievo(300, _cc1);
            _atmItaly.Saldo(_cc1);
            _atmItaly.Deposito(69, _cc1);
        }




    }


}