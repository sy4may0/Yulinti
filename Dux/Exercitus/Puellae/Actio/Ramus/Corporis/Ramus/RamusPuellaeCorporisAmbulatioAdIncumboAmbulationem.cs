using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusPuellaeCorporisAmbulatioAdIncumboAmbulationem : IRamusPuellae {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.Ambulatio;
        public IDPuellaeStatusCorporis IdStatusProximus => IDPuellaeStatusCorporis.IncumboAmbulationem;
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            return CondicioPuellaeInput.EstIncumbo(contextusOstiorum, contextusResFluida);
        }
    }
}

