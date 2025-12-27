using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal interface IMilesPuellaeActionis {
        void OrdinareActionis(
            ContextusPuellaeResFluidaLegibile contextusResFluida
        );
        OrdinatioPuellaeVeletudinis OrdinareVeletudinis(
            ContextusPuellaeResFluidaLegibile contextusResFluida
        );
        void ApplicareActionis(
            ContextusPuellaeResFluidaLegibile contextusResFluida
        );
        void RenovareResFluidaMotus(
            ref ResFluidaPuellaeMotus resFluida
        );
    }
}