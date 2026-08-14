using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesCivisGenerationis  {
        private readonly IOstiumCarrusCivisManifestationis _carrus;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IConfiguratioCivisGenerationis _configuratioCivisGenerationis;
        private readonly IOstiumCivisLegibile _ostiumCivisLegibile;
        private readonly HorologiumTemere _horologiumTemere;

        private readonly SelectorCivisPersonae _selectorCivisPersonae;

        public MilesCivisGenerationis(
            IConfiguratioCivisGenerationis configuratioCivisGenerationis,
            IConfiguratioCiviumPersonarum configuratioCiviumPersonarum,
            IOstiumCivisLegibile ostiumCivisLegibile,
            IOstiumTemporisLegibile temporis,
            IOstiumCarrusCivisManifestationis carrus,
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

            _selectorCivisPersonae = new SelectorCivisPersonae(
                configuratioCiviumPersonarum.Configurationes,
                random
            );

            _horologiumTemere.Purgere();
            _horologiumTemere.Activare();
        }

        // !! フレーム毎の生成数 !!
        // 現在の実装では1フレームにつき1NPCの生成にするように。
        // numerusManifestationesがずれたりすると大変面倒だしそもそもAnchora枠がない。
        public void Ordinare() {
            int numerusManifestationes = _ostiumCivisLegibile.LongitudoManifestationes;

            // 最大数を超えたら停止
            if (numerusManifestationes >= _configuratioCivisGenerationis.PopulatioMaxima) {
                _horologiumTemere.Deactivare();
                return;
            } else {
                if (!_horologiumTemere.EstActivum) {
                    _horologiumTemere.Activare();
                }
            }

            // 初期生成
            if (numerusManifestationes < _configuratioCivisGenerationis.PopulatioInitialis) {
                _carrus.PostulareManifestationis(
                    _selectorCivisPersonae.Selectare()
                );
                return;
            }

            // ランダムスポーン
            if (_horologiumTemere.EstExhaurita(_temporis.Intervallum)) {
                _carrus.PostulareManifestationis(
                    _selectorCivisPersonae.Selectare()
                );
                return;
            }
        }

        public void Liberare() {
            _horologiumTemere.Purgere();
        }
    }
}
