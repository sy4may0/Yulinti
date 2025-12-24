using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusPuellaeCorporisCursusAdAmbulatio : IRamusPuellae {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.Cursus;
        public IDPuellaeStatusCorporis IdStatusProximus => IDPuellaeStatusCorporis.Ambulatio;
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            return !CondicioPuellaeInput.EstCursus(contextusOstiorum, contextusResFluida) ||
                   !CondicioPuellaeInput.EstMotus(contextusOstiorum, contextusResFluida);
        }
    }
}

