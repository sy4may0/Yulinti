using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class RamusPuellaeCorporisCursusAdAmbulatio : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.Cursus;
        public IDPuellaeStatusCorporis IdStatusProximus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return IDPuellaeStatusCorporis.Ambulatio;
        }
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return !CondicioPuellaeInput.EstCursus(contextusOstiorum, resFluida) ||
                   !CondicioPuellaeInput.EstMotus(contextusOstiorum, resFluida) ||
                   CondicioPuellaeVeletudinis.EstExhauritaPatientiae(contextusOstiorum, resFluida);
        }
    }
}

