using System.Numerics;
using System;

namespace Yulinti.Nucleus {

    // UnityEngine縺ｫ縺ゅｋAngle縺ｨ縺九ｒSystem.Numerics縺ｧ螳溯｣・☆繧九・
    public static class InstrumentaNumeri {
        public static float Angulus(Vector3 v1, Vector3 v2) {
            float dot = Vector3.Dot(v1, v2);
            float mag = v1.Length() * v2.Length();

            if (mag == 0f)  return 0f;

            float cos = Math.Clamp(dot / mag, -1f, 1f);
            return MathF.Acos(cos) * Numerus.Rad2Deg;
        }

        public static float InterpolatioInversa(
            float min, float max, float v
        ) {
            if (min == max) return 0f;
            float t = (v - min) / (max - min);
            return Math.Clamp(t, 0f, 1f);
        }
    }
}
