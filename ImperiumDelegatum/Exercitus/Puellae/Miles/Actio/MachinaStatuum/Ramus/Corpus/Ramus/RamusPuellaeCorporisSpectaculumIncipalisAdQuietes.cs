using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class RamusPuellaeCorporisSpectaculumIncipalisAdQuietes : IRamusPuellaeCorporis {
        public IDPuellaeStatusCorporis IdStatusActualis => IDPuellaeStatusCorporis.SpectaculumIncipalis;
        public IDPuellaeStatusCorporis IdStatusProximus(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            return IDPuellaeStatusCorporis.Quies;
        }
        public int Prioritas => 900;
        public bool Condicio(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IResFluidaPuellaeLegibile resFluida
        ) {
            // 停止状態でないならfalseを返す。
            if (!CondicioPuellaeVelocitatis.EstVelocitatisQuietes(contextusOstiorum, resFluida)) {
                return false;
            }

            // Spectaculumが選択されていない場合、trueを返す。(ここは選択無しをフォローするための遷移。)
            if (!CondicioPuellaeSpectaculi.EstSpectaculumCorporis(contextusOstiorum, resFluida)) {
                return true;
            }

            // それ以外はfalseを返す。
            return false;
        }
    }
}