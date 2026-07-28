using System;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Nucleus.Instrumentarium {
    public static class Mathematica {
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

        public static float Clamp01(float value) {
            if (value < 0f) return 0f;
            if (value > 1f) return 1f;
            return value;
        }

        public static int Clamp01(int value) {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }

        public static float Lerp(float min, float max, float t) {
            return min + (max - min) * t;
        }

        public static float Lerp01(float min, float max, float t) {
            return Lerp(min, max, Clamp01(t));
        }

        public static float InverseLerp(float min, float max, float v) {
            if (MathF.Abs(max - min) < Numerus.Epsilon) return 0f;
            return (v - min) / (max - min);
        }

        public static float InverseLerp01(float min, float max, float v) {
            if (MathF.Abs(max - min) < Numerus.Epsilon) return 0f;
            return Clamp01((v - min) / (max - min));
        }

        public static float Round(float value) {
            return (float)Math.Round(value);
        }

        public static float Deg2Rad(float deg) {
            return deg * Numerus.Deg2Rad;
        }

        public static float Rad2Deg(float rad) {
            return rad * Numerus.Rad2Deg;
        }

        public static float SmoothStep(
            float x, float min, float max
        ) {
            if (min >= max) {
                return 0f;
            }
            float t = Clamp01((x - min) / (max - min));
            return t * t * (3f - 2f * t);
        }

        public static float Sigmoid(
            float x, float centrum, float praeruptio
        ) {
            return 1f / (1f + MathF.Exp(-praeruptio * (x - centrum)));
        }

        public static float Sigmoid01(
            float x, float centrum, float praeruptio,
            float min, float max
        ) {
            x = Clamp01(x);

            float y = Sigmoid(x, centrum, praeruptio);

            return InverseLerp(min, max, y);
        }

        public static float Gaussian01(
            float x, float min, float max, float epsilon 
        ) {
            x = Clamp01(x);
            min = Clamp01(min);
            max = Clamp01(max);
            if (min >= max) {
                return 0f;
            }
            if (epsilon <= 0f || epsilon > 1f) {
                return 0f;
            }

            float centrum = (min + max) / 2f;
            float h = (max - min) / 2f;
            float sigma = h / MathF.Sqrt(-2f * MathF.Log(epsilon));

            return MathF.Exp(-MathF.Pow(x - centrum, 2f) / (2f * MathF.Pow(sigma, 2f)));
        }
    }
}