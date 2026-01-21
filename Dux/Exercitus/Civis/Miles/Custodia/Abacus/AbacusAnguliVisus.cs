using Yulinti.Nucleus;
using System.Numerics;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class AbacusAnguliVisus {
        private readonly float _angulusMaximaRad;
        private readonly float _angulusMinRad;
        // Acos回避でdotと直接計算するためのcos値
        private readonly float _cosMin; // cos(angulusMaximaRad) - 最大角のcos（最小値）
        private readonly float _cosMax; // cos(angulusMinRad) - 最小角のcos（最大値）
        private readonly float _ratioAnguliMed;
        private readonly SigmoidLUT _sigmoid;
        private readonly SigmoidLUT _sigmoidInversus;

        public AbacusAnguliVisus(
            float angulusMaximaRad,
            float angulusMinRad,
            float angulusMediusRad,
            float praeruptioAnguliVisus
        ) {
            if ( angulusMinRad >= angulusMediusRad ||
                angulusMediusRad >= angulusMaximaRad ) {
                Errorum.Fatal(IDErrorum.ABACUSANGULIVISUS_INVALID_ANGULUS);
            }
            // π範囲内確認
            if (angulusMaximaRad >= MathF.PI ) {
                Errorum.Fatal(IDErrorum.ABACUSANGULIVISUS_INVALID_ANGULUS);
            }
            if (angulusMinRad <= 0f) {
                angulusMinRad = Numerus.Epsilon;
            }

            // ここで逆にするからradMaxはcosMinだぞボケが。死ね。
            _angulusMaximaRad = angulusMaximaRad;
            _angulusMinRad = angulusMinRad;
            _cosMin = MathF.Cos(angulusMaximaRad);
            _cosMax = MathF.Cos(angulusMinRad);
            float cosMed = MathF.Cos(angulusMediusRad);

            _ratioAnguliMed = DuxMath.InverseLerp(_cosMin, _cosMax, cosMed);
            _sigmoid = new SigmoidLUT(praeruptioAnguliVisus, _ratioAnguliMed, ConstansCivis.LongitudoSigmoidAnguliVisus);
            _sigmoidInversus = new SigmoidLUT(praeruptioAnguliVisus, _ratioAnguliMed, ConstansCivis.LongitudoSigmoidAnguliVisus, true);
        }

        public float ComputareRatio(float angulusRad) {
            if (angulusRad <= _angulusMinRad) return 1f;
            if (angulusRad >= _angulusMaximaRad) return 0f;
            float cos = MathF.Cos(angulusRad);
            float ratio = _sigmoid[DuxMath.InverseLerp(_cosMin, _cosMax, cos)];
            return ratio;
        }

        public float ComputareRatioCos(float cos) {
            if (cos >= _cosMax) return 1f; // 角度が最小角以下
            if (cos <= _cosMin) return 0f; // 角度が最大角以上
            float ratio = _sigmoid[DuxMath.InverseLerp(_cosMin, _cosMax, cos)];
            return ratio;
        }

        public float ComputareRatio(Vector3 directio0, Vector3 directio1)
        {
            float dot = DuxMath.Clamp(Vector3.Dot(Vector3.Normalize(directio0), Vector3.Normalize(directio1)), -1f, 1f);
            return ComputareRatioCos(dot);
        }

        public float ComputareRatioInversus(float angulusRad) {
            if (angulusRad <= _angulusMinRad) return 0f;
            if (angulusRad >= _angulusMaximaRad) return 1f;
            float cos = MathF.Cos(angulusRad);
            float ratio = _sigmoidInversus[DuxMath.InverseLerp(_cosMin, _cosMax, cos)];
            return ratio;
        }

        public float ComputareRatioInversusCos(float cos) {
            if (cos >= _cosMax) return 0f; // 角度が最小角以下
            if (cos <= _cosMin) return 1f; // 角度が最大角以上
            float ratio = _sigmoidInversus[DuxMath.InverseLerp(_cosMin, _cosMax, cos)];
            return ratio;
        }

        public float ComputareRatioInversus(Vector3 directio0, Vector3 directio1)
        {
            float dot = DuxMath.Clamp(Vector3.Dot(Vector3.Normalize(directio0), Vector3.Normalize(directio1)), -1f, 1f);
            return ComputareRatioInversusCos(dot);
        }
    }
}
