using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class RamusPuellaeCorporisSpectaculumIncipalisAdSpectaculum : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.SpectaculumIncipalis;
        // 現在選択されているSpectaculumを返す。ResFluidaにSpectaculumIDが設定されるためそれを見る。
        public IDPuellaeStatusCorporis IdStatusProximus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return CondicioPuellaeSpectaculi.ResolvereSpectaculum(contextusOstiorum, resFluida);
        }
        public int Prioritas => 1000;
        public bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return CondicioPuellaeVelocitatis.EstVelocitatisQuietes(contextusOstiorum, resFluida);
        }
    }
}