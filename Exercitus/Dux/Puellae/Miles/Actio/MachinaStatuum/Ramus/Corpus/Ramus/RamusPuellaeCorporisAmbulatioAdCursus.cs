using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class RamusPuellaeCorporisAmbulatioAdCursus : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.Ambulatio;
        public IDPuellaeStatusCorporis IdStatusProximus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return IDPuellaeStatusCorporis.Cursus;
        }
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return CondicioPuellaeInput.EstCursus(contextusOstiorum, resFluida) && 
                   !CondicioPuellaeVeletudinis.EstExhauritaPatientiae(contextusOstiorum, resFluida);
        }
    }
}

