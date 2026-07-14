using System;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Nucleus.Instrumentarium {
    public static class Corrector {
        public static float GradareValorem(float valor, float gradus) {
            float y = Mathematica.Round(valor / gradus) * gradus;
            return y;
        }
    }
}