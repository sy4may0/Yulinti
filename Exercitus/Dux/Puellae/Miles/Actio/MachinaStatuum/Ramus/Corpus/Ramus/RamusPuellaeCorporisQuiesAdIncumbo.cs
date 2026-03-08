using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class RamusPuellaeCorporisQuiesAdIncumbo : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.Quies;
        public IDPuellaeStatusCorporis IdStatusProximus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return IDPuellaeStatusCorporis.Incumbo;
        }
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return CondicioPuellaeInput.EstIncumbo(contextusOstiorum, resFluida);
        }
    }
}

