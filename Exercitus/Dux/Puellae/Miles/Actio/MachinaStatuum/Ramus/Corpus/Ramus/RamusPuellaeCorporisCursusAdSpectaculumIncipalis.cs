using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal sealed class RamusPuellaeCorporisCursusAdSpectaculumIncipalis : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.Cursus;
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