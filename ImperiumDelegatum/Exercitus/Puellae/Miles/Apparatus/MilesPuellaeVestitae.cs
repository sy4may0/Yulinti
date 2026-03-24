using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesPuellaeVestitae {
        private readonly IOstiumCarrusPuellae _carrus;

        public MilesPuellaeVestitae(
            IOstiumCarrusPuellae carrus
        ) {
            _carrus = carrus;
        }

        public void Initare() {
            // 何もしない。
            _carrus.PostulareVeletudinisNudi(
                false,
                false
            );
        }

        public void Ordinare(IResFluidaPuellaeLegibile resFluida) {
            // ここで服装に伴うVeletudinisを適用する。
            // - Claritas
            // - EstNudusAnterior
            // - EstNudusPosterior

            // 服装システムは未作成のため、現状はClalitas+0.25, 前面露出状態とする。
            _carrus.PostulareVeletudinisNudi(
                estNudusAnterior: true,
                estNudusPosterior: false
            );
            _carrus.PostulareVeletudinis(
                dtClaritas: 0.25f
            );
        }
    }
}