using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal interface IResolutorPuellaeRamorum {
        IDPuellaeStatusCorporis Resolvere(
            IDPuellaeStatusCorporis idStatusActualis,
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida
        );
    }
}