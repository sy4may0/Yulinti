using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesCivisGenerationis  {
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IConfiguratioCivisGenerationis _configuratioCivisGenerationis;
        private readonly IOstiumCivisLegibile _ostiumCivisLegibile;
        private readonly HorologiumTemere _horologiumTemere;

        public MilesCivisGenerationis(
            IConfiguratioCivisGenerationis configuratioCivisGenerationis,
            IOstiumCivisLegibile ostiumCivisLegibile,
            IOstiumTemporisLegibile temporis,
            IOstiumCarrusCivis carrus,
            Random random
        ) {
            _configuratioCivisGenerationis = configuratioCivisGenerationis;
            _ostiumCivisLegibile = ostiumCivisLegibile;
            _temporis = temporis;
            _carrus = carrus;
            _horologiumTemere = new HorologiumTemere(
                _configuratioCivisGenerationis.IntervallumMinimus,
                _configuratioCivisGenerationis.IntervallumMaximus,
                random
            );

            _horologiumTemere.Purgere();
            _horologiumTemere.Activare();
        }

        public void Ordinare() {
            int numerusCivisActivum = _ostiumCivisLegibile.LongitudoActivum;

            // 最大数を超えたら停止
            if (numerusCivisActivum >= _configuratioCivisGenerationis.PopulatioMaxima) {
                _horologiumTemere.Deactivare();
                return;
            } else {
                if (!_horologiumTemere.EstActivum) {
                    _horologiumTemere.Activare();
                }
            }

            // 初期生成
            if (numerusCivisActivum < _configuratioCivisGenerationis.PopulatioInitialis) {
                int id = _ostiumCivisLegibile.LegoIDIntactus();
                _carrus.PostulareMortis(
                    id,
                    SpeciesOrdinationisCivisMortis.Incarnare
                );
                return;
            }

            // ランダムスポーン
            if (_horologiumTemere.EstExhaurita(_temporis.Intervallum)) {
                int id = _ostiumCivisLegibile.LegoIDIntactus();
                _carrus.PostulareMortis(
                    id,
                    SpeciesOrdinationisCivisMortis.Incarnare
                );
                return;
            }
        }

        public void Liberare() {
            _horologiumTemere.Purgere();
        }
    }
}