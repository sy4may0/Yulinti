using System;

namespace Yulinti.Dux.Exercitus {
    internal static class DuxMath {
        public static float Clamp(float value, float min, float max) {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}