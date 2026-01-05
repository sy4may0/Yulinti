using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusPuellaeCorporisIncumboAmbulationemAdAmbulatio : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.IncumboAmbulationem;
        public IDPuellaeStatusCorporis IdStatusProximus => IDPuellaeStatusCorporis.Ambulatio;
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return !CondicioPuellaeInput.EstIncumbo(contextusOstiorum, resFluida);
        }
    }
}

