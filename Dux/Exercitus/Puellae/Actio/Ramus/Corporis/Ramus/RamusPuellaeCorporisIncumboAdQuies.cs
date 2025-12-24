using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusPuellaeCorporisIncumboAdQuies : IRamusPuellae {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.Incumbo;
        public IDPuellaeStatusCorporis IdStatusProximus => IDPuellaeStatusCorporis.Quies;
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            return !CondicioPuellaeInput.EstIncumbo(contextusOstiorum, contextusResFluida);
        }
    }
}

