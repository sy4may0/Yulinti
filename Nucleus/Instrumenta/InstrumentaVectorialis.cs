using System.Numerics;
using System;

namespace Yulinti.Nucleus {
    public static class InstrumentaVectorialis {
        public static float AngulusTriumPunctorum(
            Vector3 positioCentrale,
            Vector3 positioPrincipale,
            Vector3 positioSubsidiarius
        ) {
            Vector3 v1 = Vector3.Normalize(positioPrincipale - positioCentrale);
            Vector3 v2 = Vector3.Normalize(positioSubsidiarius - positioCentrale);

            return InstrumentaNumeri.Angulus(v1, v2);
        }

        public static float AngulusAdPondus(
            float angulus,
            float angulusMin,
            float angulusMax
        ) {
            float clamped = Math.Clamp(angulus, angulusMin, angulusMax);
            float t = InstrumentaNumeri.InterpolatioInversa(angulusMin, angulusMax, clamped);
            return t;
        }

        public static float AngulusAdPondusInversum(
            float angulus,
            float angulusMin,
            float angulusMax
        ) {
            return 1f - AngulusAdPondus(angulus, angulusMin, angulusMax);
        }

        public static float AngulusAdTriPondus(
            float angulus,
            float angulusMin,
            float angulusFastigii,
            float angulusMax
        ) {
            if (!(angulusMin < angulusFastigii && angulusFastigii < angulusMax)) return 0f;

            float pondusRisus = InstrumentaNumeri.InterpolatioInversa(angulusMin, angulusFastigii, angulus);
            float pondusCadus = 1f - InstrumentaNumeri.InterpolatioInversa(angulusFastigii, angulusMax, angulus);

            float tri01 = Math.Clamp(MathF.Min(pondusRisus, pondusCadus), 0f, 1f);
            return tri01;
        }
    }
}
