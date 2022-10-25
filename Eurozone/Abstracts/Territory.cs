using Eurozone.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurozone.Abstracts
{
    public abstract class Territory
    {
        protected int popolazione;
        protected float areaGeografica;
        public string continente;

        public Territory(int _popolazione, float _areaGeografica, string _continente)
        {
            popolazione = _popolazione;
            areaGeografica = _areaGeografica;
            continente = _continente;
        }
    }
}
