using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamusPuellaeCorporisCursusAdAmbulatio : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.Cursus;
        public IDPuellaeStatusCorporis IdStatusProximus => IDPuellaeStatusCorporis.Ambulatio;
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

