using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Delegates.ATM
{
    public class ContoCorrente : IContoNazionale
    {
        private string _id;
        private float _actualValue;
        public string Id { get { return _id; } set { _id = value; } }
        public Country _country { get; set; }

        public ContoCorrente(string id, float actualValue, Country country)
        {
            Id = id;
            _actualValue = actualValue;
            _id = id;
            _country = country;
        }

        public float ActualValue { get { return _actualValue; } set { _actualValue = value; } }

        public bool Deposito(float _value, Country externalCountry)
        {
            if (CheckCountry(externalCountry))
            {
                ActualValue += _value;
                return true;
            }
            return false;
        }

        public float Interessi(Country externalCountry)
        {
            if (CheckCountry(externalCountry))
                return ActualValue / 100 * 3;
            return -1;
        }

        public bool Prelievo(float _value)
        {
            if (ActualValue >= _value)
            {
                ActualValue -= _value;
                return true;
            }
            return false;
        }

        public float Saldo(Country externalCountry)
        {
            if(CheckCountry(externalCountry))
                return ActualValue;
            return -1;
        }

        public bool CheckCountry(Country externalCountry)
        {
            if (externalCountry == _country)
                return true;
            return false;
        }
    }

    public interface IContoInternazionale
    {
        public bool Prelievo(float _value);
    }

    public interface IContoNazionale : IContoInternazionale
    {
        public bool Deposito(float _value, Country country);
        public float Saldo(Country country);
        public float Interessi(Country country);
    }
}
