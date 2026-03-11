using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesPuellaeActionis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly MachinaPuellaeStatusCorporis _machinaStatusCorporis;

        public MilesPuellaeActionis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            _contextusOstiorum = contextusOstiorum;
            _machinaStatusCorporis = new MachinaPuellaeStatusCorporis(
                _contextusOstiorum,
                _contextusOstiorum.Configuratio.Statuum
            );
        }

        // [TODO] Nevmeshから外れた時のリカバリがきえちゃった

        public void Initare(
            IResFluidaPuellaeLegibile resFluida
        ) {
            // ベースアニメーションを適用する。
            IConfiguratioPuellaeStatuum configuratioStatuum = _contextusOstiorum.Configuratio.Statuum;
            IDPuellaeAnimationis idAnimationisPraedefinitus = configuratioStatuum.IdAnimationisPraedefinitus;
            _contextusOstiorum.Carrus.PostulareAnimationis(
                IDPuellaeAnimationisStratum.Fundamentum,
                idAnimationisPraedefinitus
            );

            // 初期位置に移動する。
            System.Numerics.Vector3 positioIncipalis = configuratioStatuum.PositioIncipalis;
            System.Numerics.Quaternion rotatioIncipalis = configuratioStatuum.RotatioIncipalis;
            _contextusOstiorum.Carrus.PostulareNavmeshInitii(
                positioIncipalis,
                rotatioIncipalis
            );
        }

        // こっちを先に呼ぶ。
        public void MutareStatus(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _machinaStatusCorporis.Mutare(resFluida);
            _machinaStatusCorporis.ConfirmareMutare(resFluida);
        }

        // こっちは後に呼ぶ。
        public void Ordinare(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _machinaStatusCorporis.Ordinare(resFluida);
        }
    }
}
