using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurozone
{
    interface UnioneEuropea
    {
        void monetaUnica();
        void costituzioneEuro();
        void EMA();

        bool checkEuroZona();
    }

    interface ONU
    {
        void OMS();
        void FMI();
    }

    interface EuroCentralBank
    {
        void calculateSpread();
    }

    interface CorteEuropea
    {
        void PenaMorte();
    }
}
