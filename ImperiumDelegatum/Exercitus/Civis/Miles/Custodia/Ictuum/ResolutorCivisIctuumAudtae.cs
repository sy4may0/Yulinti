using Yulinti.Nucleus.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // TODO: Custodiaの再構成が終わったら、01レシオ出力に変更し、メソッド名もRatioAuditae/RatioVisaeに変更する
    internal sealed class ResolutorCivisIctuumAuditae : IResolutorCivisIctuumAuditae {
        private readonly IConfiguratioCivisCustodiae _configuratioCivisCustodiae;
        private readonly IOstiumCivisLegibile _civis;
        private readonly IResFluidaPuellaeLegibile _resFPuellae;
        private readonly AbacusDistantiae _abacusDistantiae;

        private readonly IResolutorCivisDistantia _resolutorCivisDistantia;

        private readonly float[] _auditaIctuum;

        public ResolutorCivisIctuumAuditae(
            IConfiguratioCivisCustodiae configuratioCivisCustodiae,
            IOstiumCivisLegibile civis,
            IResFluidaPuellaeLegibile resFPuellae,
            IResolutorCivisDistantia resolutorCivisDistantia
        ) {
            _configuratioCivisCustodiae = configuratioCivisCustodiae;
            _civis = civis;
            _resFPuellae = resFPuellae;
            _resolutorCivisDistantia = resolutorCivisDistantia;

            _abacusDistantiae = new AbacusDistantiae(
                1.0f,
                0.0f,
                _configuratioCivisCustodiae.DistantiaAuditaeMedius,
                _configuratioCivisCustodiae.PraeruptioDistantiaAuditaeSoni
            );

            _auditaIctuum = new float[_civis.Longitudo];
            for (int i = 0; i < _civis.Longitudo; i++) {
                _auditaIctuum[i] = 0f;
            }
        }

        public float Audita(int idCivis) => _auditaIctuum[idCivis];
        public bool EstAudita(int idCivis) => _auditaIctuum[idCivis] > Numerus.Epsilon;

        public void Initare(int idCivis) {
            _auditaIctuum[idCivis] = 0f;
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
            if (!_resolutorCivisDistantia.EstCustodiaeAuditae(idCivis)) {
                _auditaIctuum[idCivis] = 0f;
                return;
            }

            float distantiaPuellae = _resolutorCivisDistantia.DistantiaPuellae(idCivis);
            float sonusQuietes = _resFPuellae.Veletudinis.SonusQuietes;
            float sonusMotus = _resFPuellae.Veletudinis.SonusMotus;
            float sonus = Mathematica.Clamp01((sonusQuietes + sonusMotus) / 2f);

            if (sonus <= Numerus.Epsilon) {
                _auditaIctuum[idCivis] = 0f;
                return;
            }

            float distantiaMaxima = ComputareDistantiaSoni(sonus);
            float ratioDistantia = ComputareRatioDistantia(distantiaMaxima, distantiaPuellae);

            _auditaIctuum[idCivis] = ratioDistantia * sonus;
        }
    }
}