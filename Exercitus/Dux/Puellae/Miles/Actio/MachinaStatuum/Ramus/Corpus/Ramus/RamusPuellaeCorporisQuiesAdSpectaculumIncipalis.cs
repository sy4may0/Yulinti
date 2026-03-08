using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class RamusPuellaeCorporisQuiesAdSpectaculumIncipalis : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.Quies;
        public IDPuellaeStatusCorporis IdStatusProximus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return IDPuellaeStatusCorporis.SpectaculumIncipalis;
        }
        public int Prioritas => 900;
        public bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return CondicioPuellaeInput.EstSpectaculumCorporis(contextusOstiorum, resFluida);
        }
    }
}