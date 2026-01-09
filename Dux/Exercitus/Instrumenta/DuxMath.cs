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
            float x, float center, float steepness
        ) {
            return 1f / (1f + MathF.Exp(-steepness * (x - center)));
        }

        // シグモイド曲線。左側の尾が長い形状。
        // y0, y1はSigmoid()で事前にx=0, 1で計算してキャッシュするように。
        public static float SigmoidCaudaSinistra(
            float x, float center, float steepness,
            float y0, float y1
        ) {
            // 0~1にクランプ
            x = Clamp(x, 0f, 1f);

            float y = 1f / (1f + MathF.Exp(-steepness * (x - center)));

            return InverseLeap(y0, y1, y);
        }

        public static float InverseLeap(float y0, float y1, float y) {
            if (MathF.Abs(y1 - y0) < Numerus.Epsilon) return 0f;
            return (y - y0) / (y1 - y0);
        }
    }
}