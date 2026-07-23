using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesPuellaeVeletudinisAnomaliae {
        private readonly IConfiguratioPuellaeVeletudinis _configuratio;
        private readonly IOstiumCarrusPuellae _carrus;

        public MilesPuellaeVeletudinisAnomaliae(
            IConfiguratioPuellaeVeletudinis configuratio,
            IOstiumCarrusPuellae carrus
        ) {
            _configuratio = configuratio;
            _carrus = carrus;
        }

        public void Ordinare() {
            // 基本値を設定
            _carrus.PostulareVeletudinis(
                dtAnomalia: _configuratio.AnomaliaBasis,
                dtAnomaliaNudus: _configuratio.AnomaliaNudusBasis
            );
        }
    }
}