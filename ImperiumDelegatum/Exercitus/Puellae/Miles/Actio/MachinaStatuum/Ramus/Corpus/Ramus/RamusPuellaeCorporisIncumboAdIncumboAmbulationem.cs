using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class RamusPuellaeCorporisIncumboAdIncumboAmbulationem : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.Incumbo;
        public IDPuellaeStatusCorporis IdStatusProximus(
            ContextusRamusPuellae contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return IDPuellaeStatusCorporis.IncumboAmbulationem;
        }
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusRamusPuellae contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return CondicioPuellaeInput.EstIncumbo(contextusOstiorum, resFluida) &&
                   CondicioPuellaeInput.EstMotus(contextusOstiorum, resFluida);
        }
    }
}

