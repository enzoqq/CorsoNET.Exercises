using System;

namespace Exercise.Delegates.ATM
{
    public delegate bool BankSystemPrelievo(float _value);
    public delegate bool BankSystemDeposito(float _value, Country externalCountry);
    public delegate float BankSystemInteressi(Country externalCountry);
    public delegate float BankSystemSaldo(Country externalCountry);

    internal class Program
    {
        static void Main(string[] args)
        {
            ATM _atmItaly = new ATM("ATM1", Country.IT);
            ContoCorrente _cc1 = new ContoCorrente("CC1", 3000, Country.IT);

            BankSystemSaldo _bankSystemSaldo = _cc1.Saldo;
            _atmItaly.Saldo(_bankSystemSaldo);

            BankSystemPrelievo _bankSystemPrelievo = _cc1.Prelievo;
            _atmItaly.Prelievo(_bankSystemPrelievo, 200);

            BankSystemInteressi _bankSystemInteressi = _cc1.Interessi;
            _atmItaly.Interessi(_bankSystemInteressi);

            BankSystemDeposito _bankSystemDeposito = _cc1.Deposito;
            _atmItaly.Deposito(_bankSystemDeposito, 299);

            _atmItaly._country = Country.IT;
            _atmItaly.Prelievo(_bankSystemPrelievo, 299000);
        }

    }


}