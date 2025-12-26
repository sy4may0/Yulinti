using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusPuellaeCorporisQuiesAdIncumbo : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.Quies;
        public IDPuellaeStatusCorporis IdStatusProximus => IDPuellaeStatusCorporis.Incumbo;
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            return CondicioPuellaeInput.EstIncumbo(contextusOstiorum, contextusResFluida);
        }
    }
}

