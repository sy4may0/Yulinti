using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResolutorCivisIctuumAuditae : IResolutorCivisIctuumAuditae {
        private readonly ContextusCivisOstiorumLegibile _contextus;
        private readonly AbacusDistantiaeVisus _abacusDistantiae;

        private readonly IResolutorCivisDistantia _resolutorCivisDistantia;

        private readonly float[] _auditaIctuum;

        public ResolutorCivisIctuumAuditae(
            ContextusCivisOstiorumLegibile contextus,
            IResolutorCivisDistantia resolutorCivisDistantia
        ) {
            _contextus = contextus;
            _resolutorCivisDistantia = resolutorCivisDistantia;

            _abacusDistantiae = new AbacusDistantiaeVisus(
                distantiaMaxima: 1.0f,
                distantiaMin: 0.0f,
                distantiaMedius: contextus.Configuratio.Custodiae.DistantiaAuditaeMedius,
                praeruptioDistantiaeVisus: contextus.Configuratio.Custodiae.PraeruptioDistantiaAuditaeSoni
            );

            _auditaIctuum = new float[contextus.Civis.Longitudo];
            for (int i = 0; i < contextus.Civis.Longitudo; i++) {
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
            float max = _contextus.Configuratio.Custodiae.DistantiaAuditaeSoniMaxima;
            float min = _contextus.Configuratio.Custodiae.DistantiaAuditaeSoniMin;
            return min + (max - min) * sonus;
        }

        private float ComputareRatioDistantia(
            float distantiaMaxima, // ComputareDistantiaSoniで出した最大距離
            float distantia // 現在の距離
        ) {
            float distantiaMin = _contextus.Configuratio.Custodiae.DistantiaAuditaeSoniMin;
            float ratioActualis = DuxMath.InverseLerp(distantiaMin, distantiaMaxima, distantia);
            return _abacusDistantiae.ComputareRatioInversus(ratioActualis);
        }

        public void Resolvere(
            int idCivis, IResFluidaCivisLegibile resFluida
        ) {
            // 聴認範囲外の場合は聴認数を0とする。
            if (!_resolutorCivisDistantia.EstCustodiaeAuditae(idCivis)) {
                _auditaIctuum[idCivis] = 0f;
                return;
            }

            float distantiaPuellae = _resolutorCivisDistantia.DistantiaPuellae(idCivis);
            float sonusQuietes = _contextus.ResFPuellae.Veletudinis.SonusQuietes;
            float sonusMotus = _contextus.ResFPuellae.Veletudinis.SonusMotus;
            float sonus = DuxMath.Clamp((sonusQuietes + sonusMotus) / 2f, 0f, 1f);

            float distantiaMaxima = ComputareDistantiaSoni(sonus);
            float ratioDistantia = ComputareRatioDistantia(distantiaMaxima, distantiaPuellae);

            float auditus = resFluida.Veletudinis.Auditus(idCivis);

            _auditaIctuum[idCivis] = ratioDistantia * auditus;
        }
    }
}