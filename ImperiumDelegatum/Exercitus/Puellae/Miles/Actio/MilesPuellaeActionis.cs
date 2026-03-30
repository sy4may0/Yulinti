using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesPuellaeActionis {
        private readonly IConfiguratioPuellaeStatuum _configuratioStatuum;
        private readonly IOstiumCarrusPuellae _carrus;
        private readonly MachinaPuellaeStatusCorporis _machinaStatusCorporis;

        public MilesPuellaeActionis(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IOstiumPuellaeAnimationisLegibile animationis,
            IOstiumCarrusPuellae carrus,
            ContextusStatusPuellaeCorporis contextus,
            ContextusRamusPuellae contextusRamus
        ) {
            _configuratioStatuum = configuratioStatuum;
            _carrus = carrus;
            _machinaStatusCorporis = new MachinaPuellaeStatusCorporis(
                configuratioStatuum,
                animationis,
                carrus,
                contextus,
                contextusRamus
            );
        }

        // [TODO] Nevmeshから外れた時のリカバリがきえちゃった

        public void Initare(
            IResFluidaPuellaeLegibile resFluida
        ) {
            // ベースアニメーションを適用する。
            IDPuellaeAnimationis idAnimationisPraedefinitus = _configuratioStatuum.IdAnimationisPraedefinitus;
            _carrus.PostulareAnimationis(
                IDPuellaeAnimationisStratum.Fundamentum,
                idAnimationisPraedefinitus
            );

            // 初期位置に移動する。
            System.Numerics.Vector3 positioIncipalis = _configuratioStatuum.PositioIncipalis;
            System.Numerics.Quaternion rotatioIncipalis = _configuratioStatuum.RotatioIncipalis;
            _carrus.PostulareNavmeshInitii(
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
