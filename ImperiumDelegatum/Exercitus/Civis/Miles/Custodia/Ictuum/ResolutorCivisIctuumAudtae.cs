using Yulinti.Nucleus.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // TODO: Custodiaの再構成が終わったら、01レシオ出力に変更し、メソッド名もRatioAuditae/RatioVisaeに変更する
    internal sealed class ResolutorCivisIctuumAuditae {
        private readonly IConfiguratioCivisCustodiaeIctuum _configuratioCivisCustodiae;
        private readonly IOstiumCivisLegibile _civis;
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IResFluidaPuellaeLegibile _resFPuellae;
        private readonly AbacusDistantiae _abacusDistantiae;

        private readonly IResFluidaCivisCustodiaeLegibile _resFCustodiae;

        public ResolutorCivisIctuumAuditae(
            IConfiguratioCivisCustodiaeIctuum configuratioCivisCustodiae,
            IOstiumCivisLegibile civis,
            IOstiumCarrusCivis carrus,
            IResFluidaPuellaeLegibile resFPuellae,
            IResFluidaCivisCustodiaeLegibile resFCustodiae
        ) {
            _configuratioCivisCustodiae = configuratioCivisCustodiae;
            _civis = civis;
            _carrus = carrus;
            _resFPuellae = resFPuellae;
            _resFCustodiae = resFCustodiae;

            _abacusDistantiae = new AbacusDistantiae(
                1.0f,
                0.0f,
                _configuratioCivisCustodiae.DistantiaAuditaeMedius,
                _configuratioCivisCustodiae.PraeruptioDistantiaAuditaeSoni
            );
        }

        public void Initare(int idCivis) {
            // ResFluidaCivisCustodiaeの初期化はExecutorCivisCustodiaeが行う。
        }

        // 音量による最大距離を計算する。SoniMaxima/SoniMin間で線形補完する。
        private float ComputareDistantiaSoni(
            float sonus // 0~1補正値
        ) {
            float max = _configuratioCivisCustodiae.DistantiaAuditaeSoniMaxima;
            float min = _configuratioCivisCustodiae.DistantiaAuditaeSoniMin;
            return min + (max - min) * sonus;
        }

        private float ComputareRatioDistantia(
            float distantiaMaxima, // ComputareDistantiaSoniで出した最大距離
            float distantia // 現在の距離
        ) {
            float distantiaMin = _configuratioCivisCustodiae.DistantiaAuditaeSoniMin;
            float ratioActualis = Mathematica.InverseLerp01(distantiaMin, distantiaMaxima, distantia);
            return _abacusDistantiae.ComputareRatioInversus(ratioActualis);
        }

        public void Resolvere(int idCivis) {
            // 聴認範囲外の場合は聴認数を0とする。
            if (!_resFCustodiae.EstCustodiaeAuditae(idCivis)) {
                _carrus.PostulareCustodiaeIctuumAuditae(idCivis, 0f);
                return;
            }

            float distantiaPuellae = _resFCustodiae.DistantiaPuellae(idCivis);
            float sonusQuietes = _resFPuellae.Veletudinis.SonusQuietes;
            float sonusMotus = _resFPuellae.Veletudinis.SonusMotus;
            float sonus = Mathematica.Clamp01((sonusQuietes + sonusMotus) / 2f);

            if (sonus <= Numerus.Epsilon) {
                _carrus.PostulareCustodiaeIctuumAuditae(idCivis, 0f);
                return;
            }

            float distantiaMaxima = ComputareDistantiaSoni(sonus);
            float ratioDistantia = ComputareRatioDistantia(distantiaMaxima, distantiaPuellae);

            _carrus.PostulareCustodiaeIctuumAuditae(idCivis, ratioDistantia * sonus);
        }
    }
}
