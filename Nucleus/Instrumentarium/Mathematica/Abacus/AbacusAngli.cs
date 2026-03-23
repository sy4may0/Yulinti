using System;
using System.Numerics;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Nucleus.Instrumentarium {
    public sealed class AbacusAngli {
        private readonly float _angulusMaximusRad;
        private readonly float _angulusMinimusRad;
        private readonly float _angulusMediusRad;
        private readonly float _praeruptioAnguli;
        private readonly ITabulaLUT01<float> _tabulaLUT;

        private static readonly TabulaLUTAcos _tabulaLUTAcos = 
            new TabulaLUTAcos(ConstansAbacus.LongitudoLUTAccuratus);

        public AbacusAngli(
            float angulusMaximusRad,
            float angulusMinimusRad,
            float angulusMediusRad,
            float praeruptioAnguli,
            ITabulaLUT01<float> tabulaLUT = null
        ) {
            if (angulusMinimusRad >= angulusMediusRad ||
                angulusMediusRad >= angulusMaximusRad) {
                Carnifex.Intermissio(LogTextus.AbacusAngli_ABACUSANGLI_INVALID_ANGULUS);
            }
            // 本来なら-πまでが有効範囲だが、dotでcosを取る前提のため、0~πの範囲とする。
            if (angulusMaximusRad > MathF.PI || angulusMinimusRad < 0f) {
                Carnifex.Intermissio(LogTextus.AbacusAngli_ABACUSANGLI_INVALID_ANGULUS);
            }
            if (praeruptioAnguli <= 0f) {
                Carnifex.Intermissio(LogTextus.AbacusAngli_ABACUSANGLI_INVALID_PRAERUPTIO_ANGULI);
            }

            _angulusMaximusRad = angulusMaximusRad;
            _angulusMinimusRad = angulusMinimusRad;
            _angulusMediusRad = angulusMediusRad;
            _praeruptioAnguli = praeruptioAnguli;
            _tabulaLUT = tabulaLUT;

            if (_tabulaLUT == null) {
                float ratioMedius = Mathematica.InverseLerp01(
                    _angulusMinimusRad, _angulusMaximusRad, _angulusMediusRad
                );
                _tabulaLUT = new TabulaLUTSigmoid(
                    _praeruptioAnguli, ratioMedius, ConstansAbacus.LongitudoLUT
                );
            }
        }

        public float ComputareRatio(float angulusRad) {
            if (angulusRad <= _angulusMinimusRad) return 0f;
            if (angulusRad >= _angulusMaximusRad) return 1f;
            float ratio = Mathematica.InverseLerp01(
                _angulusMinimusRad, _angulusMaximusRad, angulusRad
            );
            return _tabulaLUT[ratio];
        }

        public float ComputareRatioInversus(float angulusRad) {
            return 1f - ComputareRatio(angulusRad);
        }

        public float ComputareRatioCos(float cos) {
            cos = Mathematica.Clamp(cos, -1f, 1f);
            float rad = _tabulaLUTAcos[cos];
            return ComputareRatio(rad);
        }

        public float ComputareRatioCosInversus(float cos) {
            return 1f - ComputareRatioCos(cos);
        }

        public float ComputareRatioVectorialis(Vector3 directio0, Vector3 directio1) {
            float dot = Mathematica.Clamp(
                Vector3.Dot(directio0, directio1), -1f, 1f
            );
            return ComputareRatioCos(dot);
        }

        public float ComputareRatioVectorialisInversus(Vector3 directio0, Vector3 directio1) {
            float dot = Mathematica.Clamp(
                Vector3.Dot(directio0, directio1), -1f, 1f
            );
            return ComputareRatioCosInversus(dot);
        }
    }
}