using System;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal static class DuxMath {
        public static float Clamp(float value, float min, float max) {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static int Clamp(int value, int min, int max) {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static float Sigmoid(
            float x, float centrum, float praeruptio
        ) {
            return 1f / (1f + MathF.Exp(-praeruptio * (x - centrum)));
        }

        // シグモイド曲線。左側の尾が長い形状。
        // y0, y1はSigmoid()で事前にx=0, 1で計算してキャッシュするように。
        public static float SigmoidCaudaSinistra(
            float x, float centrum, float praeruptio,
            float y0, float y1
        ) {
            // 0~1にクランプ
            x = Clamp(x, 0f, 1f);

            float y = 1f / (1f + MathF.Exp(-praeruptio * (x - centrum)));

            return InverseLerp(y0, y1, y);
        }

        // 0~1にクランプしないLerp
        public static float NLerp(float y0, float y1, float t) {
            return y0 + (y1 - y0) * t;
        }

        // ClampするLerp
        public static float Lerp(float y0, float y1, float t) {
            return Clamp(y0 + (y1 - y0) * t, 0f, 1f);
        }

        // 0~1にクランプしないInverseLerp
        public static float NInverseLerp(float y0, float y1, float y) {
            if (MathF.Abs(y1 - y0) < Numerus.Epsilon) return 0f;
            return (y - y0) / (y1 - y0);
        }

        // ClampするInverseLerp
        public static float InverseLerp(float y0, float y1, float y) {
            if (MathF.Abs(y1 - y0) < Numerus.Epsilon) return 0f;
            return Clamp((y - y0) / (y1 - y0), 0f, 1f);
        }

        public static float Deg2Rad(float deg) {
            return deg * Numerus.Deg2Rad;
        }

        public static float Rad2Deg(float rad) {
            return rad * Numerus.Rad2Deg;
        }
    }

    internal sealed class SigmoidLUT {
        private readonly float[] _lut;
        private readonly float _praeruptio;
        private readonly float _centrum;
        private readonly float y0;
        private readonly float y1;

        public SigmoidLUT(
            float praeruptio,
            float centrum,
            int longitudo,
            // Y反転フラグ
            bool inversus = false
        ) {
            _praeruptio = praeruptio;
            _centrum = centrum;

            y0 = DuxMath.Sigmoid(0f, centrum, praeruptio);
            y1 = DuxMath.Sigmoid(1f, centrum, praeruptio);

            _lut = new float[longitudo];

            for (int i = 0; i < longitudo; i++) {
                _lut[i] = DuxMath.SigmoidCaudaSinistra(i / (longitudo - 1f), centrum, praeruptio, y0, y1);
            }

            if (inversus) {
                for (int i = 0; i < longitudo; i++) {
                    _lut[i] = 1f - _lut[i];
                }
            }
        }

        public float[] LUT => _lut;

        public float this[float x] {
            get {
                // 入力を0~1にクランプ
                x = DuxMath.Clamp(x, 0f, 1f);

                // 最も近いインデックスを取得
                int index = (int)MathF.Round(x * (_lut.Length - 1));
                return _lut[index];
            }
        }
    }
}